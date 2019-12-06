using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTriggerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.05f;

    private Collider2D RatCollider;

    private void Start()
    {
        RatCollider = transform.GetComponent<Collider2D>();
    }
    
    public void Run(Vector3 endVector)
    {
        if(transform.position != endVector)
        {
            transform.position = Vector3.MoveTowards(transform.position, endVector, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, RatCollider);
        }
    }
}
