using UnityEngine;

[CreateAssetMenu(fileName = "TripleShot", menuName = "This Project/Shot Type/TripleShot", order = 0)]
public class TripleShot : ShotMode
{
    public override void Shoting(Transform shotPoint)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = ObjectPooling.Instance.GetPooledGameObject("Bullet");

            if (bullet != null)
            {
                bullet.transform.position = shotPoint.position;
                bullet.transform.rotation = Quaternion.Euler(shotPoint.rotation.eulerAngles + Vector3.forward * (i - 1) * -20f);
                bullet.GetComponent<Bullet>().SetDamage(applyingShotDamage);
                bullet.SetActive(true);
            }
        }
    }
}
