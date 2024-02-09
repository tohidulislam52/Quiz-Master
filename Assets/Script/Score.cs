using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
   int carectAnswer =0;
   int carectQuestion = 0;

   public void InCarectAnswer()
   {
    carectAnswer++;
   }
   public void InCarectQuestion()
   {
    carectQuestion++;
   }


   public int CalculateScore()
    {
        return Mathf.RoundToInt( (float)carectAnswer / (float)carectQuestion * 100);
     
    }



}
