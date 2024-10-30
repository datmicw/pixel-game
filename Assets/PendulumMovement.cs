using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    public Transform pendulum; // Đối tượng Pendulum
    public LineRenderer lineRenderer; // Đối tượng LineRenderer
    public float swingSpeed = 2.0f; // Tốc độ dao động
    public float maxSwingAngle = 45.0f; // Góc dao động tối đa

    private void Start()
    {
        // Thiết lập LineRenderer để nối hai điểm
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        // Tính toán góc dao động dựa trên thời gian
        float angle = maxSwingAngle * Mathf.Sin(Time.time * swingSpeed);

        // Cập nhật vị trí của vật thể dao động dựa trên góc dao động
        pendulum.localPosition = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad), 0) * 2f;

        // Cập nhật vị trí của LineRenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pendulum.position); 
    }
}
