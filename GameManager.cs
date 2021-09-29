
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

    [SerializeField]
    private Text factText;
    
    

    [SerializeField]
    public GameObject TruePanel;
    [SerializeField]
    public GameObject FalsePanel;

    public GameObject TrueButton;
    public GameObject FalseButton;
    public GameObject noClickButton;

    [SerializeField]
    private float timeBetweenQuestions = 1f;
    [SerializeField]
    public int pointsAddedForCorrectAnswer;
    public int pointsAddedForWrongAnswer;
    public Text scoreDisplayText;
    private int playerScore;
    void Start()
    {

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrenQuestion();

    }
    void SetCurrenQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text=currentQuestion.fact;

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void UserSelectTrue()
    {
       //animator.SetTrigger("True"); 
        if (currentQuestion.isTrue)
        {
           
            playerScore += pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "SKOR: " + playerScore.ToString();
            ScoreScript.scoreValue += 10;
            TruePanel.SetActive(true);
            noClickButton.SetActive(true);


        }
        else
        {
            playerScore -= pointsAddedForWrongAnswer;
            scoreDisplayText.text = "SKOR: " + playerScore.ToString();
            ScoreScript.scoreValue -= 5;
            FalsePanel.SetActive(true);
            noClickButton.SetActive(true);


        }

        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectFalse()
    {
       //animator.SetTrigger("False"); 
        if (!currentQuestion.isTrue)
        {
            ScoreScript.scoreValue += 10;
            playerScore += pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "SKOR: " + playerScore.ToString();
            TruePanel.SetActive(true);
            noClickButton.SetActive(true);
            
        }
        else
        {
            playerScore -= pointsAddedForWrongAnswer;
            scoreDisplayText.text = "SKOR: " + playerScore.ToString();
            ScoreScript.scoreValue -= 5;
            FalsePanel.SetActive(true);
            noClickButton.SetActive(true);

        }

        StartCoroutine(TransitionToNextQuestion());
    }
}