using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Advanced_BtnPractice : MonoBehaviour
{
    public TextMeshProUGUI[] firstRandomNumbers;
    void Start()
    {
        GenerateRandomNumbers();
    }
    public void GenerateRandomNumbers()
    {
        int[] firstNosList = new int[7];
        //int[] secondNosList = new int[6];
        int randomNumber;
        int[] correstAnswersList = new int[7];
        for (int i =0; i < 7; i ++)
        {
            randomNumber = Random.Range(0, 7);
            firstRandomNumbers[i].text = randomNumber.ToString();
            firstNosList[i] = randomNumber;
        }
    }
    
}