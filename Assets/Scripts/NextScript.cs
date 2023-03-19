using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NextScript : MonoBehaviour
{
    public Text num1;
    public Text num2;
    public Text ans1;
    public Text ans2;
    public Text ans3;
    public Button nextButton;
    public Button ansButton1;
    public Button ansButton2;
    public Button ansButton3;

    private Vector3 ansButton1Pos;
    private Vector3 ansButton2Pos;
    private Vector3 ansButton3Pos;
    private int correctAns;

    // Start is called before the first frame update
    void Start()
    {
        ansButton1Pos = ansButton1.GetComponent<RectTransform>().anchoredPosition;
        ansButton2Pos = ansButton2.GetComponent<RectTransform>().anchoredPosition;
        ansButton3Pos = ansButton3.GetComponent<RectTransform>().anchoredPosition;

        // Disable the next button initially
        nextButton.gameObject.SetActive(false);

        GenerateQuestion();

        // Add listeners to the answer buttons
        ansButton1.onClick.AddListener(CheckAnswer);
        ansButton2.onClick.AddListener(CheckAnswer);
        ansButton3.onClick.AddListener(CheckAnswer);

        // Add a listener to the next button
        nextButton.onClick.AddListener(NextQuestion);
    }

    void GenerateQuestion()
    {
        // Set the text of the question
        int n1 = Random.Range(1, 10);
        int n2 = Random.Range(0, n1);
        int op = Random.Range(0, 3);
        correctAns = n1 - n2;
        num1.text = n1.ToString();
        num2.text = n2.ToString();

        // Set the text of the answer options
        if (op == 0)
        {
            ans1.text = correctAns.ToString();
            ans2.text = (correctAns + Random.Range(1, 5)).ToString();
            ans3.text = (correctAns - Random.Range(1, 5)).ToString();
        }
        else if (op == 1)
        {
            ans2.text = correctAns.ToString();
            ans1.text = (correctAns + Random.Range(1, 5)).ToString();
            ans3.text = (correctAns - Random.Range(1, 5)).ToString();
        }
        else
        {
            ans3.text = correctAns.ToString();
            ans1.text = (correctAns + Random.Range(1, 5)).ToString();
            ans2.text = (correctAns - Random.Range(1, 5)).ToString();
        }

        // Reset the positions of the answer buttons
        ResetButtonPositions();

        // Disable the next button
        nextButton.gameObject.SetActive(false);
    }

    void ResetButtonPositions()
    {
        ansButton1.GetComponent<RectTransform>().anchoredPosition = ansButton1Pos;
        ansButton2.GetComponent<RectTransform>().anchoredPosition = ansButton2Pos;
        ansButton3.GetComponent<RectTransform>().anchoredPosition = ansButton3Pos;
    }

    void NextQuestion()
    {
        StartCoroutine(GenerateNextQuestionWithDelay(1f));
    }

    IEnumerator GenerateNextQuestionWithDelay(float delayTime)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayTime);

        // Generate the next question
        GenerateQuestion();
    }

    public void CheckAnswer()
    {
        if (isCorrectAnswer())
        {
            // Enable the next button if the selected answer is correct
            nextButton.gameObject.SetActive(true);


        }
    }

    bool isCorrectAnswer()
    {
        int answer = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        return answer == correctAns;
    }
}


