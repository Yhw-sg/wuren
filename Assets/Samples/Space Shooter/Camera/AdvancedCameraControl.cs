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
            // �����µ����λ��
            Vector3 direction = transform.forward;
            float distance = Vector3.Distance(transform.position, transform.position + direction);

            // ���ƾ��뷶Χ
            distance = Mathf.Clamp(distance - scroll * zoomSpeed, minDistance, maxDistance);

            // Ӧ����λ��
            transform.position = transform.position + direction * (distance - Vector3.Distance(transform.position, transform.position + direction));
        }
    }
}