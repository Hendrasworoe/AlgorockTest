using UnityEngine;

[CreateAssetMenu(fileName = "SpawnItem", menuName = "This Project/SpawnItem", order = 0)]
public class SpawnItem : ScriptableObject
{
    public GameObject itemPrefab;
    public int poolingAmount;
    public ItemType itemType;
}
