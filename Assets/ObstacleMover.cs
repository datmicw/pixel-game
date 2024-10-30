using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 2f;         // Tốc độ di chuyển
    public float moveDistance = 2f;  // Khoảng cách di chuyển tối đa
    private Vector3 startPosition;   // Lưu vị trí ban đầu

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Kiểm tra tag để xác định hướng di chuyển
        if (CompareTag("Doc"))
        {
            MoveVertical();  // Di chuyển dọc
        }
        else if (CompareTag("Ngang"))
        {
            MoveHorizontal(); // Di chuyển ngang
        }
    }

    private void MoveVertical()
    {
        // vị trí mới theo trục Y để tạo chuyển động lên xuống
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void MoveHorizontal()
    {
        // vị trí mới theo trục X để tạo chuyển động qua lại
        float newX = startPosition.x + Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(newX, startPosition.y, startPosition.z);
    }
}
