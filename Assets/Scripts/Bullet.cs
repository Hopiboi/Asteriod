using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    [Header ("Bullet Settings")]
    [SerializeField] private float bulletSpeed = 400f;
    [SerializeField] private float maxTimer = 10f;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    
    public void Project(Vector2 direction)
    {
        rigidbody2d.AddForce(direction * this.bulletSpeed);

        Destroy(this.gameObject, this.maxTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
