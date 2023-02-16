using UnityEngine;

public class OutBoundaryBehaviour : MonoBehaviour
{
    [SerializeField] private float _boundDistFromCamRect = 3f;
    // Update is called once per frame
    void Update()
    {
        // calculate this game object out boundary or not
        float cam_dis = Camera.main.transform.position.z;
        Vector3 bl_point = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cam_dis)); // bottom-left point from perspective camera
        Vector3 tr_point = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cam_dis)); // top-right point from perspective camera
        Vector3 cur_pos = transform.position;
        bool out_bound = (cur_pos.x < bl_point.x - _boundDistFromCamRect || cur_pos.x > tr_point.x + _boundDistFromCamRect) ||
            (cur_pos.y < bl_point.y - _boundDistFromCamRect || cur_pos.y > tr_point.y + _boundDistFromCamRect);

        if (out_bound) // check if its out of boundary
        {
            gameObject.SetActive(false);
        }
    }
}
