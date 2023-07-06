using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject killOrbPrefab;
    public GameObject doubleScore;
    public GameObject shield;
    public int scorelimit = 500;
    
    private void Update()
    {
        if(scorelimit <= gameManager.GetScore())
        {
            scorelimit += scorelimit;
            ActivateOrb();
        }
    }

    private void ActivateOrb()
    {
        int getRandomOrb = Random.Range(1, 4);
        switch(getRandomOrb)
        {
            case 1:KillOrb();
                break;
            case 2:DoubleScore();
                break;
            case 3:Shield();
                break;
        }
    }

    private void KillOrb()
    {
            
    
    }

    private void DoubleScore()
    {

    }

    private void Shield()
    {

    }
}
