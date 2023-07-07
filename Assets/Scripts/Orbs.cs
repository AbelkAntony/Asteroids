using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject killOrbPrefab;
    [SerializeField] GameObject OrbPrefab;
    private GameObject orb;
    //public GameObject doubleScore;
    //public GameObject shield;
    public int scorelimit = 500;
    private Vector3 randomPosition;

    private void Start()
    {
        orb = Instantiate(OrbPrefab);
        orb.SetActive(false);
    }
    private void Update()
    {
        if(scorelimit <= gameManager.GetScore())
        {
            scorelimit += scorelimit;
            ActivateOrb();
            Debug.Log("orb");
        }
    }

    private void ActivateOrb()
    {
        randomPosition = gameManager.GetRandomPosition();
        orb.transform.position = randomPosition;
        orb.SetActive(true);
        Debug.Log("orbActivate");
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            orb.SetActive(false);
            Debug.Log("Orb False collision");
        }
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            orb.SetActive(false);
            Debug.Log("Orb False");
        }
        int getRandomOrb = Random.Range(1, 4);

        switch (getRandomOrb)
        {
            case 1:
                KillOrb();
                break;
            case 2:
                DoubleScore();
                break;
            case 3:
                Shield();
                break;
        }
    }

    private void KillOrb()
    {

        GameObject killOrb = Instantiate(killOrbPrefab);
        killOrbPrefab.transform.localScale = Vector3.one * Time.deltaTime;
        Debug.Log("Kill Orb");
    }

    private void DoubleScore()
    {
        gameManager.SetScoreMultiplier(2);
        Debug.Log("Double score");
    }

    private void Shield()
    {
        gameManager.TurnOffCollision();
        Debug.Log("Shield");
    }
}
