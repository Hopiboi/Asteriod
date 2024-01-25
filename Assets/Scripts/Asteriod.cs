using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    [Header("Asteroid Settings")]
    [SerializeField] private Sprite[] sprites;
    [SerializeField] public float size = 1f;
    [SerializeField] public float minSize = 0.5f;
    [SerializeField] public float maxSize = 1.5f;
    [SerializeField] private float asteroidSpeed = 50f;
    [SerializeField] private float maxLifeTime = 40f;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Random
    void Start()
    {
        //random sprite
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        //random rotation
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        //random scale, size
        this.transform.localScale = Vector3.one * this.size;

        // more size, more mass, much heavier
        rigidBody2D.mass = this.size * 2;
    }


    public void SetTrajectory(Vector2 direction)
    {
        rigidBody2D.AddForce(direction * this.asteroidSpeed);

        Destroy(this.gameObject, this.maxLifeTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //split condition if its still in range in size range
            if ((this.size * 0.5f) > this.minSize)
            {
                CreatingSplit();
                CreatingSplit();
            }

            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().AsteroidDestroy(this); 
        }

        // adding if condition to bullet 2
    }

    private void CreatingSplit()
    {
        //position random
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        //instantiate
        Asteriod half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.asteroidSpeed);
    }
}
