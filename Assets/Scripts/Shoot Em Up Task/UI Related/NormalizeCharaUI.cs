using UnityEngine;

public class NormalizeCharaUI : MonoBehaviour
{
    private Character _chara;

    private void Awake()
    {
        _chara = GetComponentInParent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        Normalize();
    }

    private void Normalize()
    {
        float alpha = _chara.transform.rotation.eulerAngles.z;

        Quaternion locrot_new = Quaternion.Euler(0f, 0f, -alpha);

        transform.localRotation = locrot_new;
    }
}
