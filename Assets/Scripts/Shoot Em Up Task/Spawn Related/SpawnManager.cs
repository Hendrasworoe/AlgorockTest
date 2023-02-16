using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 3f;
    [SerializeField] private float _widthSpawnSector = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        // Find Only enemy & Power Up
        var available_key = ObjectPooling.Instance.GetAvailableKey();
        available_key.Remove("Bullet");

        while (true) // maybe can change game still running
        {
            string spawn_type = available_key[Random.Range(0, available_key.Count)];
            SpawnObject(spawn_type);

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void SpawnObject(string objectName)
    {
        GameObject obj = ObjectPooling.Instance.GetPooledGameObject(objectName);

        if (obj != null)
        {
            obj.transform.position = GenerateSpawnPoint();
            obj.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            obj.SetActive(true);
        }
    }

    private Vector2 GenerateSpawnPoint()
    {
        float cam_dis = Camera.main.transform.position.z;
        Vector3 bl_point = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cam_dis)); // bottom-left point from perspective camera
        Vector3 tr_point = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cam_dis)); // top-right point from perspective camera

        int rng = Random.Range(0, 4);

        // find instantiate point at instantiate area
        float x_point = 0f;
        float y_point = 0f;
        switch (rng)
        {
            case 0: // top
                x_point = Random.Range(bl_point.x - _widthSpawnSector, tr_point.x + _widthSpawnSector);
                y_point = Random.Range(tr_point.y, tr_point.y + _widthSpawnSector);
                break;
            case 1: // right
                x_point = Random.Range(tr_point.x, tr_point.x + _widthSpawnSector);
                y_point = Random.Range(bl_point.y - _widthSpawnSector, tr_point.y + _widthSpawnSector);
                break;
            case 2: // bottom
                x_point = Random.Range(bl_point.x - _widthSpawnSector, tr_point.x + _widthSpawnSector);
                y_point = Random.Range(bl_point.y - _widthSpawnSector, bl_point.y);
                break;
            case 3: // left
                x_point = Random.Range(bl_point.x - _widthSpawnSector, bl_point.x);
                y_point = Random.Range(bl_point.y - _widthSpawnSector, tr_point.y + _widthSpawnSector);
                break;
        }

        return new Vector2(x_point, y_point);
    }
}
