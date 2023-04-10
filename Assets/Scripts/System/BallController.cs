using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour, IScoreable
{
    public float speed = 0;
    private Rigidbody2D rigidbody2D;
    private Vector2 ballDirection;
    private Vector2 currentDirection;
    private Vector3 lastVelocity;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentDirection = BallDirection.direction;
        rigidbody2D.velocity = currentDirection * speed;
    }

    void Update()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Wall"))
        {
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
            rigidbody2D.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other != null)
        {
            if(other.gameObject.name =="Trigger Score Kiri")
            {
                BallDirection.direction = Vector2.left ;
            }
            else if(other.gameObject.name == "Trigger Score Kanan")
            {
                BallDirection.direction = Vector2.right ;
            }
            
            Destroy(gameObject);
        }
    }

    public void GetScore()
    {
        Score.score++;
    }
    
}
