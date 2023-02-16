using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling _instance;
    public static ObjectPooling Instance { get { return _instance; } }

    private Dictionary<string, List<GameObject>> _pooledObjects = new Dictionary<string, List<GameObject>>();

    [SerializeField] private List<SpawnItem> _spawnItemData;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitiateAllPoolingObjects();

        GameManager.Instance.OnGameStateChanged += DisableAllChildOnGameover;
    }

    private void InitiateAllPoolingObjects()
    {
        foreach (var item in _spawnItemData)
        {
            List<GameObject> cur_objs = new List<GameObject>();

            for (int i = 0; i < item.poolingAmount; i++)
            {
                GameObject obj = Instantiate(item.itemPrefab, transform);
                obj.SetActive(false);
                cur_objs.Add(obj);
            }

            string item_type = item.itemType.ToString();
            if (_pooledObjects.ContainsKey(item_type))
            {
                _pooledObjects[item_type].AddRange(cur_objs);
            }
            else
            {
                _pooledObjects.Add(item_type, cur_objs);
            }
        }
    }

    private void DisableAllChildOnGameover(GameState gameState)
    {
        if (gameState != GameState.GameOver) return;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public List<string> GetAvailableKey()
    {
        return _pooledObjects.Keys.ToList();
    }

    public GameObject GetPooledGameObject(string objectKey)
    {
        var inactive = _pooledObjects[objectKey].Where(i => !i.activeInHierarchy).ToList();
        if (inactive.Count > 0)
        {
            int rand = Random.Range(0, inactive.Count);
            return inactive[rand];
        }

        return null;
    }
}
