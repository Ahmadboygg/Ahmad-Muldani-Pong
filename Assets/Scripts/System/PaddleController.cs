using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float speed = 0;

    private Rigidbody2D rigidbody2D;
    private float maxPaddleHeight;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        maxPaddleHeight = Camera.main.orthographicSize - 0.5f;
    }

    void Update()
    {
        MoveObject(GetInput());
    }

    Vector2 GetInput()
    {

        if(Input.GetKey(upKey))
        {
           return Vector2.up * speed;
        }
        else if(Input.GetKey(downKey))
        {
           return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    void MoveObject(Vector2 movement)
    {
        Vector2 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -maxPaddleHeight + 2f, maxPaddleHeight);
        transform.position = clampedPosition;
        rigidbody2D.velocity = movement;
    }
}
