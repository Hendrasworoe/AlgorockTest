using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 10;
    [SerializeField] private float _speed = 24f;
    [SerializeField] private float _lifeTime = 5f;
    private float _lifeTimeCounter;

    private Rigidbody2D _itsRigidbody;

    private void Awake()
    {
        _itsRigidbody = GetComponent<Rigidbody2D>();
        _lifeTimeCounter = _lifeTime;
    }

    private void OnEnable()
    {
        _lifeTimeCounter = _lifeTime;
    }

    private void FixedUpdate()
    {
        _itsRigidbody.velocity = transform.up * _speed;
        _lifeTimeCounter -= Time.deltaTime;

        if (_lifeTimeCounter <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
    }
}
