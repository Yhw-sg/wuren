using UnityEngine;

public class MouseWheelZoom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minDistance = 2f;
    public float maxDistance = 20f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            // 计算新的相机位置
            Vector3 direction = transform.forward;
            float distance = Vector3.Distance(transform.position, transform.position + direction);

            // 限制距离范围
            distance = Mathf.Clamp(distance - scroll * zoomSpeed, minDistance, maxDistance);

            // 应用新位置
            transform.position = transform.position + direction * (distance - Vector3.Distance(transform.position, transform.position + direction));
        }
    }
}