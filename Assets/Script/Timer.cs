using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float AnswerCompiletTimer= 30f;
    [SerializeField] float AnswerShowTimer = 30f;
    float timerValu;
    public bool isAnswerinQuestion= false;
    public float FillAmound;
    public bool loadNextQuestion;
    // Image TimerImage;
    
    //  void Start() 
    // {
    //    TimerImage = GetComponent<Image>(); 
    // }

    void Update()
    {
        // TimerImage.fillAmount = FillAmound;
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timerValu =0;
    }

    void UpdateTimer()
    {
        timerValu -= Time.deltaTime;
        if (isAnswerinQuestion)
        {
            if (timerValu > 0)
            {
                FillAmound = timerValu / AnswerCompiletTimer;
            }
            else
            {
                timerValu = AnswerShowTimer;
                isAnswerinQuestion = false;
            }
        }
        else
        {
            if (timerValu > 0)
            {
                FillAmound = timerValu / AnswerShowTimer;
            }
            else
            {
                timerValu = AnswerCompiletTimer;
                isAnswerinQuestion = true;
                loadNextQuestion = true;
            }
        }
        // Debug.Log(isAnswerinQuestion + ":" + timerValu + '=' + FillAmound);
    }
}
