using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerMovement2 player2;
    [SerializeField] private float respawnTime = 3f;
    [SerializeField] private int lives = 3;
    [SerializeField] private int lives2 = 3;

    [Header("Player")]
    [SerializeField] public bool _firstPlayerDead = false;
    [SerializeField] public bool _secondPlayerDead = false;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem explosion;

    [Header("Score System")]
    [SerializeField] private int points = 0;

    [Header("Stage System")]
    [SerializeField] public bool _canRestart = false;
    [SerializeField] private int levelCounter;

    [Header("Score and Lives Text")]
    public TMPro.TMP_Text livesText;
    public TMPro.TMP_Text lives2Text;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text score2Text;

    [Header("Game Over Screen")]
    [SerializeField] private GameObject GameOverScreen;

    [Header("Menu Manager")]
    public MenuManager menumanager;

    private void Update()
    {
        GameOverInteractableScreen();
    }


    // add variable points instead of scores to have efficient and more can be used in two players
    public void AsteroidDestroy(Asteriod asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if(asteroid.size < .75f)
        {
            this.points += 100;
        }
        else if (asteroid.size < 1.25f)
        {
            this.points += 50;
        }
        else
        {
            this.points += 25;
        }

       this.scoreText.text = this.points.ToString();
    }

    public void AsteroidDestroy2(Asteriod asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < .75f)
        {
            this.points += 100;
        }
        else if (asteroid.size < 1.25f)
        {
            this.points += 50;
        }
        else
        {
            this.points += 25;
        }

        this.score2Text.text = this.points.ToString();
    }

    public void PlayerDead()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;
        this.livesText.text = "x" + this.lives.ToString();

        if (this.lives <= 0)
        {
            _firstPlayerDead = true;
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    public void Player2Dead()
    {
        this.explosion.transform.position = this.player2.transform.position;
        this.explosion.Play();

        this.lives2--;
        this.lives2Text.text = this.lives2.ToString() + "x";

        if (this.lives2 <= 0)
        {
            _secondPlayerDead = true;
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn2), respawnTime);
        }
    }

    //Respawn
    private void Respawn()
    {
        //changing the layer
        ActiveInvicibility();
        FindObjectOfType<PlayerMovement>().InvicibilityOn();
        Invoke(nameof(InvicibilityOff), 3f);
    }

    private void Respawn2()
    {
        ActiveInvicibility2();
        FindObjectOfType<PlayerMovement2>().InvicibilityOn();
        Invoke(nameof(Invicibility2Off), 3f);
    }


    //invicibility code
    private void ActiveInvicibility()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Invicibility");
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void ActiveInvicibility2()
    {
        this.player2.gameObject.layer = LayerMask.NameToLayer("Invicibility");
        this.player2.transform.position = Vector3.zero;
        this.player2.gameObject.SetActive(true);
    }

    //turning off the invicibility
    private void InvicibilityOff()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
        FindObjectOfType<PlayerMovement>().ColorReset();
    }

    private void Invicibility2Off()
    {
        this.player2.gameObject.layer = LayerMask.NameToLayer("Player 2");
        FindObjectOfType<PlayerMovement2>().ColorReset();
    }

    // Game Over Section
    private void GameOver()
    {
        if (levelCounter <= 2)
        {
            if (_firstPlayerDead == true)
            {
                GameOverScreen.gameObject.SetActive(true);
                _canRestart = true;
            }
        }

        if (levelCounter == 3)
        {
            if (_firstPlayerDead == true && _secondPlayerDead == true)
            {
                GameOverScreen.gameObject.SetActive(true);
                _canRestart = true;
            }
        }
    }

    private void GameOverInteractableScreen()
    {

        if (_canRestart == true)
        {
            GameOverButtons();
        }
    }

    private void GameOverButtons()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _canRestart = false;
            GameOverScreen.gameObject.SetActive(false);
            menumanager.Restart();  
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            menumanager.MainMenu();
        }
    }

}

