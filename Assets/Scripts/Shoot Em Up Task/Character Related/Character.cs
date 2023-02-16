using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int _hp = 30;
    private int _calculatedHp;

    public UnityAction<int, int> OnHpChanged = delegate { };

    private void OnEnable()
    {
        OnEnableSetting();
        _calculatedHp = _hp;

        OnHpChanged(_calculatedHp, _hp);
    }

    protected abstract void OnEnableSetting();
    protected abstract void OnDie();

    public void TakeDamage(int damage)
    {
        _calculatedHp -= damage;

        OnHpChanged(_calculatedHp, _hp);

        if (_calculatedHp <= 0)
        {
            OnDie();
        }
    }

    public void IncreaseHealth(int increaseAmount)
    {
        _calculatedHp += increaseAmount;
        if (_calculatedHp > _hp)
        {
            _calculatedHp = _hp;
        }

        OnHpChanged(_calculatedHp, _hp);
    }
}
