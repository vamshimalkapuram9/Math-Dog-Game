using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SubAdvHarish : MonoBehaviour
{

    static int count = 0;
    List<TextMeshProUGUI> firstRandomNumbers;
    List<TextMeshProUGUI> secondRandomNumbers;
    List<TextMeshProUGUI> AnswerPanelTexts;
    public List<GameObject> RandomPanels;

    List<Text> answerTexts;

    public int[] finalAnswers;

    public int panelCount = 0;

    public int[] correctAnswersList;

    public Button nextBtn;

    //Initialise an Answer Panel Queue
    List<GameObject> panelsList;
    public List<GameObject> answerPanelsList;



    //Answer Buttons Panel
    GameObject buttonsPanel;

    //Green Board Panel
    GameObject greenBoardPanel;

    /// ============================
    /// Panel Selection Code
    /// ============================
    public List<SinglePanel> singlePanels;



    // Start is called before the first frame update
    void Start()
    {
        initPanelsAndVariables();
        Debug.Log("Sub Harish Start Called");
        finalAnswers = GenerateRandomNumbers();

    }

    //Function to get correct AnswersList
    public int[] getCorrectAnswersList()
    {
        return correctAnswersList;
    }

    //Here is the function to generate the Answer Panels Queue
    void initPanelsAndVariables()
    {
        singlePanels = new List<SinglePanel>();
        panelsList = new List<GameObject>();
        answerPanelsList = new List<GameObject>();

        RandomPanels = new List<GameObject>();

        getPanels();


        // Initialise @param firstRandomNumbers
        firstRandomNumbers = new List<TextMeshProUGUI>();

        //Intialise @param secondRandomNumbers
        secondRandomNumbers = new List<TextMeshProUGUI>();

        //Intialise @param AnswerPanelTexts
        AnswerPanelTexts = new List<TextMeshProUGUI>();

        getFirstandSecondTMPList();
        getAnswerPanelTexts();


        /**
         * Answer Buttons Panel
         */
        buttonsPanel = GameObject.FindWithTag("AnswerButtonsPanel");

        //Initialise the Answers Texts List
        answerTexts = new List<Text>();

        //Transform component of the panel game object
        Transform panelTransform = buttonsPanel.GetComponent<Transform>();

        //Loop through all the children of the panel

        for (int i = 0; i < panelTransform.childCount; i++)
        {
            Transform childTransform = panelTransform.GetChild(i);

            //Convert the child Transform into Button
            Button currentAnsButton = childTransform.GetComponent<Button>();

            Text currentAnsText = currentAnsButton.GetComponentInChildren<Text>();

            answerTexts.Add(currentAnsText);
        }

        // Connect the Board to Tag

        greenBoardPanel = GameObject.FindGameObjectWithTag(Tags.GREEN_BOARD_PANEL);



    }




    /**
     * Since Panels Get Dequeued we need to call them again in the animation function
     */

    void getPanels()
    {

        panelCount = 0;
        panelsList.Add(GameObject.FindWithTag(Tags.FIRST_PANEL));
        panelsList.Add(GameObject.FindWithTag(Tags.SECOND_PANEL));
        panelsList.Add(GameObject.FindWithTag(Tags.THIRD_PANEL));
        panelsList.Add(GameObject.FindWithTag(Tags.FOURTH_PANEL));
        panelsList.Add(GameObject.FindWithTag(Tags.FIFTH_PANEL));
        panelsList.Add(GameObject.FindWithTag(Tags.SIXTH_PANEL));

        addAnswersPanels();


    }

    


    void addAnswersPanels()
    {
        GameObject tempPanel = new();

        foreach (GameObject panel in panelsList)
        {

            tempPanel = panel.transform.GetChild(4).gameObject;
            answerPanelsList.Add(tempPanel);

        }
    }

    public List<GameObject> getAnswerPanels()
    {
        return answerPanelsList;
    }



    void resetTIAText(List<GameObject> panelsList)
    {
        foreach (GameObject panel in panelsList)
        {
            GameObject answerPanelObject = panel.transform.GetChild(4).gameObject;


            //TIA Code
            Transform TIATransform = answerPanelObject.transform.GetChild(0);
            TextMeshProUGUI TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
            TextInAnswerPanel.text = "?";
        }
    }






    void getFirstandSecondTMPList()
    {
        foreach (GameObject panel in panelsList)
        {
            GameObject firstPanelObject = panel.transform.GetChild(0).gameObject;

            Transform leftSideNumber = firstPanelObject.transform.GetChild(0);

            //Get the TMP Text from the currentChild
            TextMeshProUGUI firstNumberTMP = leftSideNumber.GetComponent<TextMeshProUGUI>();

            //Add it to our @param firstRandomNumbers
            firstRandomNumbers.Add(firstNumberTMP);


            GameObject secondPanelObject = panel.transform.GetChild(2).gameObject;
            //Now let's focus on the right side Numbers
            Transform rightSideNumber = secondPanelObject.transform.GetChild(0);

            //Get the TMP Text from the currentChild
            TextMeshProUGUI secondNumberTMP = rightSideNumber.GetComponent<TextMeshProUGUI>();

            //Add the @param secondNumberTMP to @param secondRandomNumbers
            secondRandomNumbers.Add(secondNumberTMP);


        }

    }

    void getAnswerPanelTexts() {
        foreach (GameObject panel in panelsList)
        {
            GameObject answerPanelObject = panel.transform.GetChild(4).gameObject;


            //TIA Code
            Transform TIATransform = answerPanelObject.transform.GetChild(0);
            TextMeshProUGUI TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
            AnswerPanelTexts.Add(TextInAnswerPanel);
        }

    }

    public void callNewAnswerButtons(int index)
    {
        List<int> ansList = correctAnswersList.ToList();

        ansList.RemoveAt(index);

        int[] currentAnsArray = ansList.ToArray();

        GenerateAnswerButtons(currentAnsArray);
    }



    public int[] GenerateRandomNumbers()
    {
        ////First Initialise the panels and Variables
        //initPanelsAndVariables();

        int[] firstNosList = new int[6];
        int[] secondNosList = new int[6];
        int randomNumber;

        correctAnswersList = new int[6];

        for (int i = 0; i < 6; i++)
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
            AnswerPanelTexts[i].text = (firstNosList[i] - secondNosList[i]).ToString();
           
        }

        //Create Random Placements for the texts and rememeber them

        GameObject rndPnlObject;

        for(int i = 0; i < 6; i++)
        {
            randomNumber = Random.Range(1, 4);

            switch(randomNumber)
            { 
                case 1: correctAnswersList[i] = firstNosList[i];
                    firstRandomNumbers[i].text = "?";
                    rndPnlObject = panelsList[i].transform.GetChild(0).gameObject;
                    RandomPanels.Add(rndPnlObject);
                    break;

                case 2: correctAnswersList[i] = secondNosList[i];
                    secondRandomNumbers[i].text = "?";
                    rndPnlObject = panelsList[i].transform.GetChild(2).gameObject;
                    RandomPanels.Add(rndPnlObject);
                    break;

                case 3: correctAnswersList[i] = firstNosList[i] - secondNosList[i];
                    AnswerPanelTexts[i].text = "?";
                    rndPnlObject = panelsList[i].transform.GetChild(4).gameObject;
                    RandomPanels.Add(rndPnlObject);
                    break;


            }

        }



        GenerateAnswerButtons(correctAnswersList);




        return correctAnswersList;

    }







    public void GenerateAnswerButtons(int[] buttonAnswersList)
    {
        int[] answerChoices = new int[7];

        int randomValue = Random.Range(1, 10);

        for (int i = 0; i < buttonAnswersList.Length; i++)
        {
            answerChoices[i] = buttonAnswersList[i];
        }




        for (int i = buttonAnswersList.Length; i < 7; i++)
        {
            while (answerChoices.Contains(randomValue))
            {
                randomValue = Random.Range(1, 10);
            }
            answerChoices[i] = randomValue;

        }




        Debug.Log("First Answers List: " + string.Join(", ", answerChoices));
        //Shuffle The array;

        RandomExtensions.Shuffle<int[]>(answerChoices);
        Debug.Log("Randomised Answers List: " + string.Join(", ", answerChoices));


        for (int i = 0; i < 7; i++)
        {
            answerTexts[i].text = answerChoices[i].ToString();
        }


    }


    /**
     *==================================================
     *          Code For After Clicking the Next Btn
     *=====================================================
     */

    public void callNextBtn()
    {
        nextBtn.gameObject.SetActive(true);
    }


    private void resetPanelsAndButtons()
    {



        firstRandomNumbers.Clear();
        secondRandomNumbers.Clear();

    }


    public void RefreshPuzzle()
    {
        count++;
        if (count % 2 == 0)
        {
            SceneManager.LoadScene("PracticeConfetti");
            Debug.Log("Confetti loading");
            count = 0;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        //Start NewBoard Couroutine

        StartCoroutine(newBoardAnimation());
    }

    private IEnumerator newBoardAnimation()
    {

        Debug.Log(greenBoardPanel.tag);

        Vector2 originalPos = greenBoardPanel.transform.position;

        Vector2 leftOffScreen = originalPos + new Vector2(-1 * Screen.width, 0);
        Vector2 rightOffScreen = originalPos + new Vector2(Screen.width, 0);

        float elapsedTime = 0;
        int moveSpeed = 8;

        while (elapsedTime < 1)
        {
            greenBoardPanel.transform.position = Vector2.Lerp(greenBoardPanel.transform.position, leftOffScreen, Time.deltaTime * moveSpeed);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        greenBoardPanel.transform.position = rightOffScreen;

        /**
         * ================================================
         *              CODE TO RESTART THE BOARD
         */

        resetPanelsAndButtons();
        initPanelsAndVariables();
        finalAnswers = GenerateRandomNumbers();

        /**
         * ================================================
         */


        while (elapsedTime < 2)
        {
            greenBoardPanel.transform.position = Vector2.Lerp(greenBoardPanel.transform.position, originalPos, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;

            yield return null;
        }



        greenBoardPanel.transform.position = originalPos;

        yield return null;


    }
}






