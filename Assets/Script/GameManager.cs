using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    QuizGui quizGui;
    EndScrend endScrend;
     void Awake() 
    {
       quizGui = FindObjectOfType<QuizGui>();
       endScrend = FindObjectOfType<EndScrend>(); 
    }
    void Start()
    {
        quizGui.gameObject.SetActive(true);
        endScrend.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(quizGui.GameFinis)
        {
            quizGui.gameObject.SetActive(false);
            endScrend.gameObject.SetActive(true);
            endScrend.ShowScore();
        }
    }

    public void PalyAgain()
    {
        // SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
