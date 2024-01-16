using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float respawnTime = 3f;
    [SerializeField] private int lives = 3;

    public void PlayerDead()
    {
        this.lives--;

        if (this.lives < 0)
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
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void GameOver()
    {

    }
}
