using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float respawnTime = 3f;
    [SerializeField] private int lives = 3;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem explosion;

    [Header("Score System")]
    [SerializeField] private int score = 0;

    public void AsteroidDestroy(Asteriod asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

    }

    public void PlayerDead()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
        
    }

    private void Respawn()
    {
        //changing the layer
        this.player.gameObject.layer = LayerMask.NameToLayer("Invicibility");
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        Invoke(nameof(InvicibilityOff), 3f);
    }

    //turning off the invicibility
    private void InvicibilityOff()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {

    }
}
