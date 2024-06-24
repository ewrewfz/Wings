using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowCam : MonoBehaviour
{
    public Camera _camera;
    public float distance = 1.1f;
    public float smoothTime = 0.3F;
    public float height = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPos = _camera.transform.TransformPoint(new Vector3(0, 0, distance));
        targetPos.y = height;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

        transform.LookAt(_camera.transform.position, Vector3.up);
    }

}
