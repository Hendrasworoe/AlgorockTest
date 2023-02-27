using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    [SerializeField] private Transform _objectFollowed;

    [Range(0, 1)]
    [SerializeField] private float _smoothTime;

    [SerializeField] private Vector3 _positionOffset = new Vector3(0f, 0f, -10f);

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 target_pos = _objectFollowed.position + _positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, target_pos, ref velocity, _smoothTime);
    }
}
