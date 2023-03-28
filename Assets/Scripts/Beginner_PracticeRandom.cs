using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Beginner_PracticeRandom : MonoBehaviour
{
    public TextMeshProUGUI[] firstRandomNumbers;
    public TextMeshProUGUI[] secondRandomNumbers;
    //public Text[] answerTexts;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomNumbers();
    }
    public void GenerateRandomNumbers()
    {
        int[] firstNosList = new int[6];
        int[] secondNosList = new int[6];
        int randomNumber;
        int[] correstAnswersList = new int[6];
        for (int i =0; i < 6; i ++)
        {
            randomNumber = Random.Range(2, 5);
            firstRandomNumbers[i].text = randomNumber.ToString();
            firstNosList[i] = randomNumber;
        }
        for (int i = 0; i < 6; i++)
        {
            randomNumber = Random.Range(1, firstNosList[i]);
            secondRandomNumbers[i].text = randomNumber.ToString();
            secondNosList[i] = randomNumber;
        }
        for (int i = 0; i < 6; i++)
        {
            correstAnswersList[i] = firstNosList[i] - secondNosList[i];
        }
        //GenerateAnswers(correstAnswersList[0]);   
    }
    /*public void GenerateAnswers(int correctAnswer)
    {
        int[] answerChoices = new int[7];
        int randomPlace = Random.Range(1, 7);
        answerChoices[randomPlace] = correctAnswer;
        int randomAnswer;
        for (int i = 0; i < 7; i++)
        {
            if(i == randomPlace)
            {
                continue;
            }
            //Ensure that the new random number isn't repeted and isn't the correct answer
            randomAnswer = Random.Range(1, 5);
            while (randomAnswer == correctAnswer || answerChoices.Contains(randomAnswer))
            {
                randomAnswer = Random.Range(1, 5);
            }
            answerChoices[i] = randomAnswer;
        }
        for (int i = 0; i < 7; i++)
        {
            answerTexts[i].text = answerChoices[i].ToString();
        }
    }*/
}