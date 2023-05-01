using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float speed = 0;
    public float speedUp = 0;
    private float currentSpeed;
    private float currentSpeedUpTime;
    private float currentSizeUpTime;

    private Rigidbody2D rigidbody2D;
    private Vector2 paddleScale;
    private float maxPaddleHeight;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        maxPaddleHeight = Camera.main.orthographicSize - 0.5f;
    }
    void Start() 
    {
        paddleScale = transform.localScale;
        currentSpeed = speed;
    }

    void Update()
    {
        MoveObject(GetInput());
        GetCurrentSpeed();

        if(currentSpeedUpTime > 0)
        {
            currentSpeedUpTime -= Time.deltaTime;
        }
        else
        {
            ResetSpeedUp();
        }

        if(currentSizeUpTime > 0)
        {
            currentSizeUpTime -= Time.deltaTime;
        }
        else
        {
            ResetSizeUp();
        }
    }

    Vector2 GetInput()
    {

        if(Input.GetKey(upKey))
        {
           return Vector2.up * currentSpeed;
        }
        else if(Input.GetKey(downKey))
        {
           return Vector2.down * currentSpeed;
        }

        return Vector2.zero;
    }

    void MoveObject(Vector2 movement)
    {
        Vector2 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -maxPaddleHeight + 2f, maxPaddleHeight);
        transform.position = clampedPosition;
        rigidbody2D.velocity = movement;
        Debug.Log($"{gameObject} : {PaddleDirectionString()}");
    }

    string PaddleDirectionString()
    {
        if(rigidbody2D.velocity.y > 0)
        {
            return $"Bergerak ke atas dengan kecepatan {currentSpeed}";
        }
        else if(rigidbody2D.velocity.y < 0)
        {
            return $"Bergerak ke bawah dengan kecepatan {currentSpeed}";
        }
        else
        {
            return "Tidak Bergerak";
        }
    }

    public void SpeedUp()
    {
        currentSpeed *= speedUp;
        currentSpeedUpTime = 5f;
    }

    public void ResetSpeedUp()
    {
        currentSpeed = speed;
    }

    float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SizeUp()
    {
        transform.localScale = paddleScale * 2f;
        currentSizeUpTime = 5f;
    }

    public void ResetSizeUp()
    {
        transform.localScale = paddleScale;
    }
}
