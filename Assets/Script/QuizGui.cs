using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizGui : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI QuestionText;
    [SerializeField] List<Question> questions = new List<Question>();

    Question CarentQuestion;
    
    [Header("Answer")]
    [SerializeField] GameObject[] AnswerButton;
    bool HasAnswer;
    int carectanswer;
    [Header("Sprite")]
    [SerializeField] Sprite DefaultSprite;
    [SerializeField] Sprite carectSprite;


    [Header("Timer")]
    [SerializeField] Image TimerImage;
    Timer timer;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreText;
    Score ScoreCode;

    [Header("slider")]
    [SerializeField] Slider sliderBer;
    public bool GameFinis;

    

    bool Error =false ;

    
    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        ScoreCode =FindObjectOfType<Score>();
        sliderBer.maxValue = questions.Count;
        sliderBer.value = 0;
    }

    void Update() 
    {
        TimerImage.fillAmount= timer.FillAmound;
        if(timer.loadNextQuestion)
        {
             if(sliderBer.value == sliderBer.maxValue)
            {
                GameFinis = true;
            }
            GetNextQuestion();
            timer.loadNextQuestion = false;
            HasAnswer = false;
        }
        else if(!HasAnswer && !timer.isAnswerinQuestion)
        {
            // GetAnswerSelected(1);
            if(Error)
            {
            GetAnswerSelected(-1);
            }
            HasAnswer =true;
            ButtonState(false);
        }
        
    }
    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            RandomeQuestion();
            DisplayQuestion();
            DefaultSpriteMathod();
            ButtonState(true);
            ScoreCode.InCarectQuestion();
            sliderBer.value++;
        }
    }

    void RandomeQuestion()
    {
        int index = Random.Range(0,questions.Count);
        CarentQuestion = questions[index];
        if(questions.Contains(CarentQuestion))
        {
            questions.Remove(CarentQuestion); 
        }
        Error =true;
    }
    void DisplayQuestion()
    {
        QuestionText.text = CarentQuestion.getQuestion();
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            TextMeshProUGUI button =
            AnswerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            button.text = CarentQuestion.GetAnswers(i);
            
        }
    }
    public void OnAnswerSelected(int index)
    {
        GetAnswerSelected(index);
        ButtonState(false);
        timer.CancelTimer();
        HasAnswer = true;
        ScoreText.text = "Score:" + ScoreCode.CalculateScore()+"%";
        
    }

    void GetAnswerSelected( int indexx)
    {
        if (indexx == CarentQuestion.GetCarectAnswer())
        {
            QuestionText.text = "Correct!!";
            Image buttonImage = AnswerButton[indexx].GetComponent<Image>();
            buttonImage.sprite = carectSprite;
            ScoreCode.InCarectAnswer();
            // buttonImage.color= Color.black;
        }
        else
        {
            carectanswer = CarentQuestion.GetCarectAnswer();
            string carectAnswerString = CarentQuestion.GetAnswers(carectanswer);
            QuestionText.text = "Sorry, the correct answer was;\n" + carectAnswerString;
            Image buttonImage = AnswerButton[carectanswer].GetComponent<Image>();
            buttonImage.sprite = carectSprite;
        }
    }

    void ButtonState(bool state)
    {
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            Button button = AnswerButton[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void DefaultSpriteMathod()
    {
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            Image buttonimage=AnswerButton[i].GetComponent<Image>();
            buttonimage.sprite =DefaultSprite;
        }
    }
}
