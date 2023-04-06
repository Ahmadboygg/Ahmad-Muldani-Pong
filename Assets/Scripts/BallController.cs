using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody2D rigidbody2D;
    Vector3 lastVelocity;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.right * speed;
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
            Debug.Log($"wall direction : {direction}");
        }

        if(other.collider.CompareTag("Paddle"))
        {
            Debug.Log(rigidbody2D.velocity);
        }
    }
}
