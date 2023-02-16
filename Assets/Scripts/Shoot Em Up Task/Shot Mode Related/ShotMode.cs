using UnityEngine;

public abstract class ShotMode : ScriptableObject
{
    public int shotBaseDamage = 10;
    public int maxShotDamage = 20;
    [HideInInspector] public int applyingShotDamage;

    // this can be added other detail like bullet image, bullet move speed, etc.

    public abstract void Shoting(Transform shotPoint);
}
