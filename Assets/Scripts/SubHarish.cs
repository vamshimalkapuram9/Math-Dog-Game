using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubHarish : MonoBehaviour
{

    public TextMeshProUGUI[] firstRandomNumbers;
    public TextMeshProUGUI[] secondRandomNumbers;

    public Text[] answerTexts;

    public int[] finalAnswers;

    
    //Initialise an Answer Panel Queue
    Queue<GameObject> panelsQueue;

    //This is the panel that is being answered at the moment
    GameObject presentlyActivePanel;

    //I have added this in order to change the Alpha of the @param presentlyActivePanel
    Image panelImage;


    // Start is called before the first frame update
    void Start()
    {
        finalAnswers = GenerateRandomNumbers();
        initPanelsAndVariables();
    }

    //Here is the function to generate the Answer Panels Queue
    void initPanelsAndVariables()
    {
        

        panelsQueue = new Queue<GameObject>();


        panelsQueue.Enqueue(GameObject.FindWithTag("FirstPanel"));
        panelsQueue.Enqueue(GameObject.FindWithTag("SecondPanel"));
        panelsQueue.Enqueue(GameObject.FindWithTag("ThirdPanel"));
        panelsQueue.Enqueue(GameObject.FindWithTag("FourthPanel"));
        panelsQueue.Enqueue(GameObject.FindWithTag("FifthPanel"));
        panelsQueue.Enqueue(GameObject.FindWithTag("SixthPanel"));


        presentlyActivePanel = panelsQueue.Dequeue();


        changePanelTransparency(presentlyActivePanel);


        //Transform firstChild = PresentlyActivePanel.transform.GetChild(0);

        //TextMeshProUGUI firstText = firstChild.GetComponent<TextMeshProUGUI>();

        //Debug.Log(firstText.text);
        ////Debug.Log(PresentlyActivePanel.transform.childCount);


    }


    void changePanelTransparency(GameObject currentPanel)
    {
        //Generating Transparency
        panelImage = currentPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 0.3f;

        panelImage.color = panelColor;

    }





    public int[] GenerateRandomNumbers()
    {
        int[] firstNosList = new int[6];
        int[] secondNosList = new int[6];
        int randomNumber;

        int[] correctAnswersList = new int[6];

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
            correctAnswersList[i] = firstNosList[i] - secondNosList[i];
        }

        GenerateAnswerButtons(correctAnswersList[0]);

        return correctAnswersList;
        
    }





    public void GenerateAnswerButtons(int correctAnswer)
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

            randomAnswer = Random.Range(1, 10);

            while (randomAnswer == correctAnswer || answerChoices.Contains(randomAnswer))
            {
                randomAnswer = Random.Range(1, 10);
            }

            answerChoices[i] = randomAnswer;

        }

        for (int i = 0; i < 7; i++)
        {
            answerTexts[i].text = answerChoices[i].ToString();
        }


    }



}
