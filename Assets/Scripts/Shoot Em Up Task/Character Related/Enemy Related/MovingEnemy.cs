using UnityEngine;

public class MovingEnemy : Enemy
{
    [SerializeField] private float _speed = 1f;

    private Player _moveTarget;

    private void Awake()
    {
        _moveTarget = FindObjectOfType<Player>();
    }

    protected override void EnemySetting()
    {
        base.EnemySetting();
    }

    protected override void EnemyBehaviour()
    {
        base.EnemyBehaviour();

        var target_pos = _moveTarget.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, target_pos, _speed * Time.deltaTime);

        var delta_pos = target_pos - transform.position;
        float deg_amount = Mathf.Atan2(delta_pos.y, delta_pos.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, deg_amount);
    }
}
