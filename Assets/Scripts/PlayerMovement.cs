using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    [Header("Bullet Prefab")]
    [SerializeField] private Bullet bulletprefab;

    [Header ("PlayerMovement")]
    [SerializeField] private float thrustSpeed = 2f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float turnDirection;
    [SerializeField] private bool _thrustMovement;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _thrustMovement = Input.GetKey(KeyCode.W);

        //left
        if (Input.GetKey(KeyCode.A))
        {
            turnDirection = 1.0f;
        }
        //right
        else if (Input.GetKey(KeyCode.D))
        {
            turnDirection = -1.0f;
        }
        //neutral
        else
        {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        if (_thrustMovement)
        {
            rigidbody2d.AddForce(this.transform.up * thrustSpeed);
        }

        if (turnDirection != 0f)
        {
            rigidbody2d.AddTorque(turnDirection * rotationSpeed);
        }
    }

    //instantiate or creating the bullet
    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletprefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
}
