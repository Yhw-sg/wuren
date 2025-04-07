using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 xLimit = new Vector2(-10, 10);
    public Vector2 zLimit = new Vector2(-10, 10);
    public float dragSpeed = 2f;

    private Vector3 dragOrigin;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        HandleDrag();
    }

    void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        Vector3 newPosition = transform.position + move;

        // 应用边界限制
        newPosition.x = Mathf.Clamp(newPosition.x,
            originalPosition.x + xLimit.x,
            originalPosition.x + xLimit.y);

        newPosition.z = Mathf.Clamp(newPosition.z,
            originalPosition.z + zLimit.x,
            originalPosition.z + zLimit.y);

        transform.position = newPosition;
       //dragOrigin = Input.mousePosition;
    }
}