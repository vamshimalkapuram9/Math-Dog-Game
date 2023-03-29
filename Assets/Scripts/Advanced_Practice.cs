using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Advanced_Practice : MonoBehaviour
{
    public TextMeshProUGUI[] firstRandomNumbers;
    public TextMeshProUGUI[] secondRandomNumbers;
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
            randomNumber = Random.Range(2, 10);
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
    }
}