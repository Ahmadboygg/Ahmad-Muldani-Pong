using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour, IScoreable, ISpeedable, ISizeable
{
    public float speed = 0;
    public float speedUp = 0;
    private float currentSpeed;
    private Rigidbody2D rigidbody2D;
    private Vector2 ballDirection;
    private Vector2 currentDirection;
    private Vector3 lastVelocity;
    private Vector2 paddleSizeUp;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentDirection = BallDirection.direction;
        currentSpeed = speed;
        rigidbody2D.velocity = currentDirection * currentSpeed;
    }

    void Update()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Wall"))
        {
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
            rigidbody2D.velocity = direction * currentSpeed;
        }
        else
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * currentSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other != null)
        {
            if(other.gameObject.name =="Trigger Score Kiri")
            {
                BallDirection.direction = Vector2.left ;
                Destroy(gameObject);
            }
            else if(other.gameObject.name == "Trigger Score Kanan")
            {
                BallDirection.direction = Vector2.right ;
                Destroy(gameObject);
            }
        }
    }

    public void GetScore()
    {
    
    }

    public void BallSpeedUp()
    {
        currentSpeed += speedUp;
        Debug.Log("Speed :" +currentSpeed);
    }

    public void ResetBallSpeedUp()
    {
        currentSpeed = speed;
        Debug.Log("Speed :" +currentSpeed);
    }

    public void PaddleSpeedUp()
    {
        if(rigidbody2D.velocity.x > 0)
        {
           GameObject.Find("Paddle Kiri").GetComponent<PaddleController>().SpeedUp();
        }
        else if(rigidbody2D.velocity.x < 0)
        {
           GameObject.Find("Paddle Kanan").GetComponent<PaddleController>().SpeedUp();
        }
    }

    public void ResetPaddleSpeedUp()
    {
        GameObject.Find("Paddle Kiri").GetComponent<PaddleController>().ResetSpeedUp();
        GameObject.Find("Paddle Kanan").GetComponent<PaddleController>().ResetSpeedUp();
    }


    public void IncreaseSize()
    {
        if(rigidbody2D.velocity.x < 0)
        {
           GameObject.Find("Paddle Kanan").gameObject.GetComponent<PaddleController>().SizeUp();
           
        }
        else if(rigidbody2D.velocity.x > 0)
        {
           GameObject.Find("Paddle Kiri").gameObject.GetComponent<PaddleController>().SizeUp();
        }
    }

    public void ResetToDeffaultSize()
    {
        GameObject.Find("Paddle Kanan").gameObject.GetComponent<PaddleController>().ResetSizeUp();
        GameObject.Find("Paddle Kiri").gameObject.GetComponent<PaddleController>().ResetSizeUp();
    }
}
