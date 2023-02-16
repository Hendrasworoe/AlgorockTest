using UnityEngine;

public class IncreaseShotDmg : PowerUp
{
    [SerializeField] private int _dmgAdder = 2;
    protected override void OnItemPicked(Player player)
    {
        player.IncreaseShotDamage(_dmgAdder);
    }
}
