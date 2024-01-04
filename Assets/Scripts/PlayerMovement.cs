using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

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
}
