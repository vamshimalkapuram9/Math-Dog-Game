using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathPuzzle : MonoBehaviour
{
    public Text num1;
    public Text num2;
    public Text Ans1;

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne;
    public int currentAnswer;
    // Start is called before the first frame update
    void Start()
    {
        DisplayMathProblem();
    }
    private (int, int) GetTwoRandomDiff() // Return tuple of two random numbers
    {
        int firstNum = Random.Range(1, 10); // Random integer between 1 and 10
        int nextNum = Random.Range(1, firstNum); // Ensure the difference is not negative integer

        return (firstNum, nextNum);
    }
    private (int, int) GetDiffOptions(int firstNum, int nextNum) // Return 3 random options between 1 and 9, one of which is the correct difference
    {
        int answer = firstNum - nextNum;

        if (answer < 1 || answer > 10)
        {
            throw new System.Exception("GetDiffOptions received invalid values to perform difference");
        }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        possibilities.Remove(answer); // Ensure only one correct answer offered

        // Get first incorrect option
        int firstOptionIndex = Random.Range(0, possibilities.Count);
        int firstOption = possibilities[firstOptionIndex];

        // Ensure next incorrect option is different from the first one
        possibilities.Remove(firstOption);

        // Get next incorrect option
        int nextOptionIndex = Random.Range(0, possibilities.Count);
        int nextOption = possibilities[nextOptionIndex];

        // Shuffle options before returning them
        var options = new List<int>() { answer, firstOption, nextOption };
        int count = options.Count;
        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        return (options[0], options[1]);
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

        if (randomFirstNumber != randomSecondNumber)
        {
            num1.text = "" + randomFirstNumber;
            num2.text = "" + randomSecondNumber;
            Ans1.text = "" + answerOne;
        }
        // Set which option is the correct answer (counting from 0)
        currentAnswer = 0;
        if (answerOne == randomSub)
        {
            currentAnswer = 1;
        }

    }
}

