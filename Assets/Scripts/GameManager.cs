using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    public int lives = 3;
    public float respawnTime = 3f;
    public void PlayerDied()
    {
        lives--;

        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
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
        //TODO
    }
}
