using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject orb;
    //private GameObject orb;
    //public GameObject doubleScore;
    //public GameObject shield;
    public int scorelimit = 500;
    private Vector3 randomPosition;
    private int getRandomOrb;

    public int GetScoreLimit() { return scorelimit; }
    private void Start()
    {
        orb.SetActive(false); 
    }
    private void Update()
    {
        if(scorelimit <= gameManager.GetScore())
        {
            Debug.Log("orb");
            
            SpawnOrb();
            scorelimit += 500;
        }
    }

    public void SpawnOrb()
    {
        randomPosition = gameManager.GetRandomPosition();
        Debug.Log("random position");
        orb.transform.position = randomPosition;
        orb.SetActive(true);
        Debug.Log("orbActivate");
        getRandomOrb = Random.Range(1, 4);

        switch (getRandomOrb)
        {
            case 1:
                //todo
                break;
            case 2:
                //todo
                break;
            case 3:
                //todo
                break;
        }

    }

 
    public void ActivateOrb()
    {
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
