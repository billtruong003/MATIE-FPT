using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField]
    private Transform rabbitPlace;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;

    private bool isDragging = false;
    private Vector3 touchStartPos;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!locked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Bắt đầu kéo bằng chuột hoặc chạm màn hình
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
                {
                    isDragging = true;
                    touchStartPos = mousePos - transform.position;
                }
            }

            if (isDragging)
            {
                // Di chuyển đối tượng bằng chuột hoặc chạm màn hình
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePos.x - touchStartPos.x, mousePos.y - touchStartPos.y);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                if (Mathf.Abs(transform.position.x - rabbitPlace.position.x) <= 0.5f &&
                    Mathf.Abs(transform.position.y - rabbitPlace.position.y) <= 0.5f)
                {
                    // Nếu đối tượng nằm ở đúng vị trí đích, khóa nó
                    transform.position = new Vector3(rabbitPlace.position.x, rabbitPlace.position.y, 0);
                    locked = true;
                }
                else
                {
                    // Nếu không, đặt lại vị trí ban đầu
                    transform.position = new Vector3(initialPosition.x, initialPosition.y, 0);
                }
            }
        }
    }
    public void ResetToInitialState()
    {
        transform.position = initialPosition; // initialPosition là vị trí ban đầu của đối tượng
        locked = false;
        // Thêm bất kỳ trạng thái khác cần đặt lại ở đây
    }

}
