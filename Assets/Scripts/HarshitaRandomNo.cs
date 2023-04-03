using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarshitaRandomNo : MonoBehaviour
{
    public Text num1;
    public Text num2;
    public Text Ans1;
    public Text num3;
    public Text num4;
    public Text Ans2;
    //public Text equal;
    //public Text minus;

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne, answerTwo, answerThree;
    //int answerTwo, answerThree, answerFour, answerFive;
    public int currentAnswer;
    // Start is called before the first frame update
    void Start()
    {
        DisplayMathProblem();
    }
    private (int, int) GetTwoRandomDiff() // Return tuple of two random numbers
    {
        int firstNum = Random.Range(1, 10); // Random integer between 1 and 10
        int nextNum = Random.Range(1, 10); // Ensure the difference is not negative integer

        if (nextNum > firstNum)
        {
            int temp = firstNum;
            firstNum = nextNum;
            nextNum = temp;
        }

        return (firstNum, nextNum);
    }
    private (int, int, int) GetDiffOptions(int firstNum, int nextNum)
    {
        int answer = firstNum - nextNum;
        //char minus1= '-', equal1 = '=';

     //   if (answer < 1 || answer > 10)
       // {
         //   throw new System.Exception("GetDiffOptions received invalid values to perform difference");
        // }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //var another = new List<char>() { '-', '=' };
        possibilities.Remove(answer); // Ensure only one correct answer offered


        //int firstOptionIndex = Random.Range(0, possibilities.Count);
        int firstOption = firstNum;
        //int nextOptionIndex = Random.Range(0, possibilities.Count);
        int nextOption = nextNum;

        // Shuffle options before returning them
        var options = new List<int>() { answer, firstOption, nextOption };
        //var charoptions = new List<char>() {minus1, equal1 };
        int count = options.Count;


        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        //for (int j = 0; j < 2; ++j){
        //int rand = Random.Range(j, count);
        //char tmp = charoptions[j];
        //charoptions[j] = charoptions[rand];
        //charoptions[rand] = tmp;
        //}

        return (options[0], options[1], options[2]);
        // return(charoptions[3], charoptions[4]);
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
        //answerFour = options.Item4;
        //answerFive = options.Item5;

        num1.text = "" + randomFirstNumber;
        num2.text = "" + randomSecondNumber;
        Ans1.text = "" + randomSub;
        num3.text = "" + answerOne;
        num4.text = "" + answerTwo;
        Ans2.text = "" + answerThree;
        //Ans2.text = "" + answerThree;
        //equal.text = "" + answerFour;
        //minus.text = "" + answerFive; 

    }
}

