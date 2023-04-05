using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public int speed = 0;
    void Start()
    {
        
    }

    void Update()
    {
        MoveObject(GetInput());
    }

    Vector2 GetInput()
    {

        if(Input.GetKey(upKey))
        {
           return Vector2.up;
        }
        else if(Input.GetKey(downKey))
        {
           return Vector2.down;
        }

        return Vector2.zero;
    }

    void MoveObject(Vector2 movement)
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
