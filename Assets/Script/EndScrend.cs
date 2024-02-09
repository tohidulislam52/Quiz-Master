using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScrend : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FinalScore;
    Score score;
   
    void Awake()
    {
        score = FindObjectOfType<Score>();
    }

    public void ShowScore()
    {
        FinalScore.text = "Congratulatons \n You score:" 
                                    + score.CalculateScore() + "%";
    }
}
