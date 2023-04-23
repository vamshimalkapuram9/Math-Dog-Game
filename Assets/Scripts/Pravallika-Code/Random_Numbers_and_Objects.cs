using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Random_Numbers_and_Objects : MonoBehaviour
{
    public Text num1;
    public Text num2;

    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    public Button nextButton; // button to go to next problem

    public Sprite ObjectSprite1;
    public Sprite ObjectSprite2;
    public Sprite ObjectSprite3;
    public Sprite ObjectSprite4;
    public Sprite ObjectSprite5;
    public Sprite ObjectSprite6;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;
    public GameObject Object6;
    public GameObject Object7;
    public GameObject Object8;
    public GameObject Object9;
    public GameObject Object10;
    public GameObject RandomAddGameObjects; // parent of all the game objects for this game

    // Green Board and Objects List Declaration
    List<GameObject> transparentObjects;
    Image panelImage;

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne;
    int answerTwo;
    int answerThree;
    public int correctAnswer;

    public GameObject Ans1;
    public GameObject Ans2;
    public GameObject Ans3;

    Vector2 objectInitPos1;
    Vector2 objectInitPos2;
    Vector2 objectInitPos3;
    UnityEngine.Vector3 originalRotation1;

    public void Start()
    {
        nextButton.gameObject.SetActive(false);
        objectInitPos1 = Ans1.transform.position;
        objectInitPos2 = Ans2.transform.position;
        objectInitPos3 = Ans3.transform.position;
        DisplayMathProblem();
    }


    void setObjectTags()
    {
        // Initialise @param transparent Objects

        transparentObjects = new List<GameObject>();

        
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_1));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_2));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_3));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_4));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_5));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_6));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_7));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_8));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_9));
        transparentObjects.Add(GameObject.FindWithTag(Tags.FUN_OBJECT_10));


       
    }

    private (int, int) GetTwoRandomDiff() // Return tuple of two random numbers
    {
        int firstNum = UnityEngine.Random.Range(1, 11); // Random integer between 1 and 11
        int nextNum = UnityEngine.Random.Range(1, firstNum); // Ensure second number is not greater than first one

        if (nextNum > firstNum)
        {
            int temp = firstNum;
            firstNum = nextNum;
            nextNum = temp;
        }

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

    public void updateObjectSprites()
    {
        int objNum = UnityEngine.Random.Range(1, 7); // randomly select sprite 
        Sprite newSprite = ObjectSprite1;
        if (objNum == 1)
        {
            newSprite = ObjectSprite1;
        }
        else if (objNum == 2)
        {
            newSprite = ObjectSprite2;
        }
        else if (objNum == 3)
        {
            newSprite = ObjectSprite3;
        }
        else if (objNum == 4)
        {
            newSprite = ObjectSprite4;
        }
        else if (objNum == 5)
        {
            newSprite = ObjectSprite5;
        }
        else if (objNum == 6)
        {
            newSprite = ObjectSprite6;
        }
        // panel objects
        if (randomFirstNumber == 1)
        {

            displaySprite(Object1, randomFirstNumber, newSprite);

        }
        else if (randomFirstNumber == 2)
        {
            displaySprite(Object2, randomFirstNumber, newSprite);

        }
        else if (randomFirstNumber == 3)
        {
            displaySprite(Object3, randomFirstNumber, newSprite);

        }
        else if (randomFirstNumber == 4)
        {
            displaySprite(Object4, randomFirstNumber, newSprite);
        }
        else if (randomFirstNumber == 5)
        {
            displaySprite(Object5, randomFirstNumber, newSprite);
}
        else if (randomFirstNumber == 6)
        {
            displaySprite(Object6, randomFirstNumber,newSprite);
}
        else if (randomFirstNumber == 7)
        {
            displaySprite(Object7, randomFirstNumber, newSprite);

}
        else if (randomFirstNumber == 8)
        {
            displaySprite(Object8, randomFirstNumber, newSprite);

}
        else if (randomFirstNumber == 9)
        {
            displaySprite(Object9, randomFirstNumber, newSprite);
}
        else if (randomFirstNumber == 10)
        {
            displaySprite(Object10, randomFirstNumber, newSprite);
        }
    }

     void displaySprite(GameObject gameObject, int randomFirstNumber,Sprite tSprite)
    {
        
        for(int i =0; i < randomFirstNumber; i++)
        {
            GameObject obj = gameObject.transform.GetChild(i).gameObject;
            obj.GetComponentInChildren<Image>().sprite = tSprite;
        }

        //GameObject obj1 = gameObject.transform.GetChild(0).gameObject;
        //GameObject obj2 = gameObject.transform.GetChild(1).gameObject;
        //GameObject obj3 = gameObject.transform.GetChild(2).gameObject;
        //GameObject obj4 = gameObject.transform.GetChild(3).gameObject;
        //GameObject obj5 = gameObject.transform.GetChild(4).gameObject;
        //GameObject obj6 = gameObject.transform.GetChild(5).gameObject;
        //obj1.GetComponentInChildren<Image>().sprite = tSprite;
        //obj2.GetComponentInChildren<Image>().sprite = tSprite;
        //obj3.GetComponentInChildren<Image>().sprite = tSprite;
        //obj4.GetComponentInChildren<Image>().sprite = tSprite;
        //obj5.GetComponentInChildren<Image>().sprite = tSprite;
        //obj6.GetComponentInChildren<Image>().sprite = tSprite;
        gameObject.SetActive(true);
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
        updateObjectSprites();
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
        // now hide all objects
        Object1.SetActive(false);
        Object2.SetActive(false);
        Object3.SetActive(false);
        Object4.SetActive(false);
        Object5.SetActive(false);
        Object6.SetActive(false);
        Object7.SetActive(false);
        Object8.SetActive(false);
        Object9.SetActive(false);
        Object10.SetActive(false);
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

    /**
     *  =======================================
     *      Code for Panel Transparency
     *  =======================================
     **/

    void changePanelTransparency(GameObject currentPanel)
    {
        //Generating Transparency
        panelImage = currentPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 0.3f;

        panelImage.color = panelColor;

    }

    public void resetTransparency(GameObject currentPanel)
    {
        //Generating Transparency
        panelImage = currentPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 0f;

        panelImage.color = panelColor;

    }
}
