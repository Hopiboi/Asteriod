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

    [Header("Score and Lives Text")]
    public TMPro.TMP_Text livesText;
    public TMPro.TMP_Text scoreText;

    [Header("Game Over Screen")]
    [SerializeField] private GameObject GameOverScreen;

    public void AsteroidDestroy(Asteriod asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if(asteroid.size < .75f)
        {
            this.score += 100;
        }
        else if (asteroid.size < 1.25f)
        {
            this.score += 50;
        }
        else
        {
            this.score += 25;
        }

       this.scoreText.text = this.score.ToString();
    }

    public void PlayerDead()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;
        this.livesText.text = "x" + this.lives.ToString();

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
        FindObjectOfType<PlayerMovement>().InvicibilityOn();
        Invoke(nameof(InvicibilityOff), 3f);

            
    }

    //turning off the invicibility
    private void InvicibilityOff()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
        FindObjectOfType<PlayerMovement>().ColorReset();
    }

    private void GameOver()
    {
        GameOverScreen.gameObject.SetActive(true);
    }
}
