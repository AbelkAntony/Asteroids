using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] UI ui;

    [SerializeField] Player player;
    [SerializeField] ParticleSystem explosion;
    private int lives = 3;
    private float respawnTime = 3f;
    private int score = 0;

    private void Awake()
    {
        ui.SetState(false);
        Time.timeScale = 0f;
    }


    public void NewGame()
    {
        Time.timeScale = 1f;
        ui.SetState(true);
        this.lives = 3;
        this.score = 0;
        ui.DisplayLife(lives);
        ui.DisplayScore(score);

        PlayerSpwan();
    }
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.75f)
        {
            this.score += 100;
        }
        else if (asteroid.size < 1.2f)
        {
            this.score += 50;
        }
        else
        {
            this.score += 25; 
        }
        ui.DisplayScore(score);
    }
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        lives--;

        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            ui.DisplayLife(lives);
            Invoke(nameof(PlayerSpwan),this.respawnTime);
        }
    }

    private void PlayerSpwan()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollission), 3f);
    }

    private void TurnOnCollission()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        ui.DisplayGameOver();
    }
}
