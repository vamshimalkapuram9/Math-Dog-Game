using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MathSubRandom : MonoBehaviour
{
    public Text num1;
    public Text num2;

    public Text Answer1;
    public Text Answer2;
    public Text Answer3;
    public Button nextButton; // button to go to next problem


   

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne;
    int answerTwo;
    int answerThree;
    public int correctAnswer;

    public GameObject Answer1;
    public GameObject Answer2;
    public GameObject Answer3;

    Vector2 objectInitPos1;
    Vector2 objectInitPos2;
    Vector2 objectInitPos3;
    UnityEngine.Vector3 originalRotation1;

    public void Start()
    {
        nextButton.gameObject.SetActive(false);
        objectInitPos1 = Answer1.transform.position;
        objectInitPos2 = Answer2.transform.position;
        objectInitPos3 = Answer3.transform.position;
        DisplayMathProblem();
    }

    private (int, int) GetTwoRandomDiff() // Return tuple of two random numbers that sum to something between 2 and 5
    {
        int firstNum = UnityEngine.Random.Range(1, 11); // Random integer between 1 and 4
        int nextNum = UnityEngine.Random.Range(1, firstNum); // Ensure sum is no more than 5

        return (firstNum, nextNum);
    }
    private (int, int, int) GetDiffOptions(int firstNum, int nextNum) // Return 3 random options between 1 and 9, one of which is the correct difference
    {
        int answer = firstNum - nextNum;

        if (answer < 1 || answer > 10)
        {
            throw new System.Exception("GetDiffOptions received invalid values to perform difference");
        }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        possibilities.Remove(answer); // Ensure only one correct answer offered

        // Get first incorrect option
        int firstOptionIndex = UnityEngine.Random.Range(0, possibilities.Count);
        int firstOption = possibilities[firstOptionIndex];

        // Ensure next incorrect option is different from the first one
        possibilities.Remove(firstOption);

        // Get next incorrect option
        int nextOptionIndex = UnityEngine.Random.Range(0, possibilities.Count);
        int nextOption = possibilities[nextOptionIndex];

        // Shuffle options before returning them
        var options = new List<int>() { answer, firstOption, nextOption };
        int count = options.Count;
        for (int i = 0; i < count - 1; ++i)
        {
            int rand = UnityEngine.Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        return (options[0], options[1], options[2]);
    }

    
        

    public void DisplayMathProblem()
    {
        //generate a random number as the first and second numbers
        var nums = GetTwoRandomDiff();
        randomFirstNumber = nums.Item1;
        randomSecondNumber = nums.Item2;
        int randomSub = randomFirstNumber - randomSecondNumber;

        var options = GetDiffOptions(randomFirstNumber, randomSecondNumber);
        answerOne = options.Item1;
        answerTwo = options.Item2;
        answerThree = options.Item3;
        num1.text = "" + randomFirstNumber;
        num2.text = "" + randomSecondNumber;
        answer1Button.GetComponentInChildren<Text>().text = "" + answerOne;
        answer2Button.GetComponentInChildren<Text>().text = "" + answerTwo;
        answer3Button.GetComponentInChildren<Text>().text = "" + answerThree;
        // Set which option is the correct answer (counting from 0)
        correctAnswer = randomSub;
    }

    public void ButtonAnswer1()
    {
        bool isButton1Correct = answer1Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
        //showResults(isButton1Correct);
    }

    public void ButtonAnswer2()
    {
        bool isButton2Correct = answer2Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
        //showResults(isButton2Correct);
    }

    public void ButtonAnswer3()
    {
        bool isButton3Correct = answer3Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
        //showResults(isButton3Correct);
    }

    //public void showResults(bool isCorrectAnswer)
    //{
    //    if (isCorrectAnswer)
    //    {
    //        nextButton.gameObject.SetActive(true);
    //    }
    //}

    public void refreshPuzzle()
    {
        nextButton.gameObject.SetActive(false); // hide until another correct answer
        // animated transition
        StartCoroutine(NewProblem());

    }

    private IEnumerator NewProblem()
    {

        Ans1.transform.position = objectInitPos1;
        Ans2.transform.position = objectInitPos2;
        Ans3.transform.position = objectInitPos3;
        Vector3 originalPos = RandomAddGameObjects.transform.position;
        Vector3 leftOffScreen = originalPos + new Vector3(-1 * Screen.width, 0, 0);
        Vector3 rightOffScreen = originalPos + new Vector3(Screen.width, 0, 0);
        float elapsedTime = 0;
        int moveSpeed = 8;

        while (elapsedTime < 1)
        {
            RandomAddGameObjects.transform.position = Vector3.Lerp(RandomAddGameObjects.transform.position, leftOffScreen, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RandomAddGameObjects.transform.position = rightOffScreen;
        DisplayMathProblem();

        while (elapsedTime < 2)
        {
            RandomAddGameObjects.transform.position = Vector3.Lerp(RandomAddGameObjects.transform.position, originalPos, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RandomAddGameObjects.transform.position = originalPos; // ensure end at original position since Lerp is inexact


        yield return null;
    }
}
