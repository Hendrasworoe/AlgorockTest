using UnityEngine;

public class FollowScrollBackground : MonoBehaviour
{
    private Material _itsMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _itsMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float x_offset = transform.position.x / transform.localScale.x;
        float y_offset = transform.position.y / transform.localScale.y;
        _itsMaterial.mainTextureOffset = Vector2.right * x_offset + Vector2.up * y_offset;
    }
}
