using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Random_number : MonoBehaviour
{
    public List<int> easyMathList = new List<int>();

    //private int easyLevelLimit = 10;
    //private int mediumLevelLimit = 25;
    //private int hardLevelLimit = 99;

    public int randomFirstNumber;
    public int randomSecondNumber;

    public (int, int) GetTwoRandomNumbers(int numberLimit)
    {
        int firstNum = Random.Range(1, numberLimit); // Random integer between 1 and 10
        int nextNum = Random.Range(1, firstNum); // Ensure the difference is not negative integer

        return (firstNum, nextNum);
    }




}
