using UnityEngine;

public class RotatingEnemy : Enemy
{
    [SerializeField] private float _rotateSpeed = 20f;

    protected override void EnemyBehaviour()
    {
        base.EnemyBehaviour();

        transform.RotateAround(transform.position, Vector3.back, _rotateSpeed * Time.deltaTime);
    }
}
