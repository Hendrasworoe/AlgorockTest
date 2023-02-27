using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float _moveSpeed = 2f;

    [SerializeField] private float _fireRate = 0.2f;
    private float _calculatedFireRate;

    [SerializeField] private Transform _shotPoint;
    [SerializeField] private List<ShotMode> _shotModeList;
    private int _acumulatedDamageAdder;
    private int _currentWeapon;
    private float _switchingCD;

    private delegate void Shoting(Transform shotPoint);
    private Shoting _shot;

    private Rigidbody2D _itsRigidbody;

    protected override void OnEnableSetting()
    {
        _itsRigidbody = GetComponent<Rigidbody2D>();
        _calculatedFireRate = 0;

        _currentWeapon = 0;
        _acumulatedDamageAdder = 0;
        IncreaseShotDamage(_acumulatedDamageAdder);
        _shot = _shotModeList[_currentWeapon].Shoting;
    }

    protected override void OnDie()
    {
        GameManager.Instance.UpdateGameState(GameState.GameOver);
        gameObject.SetActive(false);
    }


    private void FixedUpdate()
    {
        Move();
        Rotate();
        SwitchWeapon();
        Shoot();
    }

    private void Move()
    {
        Vector2 dir = Vector2.right * Input.GetAxisRaw("Horizontal") + Vector2.up * Input.GetAxisRaw("Vertical");
        _itsRigidbody.MovePosition(_itsRigidbody.position + _moveSpeed * dir.normalized * Time.deltaTime);
    }

    private void Rotate()
    {
        var mouse_world_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 look_target = new Vector3(mouse_world_pos.x, mouse_world_pos.y, 0f);

        var delta_pos = look_target - transform.position;
        float deg_amount = Mathf.Atan2(delta_pos.y, delta_pos.x) * Mathf.Rad2Deg - 90;
        _itsRigidbody.SetRotation(deg_amount);
    }

    private void SwitchWeapon()
    {
        if (Input.GetButton("Fire2") && _switchingCD <= 0)
        {
            _currentWeapon++;
            if (_currentWeapon >= _shotModeList.Count)
            {
                _currentWeapon = 0;
            }
            _shot = _shotModeList[_currentWeapon].Shoting;

            _switchingCD = 0.15f;
        }

        if (_switchingCD > 0)
        {
            _switchingCD -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1") && _calculatedFireRate <= 0)
        {
            _shot(_shotPoint);
            _calculatedFireRate = _fireRate;
        }

        if (_calculatedFireRate > 0)
        {
            _calculatedFireRate -= Time.deltaTime;
        }
    }

    public void IncreaseShotDamage(int adderAmount)
    {
        _acumulatedDamageAdder += adderAmount;

        if (_acumulatedDamageAdder < 0)
        {
            _acumulatedDamageAdder = 0;
        }

        foreach (var mode in _shotModeList)
        {
            mode.applyingShotDamage = mode.shotBaseDamage + _acumulatedDamageAdder;

            if (mode.applyingShotDamage > mode.maxShotDamage)
            {
                mode.applyingShotDamage = mode.maxShotDamage;
            }

            if (mode.applyingShotDamage < mode.shotBaseDamage)
            {
                mode.applyingShotDamage = mode.shotBaseDamage;
            }
        }
    }
}
