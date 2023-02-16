using UnityEngine;

public class IncreaseHp : PowerUp
{
    [SerializeField] private int _incrHpAmount = 10;

    protected override void OnItemPicked(Player player)
    {
        player.IncreaseHealth(_incrHpAmount);
    }
}
