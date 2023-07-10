using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Orbs orb;
    [SerializeField] UI ui;
    [SerializeField] BoxCollider2D gridArea;
    [SerializeField] Player player;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] AsteroidSpwaner asteroidSpwaner;
    public int lives;
    private float respawnTime = 3f;
    private int score;
    private Vector3 randomPosition;
    private int scoreMultiplier;

    public int GetScore() { return score; }


    private void Awake()
    {
        ui.SetState(false);
        ui.DisplayGameOver(false);
        this.player.gameObject.SetActive(false);
        //Time.timeScale = 0f;
    }


    public void NewGame()
    {
        Time.timeScale = 1f;
        ui.SetState(true);
        this.lives = 1;
        this.score = 0;
        this.scoreMultiplier = 1;
        ui.DisplayLife(lives);
        ui.DisplayScore(score);
        ui.DisplayGameOver(false);
        PlayerSpwan();
        asteroidSpwaner.SpwanAsteroids();
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

    public Vector3 GetRandomPosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        randomPosition = new Vector3(x, y, 0f);
        return randomPosition;
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

    public void TurnOffCollision()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        Invoke(nameof(TurnOnCollission), 5f);
        Debug.Log("Shield off");
    }

    private void GameOver()
    {
        
        ui.DisplayGameOver(true);
        asteroidSpwaner.CancelInvoke();
        ui.SetState(false);

    }

    public void SetScoreMultiplier(int multiplier)
    {
        scoreMultiplier = multiplier;
        Invoke(nameof(ResetScoreMultiplier), 5f);
    }

    private void ResetScoreMultiplier()
    {
        scoreMultiplier = 1;
    }

    public void OrbTaken()
    {
        orb.ActivateOrb();
    }

}
