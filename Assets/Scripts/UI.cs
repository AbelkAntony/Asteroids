using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject scoreTitle;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject lifeTitle;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject gameName;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI orbText;
    [SerializeField] GameObject activatedUi;

 
    public void SetState(bool state)
    {
        scoreTitle.gameObject.SetActive(state);
        scoreText.gameObject.SetActive(state);
        lifeTitle.gameObject.SetActive(state);
        lifeText.gameObject.SetActive(state);
        orbText.gameObject.SetActive(false);
        activatedUi.gameObject.SetActive(false);
        if(state)
        {
            startButton.SetActive(false);
            gameName.SetActive(false);
        }
        else
        {
            gameOver.SetActive(true);
            startButton.SetActive(true);
            gameName.SetActive(true);
        }
    }

    
    public void DisplayScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void DisplayLife(int lives)
    {
        lifeText.text = lives.ToString();
    }

    public void DisplayGameOver(bool state)
    {
        gameOver.SetActive(state);
       
    }

    public void OrbUi(int orbnumber)
    {
        string orbName;
        switch (orbnumber)
        {
            case 1:
                orbName = "KILL ORB";
                break;
            case 2:
                orbName = "DOUBLE SCORE ORB";
                break;
            case 3:
                orbName = "SHEILD ORB";
                break;
            default: orbName = "";
                break;
        }
        orbText.text = orbName;
        orbText.gameObject.SetActive(true);
    }

  

    public void OrbActivated(bool state)
    {
        orbText.gameObject.SetActive(state);
        activatedUi.gameObject.SetActive(state);
    }


}
