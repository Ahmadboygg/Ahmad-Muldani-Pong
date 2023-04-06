using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public int speed = 0;

    private Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
        rigidbody2D.velocity = movement;
    }
}
