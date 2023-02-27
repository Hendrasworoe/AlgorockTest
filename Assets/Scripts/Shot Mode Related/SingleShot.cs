using UnityEngine;

[CreateAssetMenu(fileName = "SingleShot", menuName = "This Project/Shot Type/SingleShot", order = 0)]
public class SingleShot : ShotMode
{
    public override void Shoting(Transform shotPoint)
    {
        GameObject bullet = ObjectPooling.Instance.GetPooledGameObject("Bullet");

        if (bullet != null)
        {
            bullet.transform.position = shotPoint.position;
            bullet.transform.rotation = shotPoint.rotation;
            bullet.GetComponent<Bullet>().SetDamage(applyingShotDamage);
            bullet.SetActive(true);
        }
    }
}
