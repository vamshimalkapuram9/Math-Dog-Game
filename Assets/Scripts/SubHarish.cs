using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubHarish : MonoBehaviour
{

    public TextMeshProUGUI[] firstRandomNumbers;
    public TextMeshProUGUI[] secondRandomNumbers;



    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomNumbers();
    }

    public void GenerateRandomNumbers()
    {
        int[] firstNosList = new int[6];

        int randomNumber;

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

        }
    }

}
