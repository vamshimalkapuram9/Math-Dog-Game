//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class Hscript : MonoBehaviour
//{
//    public Text num1panel;
//    public Text num2panel;
//    public Text answer;
//    public Text minus;
//    public Text equals;

//    public Button NoOneButton;
//    public Button NoTwoButton;
//    public Button answerButton;
//    public Button minusButton;
//    public Button equalsButton;
//    public Button nextButton; // button to go to next problem


//    public void Start()
//    {
//        nextButton.gameObject.SetActive(false);
//        objectInitPos1 = NoOneButton.transform.position;
//        objectInitPos2 = NoTwoButton.transform.position;
//        objectInitPos3 = answerButton.transform.position;
//        objectInitPos4 = minusButton.transform.position;
//        objectInitPos5 = equalsButton.transform.position;
//        DisplayMathProblem();
//    }


//        // panel objects
//        if (randomFirstNumber == 1)
//        {
//            GameObject obj = Object1.transform.GetChild(0).gameObject;
//            obj.GetComponentInChildren<Image>().sprite = newSprite;
//            Object1.SetActive(true);
//        }
//        else if (randomFirstNumber == 2)
//        {
//            GameObject obj1 = Object2.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object2.transform.GetChild(1).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            Object2.SetActive(true);
//        }
//        else if (randomFirstNumber == 3)
//        {
//            GameObject obj1 = Object3.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object3.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object3.transform.GetChild(2).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            Object3.SetActive(true);
//        }
//        else if (randomFirstNumber == 4)
//        {
//            GameObject obj1 = Object4.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object4.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object4.transform.GetChild(2).gameObject;
//            GameObject obj4 = Object4.transform.GetChild(3).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            Object4.SetActive(true);
//        }
//        else if (randomFirstNumber == 5)
//        {
//            GameObject obj = Object5.transform.GetChild(0).gameObject;
//            GameObject obj1 = Object5.transform.GetChild(1).gameObject;
//            GameObject obj2 = Object5.transform.GetChild(2).gameObject;
//            GameObject obj3 = Object5.transform.GetChild(3).gameObject;
//            GameObject obj4 = Object5.transform.GetChild(4).gameObject;
//            obj.GetComponentInChildren<Image>().sprite = newSprite;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            Object5.SetActive(true);
//        }
//        else if (randomFirstNumber == 6)
//        {
//            GameObject obj1 = Object6.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object6.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object6.transform.GetChild(2).gameObject;
//            GameObject obj4 = Object6.transform.GetChild(3).gameObject;
//            GameObject obj5 = Object6.transform.GetChild(4).gameObject;
//            GameObject obj6 = Object6.transform.GetChild(5).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            obj5.GetComponentInChildren<Image>().sprite = newSprite;
//            obj6.GetComponentInChildren<Image>().sprite = newSprite;
//            Object6.SetActive(true);
//        }
//        else if (randomFirstNumber == 7)
//        {
//            GameObject obj1 = Object7.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object7.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object7.transform.GetChild(2).gameObject;
//            GameObject obj4 = Object7.transform.GetChild(3).gameObject;
//            GameObject obj5 = Object7.transform.GetChild(4).gameObject;
//            GameObject obj6 = Object7.transform.GetChild(5).gameObject;
//            GameObject obj7 = Object7.transform.GetChild(6).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            obj5.GetComponentInChildren<Image>().sprite = newSprite;
//            obj6.GetComponentInChildren<Image>().sprite = newSprite;
//            obj7.GetComponentInChildren<Image>().sprite = newSprite;
//            Object7.SetActive(true);
//        }
//        else if (randomFirstNumber == 8)
//        {
//            GameObject obj1 = Object8.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object8.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object8.transform.GetChild(2).gameObject;
//            GameObject obj4 = Object8.transform.GetChild(3).gameObject;
//            GameObject obj5 = Object8.transform.GetChild(4).gameObject;
//            GameObject obj6 = Object8.transform.GetChild(5).gameObject;
//            GameObject obj7 = Object8.transform.GetChild(6).gameObject;
//            GameObject obj8 = Object8.transform.GetChild(7).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            obj5.GetComponentInChildren<Image>().sprite = newSprite;
//            obj6.GetComponentInChildren<Image>().sprite = newSprite;
//            obj7.GetComponentInChildren<Image>().sprite = newSprite;
//            obj8.GetComponentInChildren<Image>().sprite = newSprite;
//            Object8.SetActive(true);
//        }
//        else if (randomFirstNumber == 9)
//        {
//            GameObject obj1 = Object9.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object9.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object9.transform.GetChild(2).gameObject;
//            GameObject obj4 = Object9.transform.GetChild(3).gameObject;
//            GameObject obj5 = Object9.transform.GetChild(4).gameObject;
//            GameObject obj6 = Object9.transform.GetChild(5).gameObject;
//            GameObject obj7 = Object9.transform.GetChild(6).gameObject;
//            GameObject obj8 = Object9.transform.GetChild(7).gameObject;
//            GameObject obj9 = Object9.transform.GetChild(8).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            obj5.GetComponentInChildren<Image>().sprite = newSprite;
//            obj6.GetComponentInChildren<Image>().sprite = newSprite;
//            obj7.GetComponentInChildren<Image>().sprite = newSprite;
//            obj8.GetComponentInChildren<Image>().sprite = newSprite;
//            obj9.GetComponentInChildren<Image>().sprite = newSprite;
//            Object9.SetActive(true);
//        }
//        else if (randomFirstNumber == 10)
//        {
//            GameObject obj1 = Object10.transform.GetChild(0).gameObject;
//            GameObject obj2 = Object10.transform.GetChild(1).gameObject;
//            GameObject obj3 = Object10.transform.GetChild(2).gameObject;
//            GameObject obj4 = Object10.transform.GetChild(3).gameObject;
//            GameObject obj5 = Object10.transform.GetChild(4).gameObject;
//            GameObject obj6 = Object10.transform.GetChild(5).gameObject;
//            GameObject obj7 = Object10.transform.GetChild(6).gameObject;
//            GameObject obj8 = Object10.transform.GetChild(7).gameObject;
//            GameObject obj9 = Object10.transform.GetChild(8).gameObject;
//            GameObject obj10 = Object10.transform.GetChild(9).gameObject;
//            obj1.GetComponentInChildren<Image>().sprite = newSprite;
//            obj2.GetComponentInChildren<Image>().sprite = newSprite;
//            obj3.GetComponentInChildren<Image>().sprite = newSprite;
//            obj4.GetComponentInChildren<Image>().sprite = newSprite;
//            obj5.GetComponentInChildren<Image>().sprite = newSprite;
//            obj6.GetComponentInChildren<Image>().sprite = newSprite;
//            obj7.GetComponentInChildren<Image>().sprite = newSprite;
//            obj8.GetComponentInChildren<Image>().sprite = newSprite;
//            obj9.GetComponentInChildren<Image>().sprite = newSprite;
//            obj10.GetComponentInChildren<Image>().sprite = newSprite;
//            Object10.SetActive(true);
//        }
//    }


//    public void ButtonAnswer1()
//    {
//        bool isButton1Correct = answer1Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
//        //showResults(isButton1Correct);
//    }

//    public void ButtonAnswer2()
//    {
//        bool isButton2Correct = answer2Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
//        //showResults(isButton2Correct);
//    }

//    public void ButtonAnswer3()
//    {
//        bool isButton3Correct = answer3Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
//        //showResults(isButton3Correct);
//    }

//    //public void showResults(bool isCorrectAnswer)
//    //{
//    //    if (isCorrectAnswer)
//    //    {
//    //        nextButton.gameObject.SetActive(true);
//    //    }
//    //}

//    public void refreshPuzzle()
//    {
//        nextButton.gameObject.SetActive(false); // hide until another correct answer
//        // now hide all objects
//        Object1.SetActive(false);
//        Object2.SetActive(false);
//        Object3.SetActive(false);
//        Object4.SetActive(false);
//        Object5.SetActive(false);
//        Object6.SetActive(false);
//        Object7.SetActive(false);
//        Object8.SetActive(false);
//        Object9.SetActive(false);
//        Object10.SetActive(false);
//        // animated transition
//        StartCoroutine(NewProblem());

//    }

//    private IEnumerator NewProblem()
//    {

//        Ans1.transform.position = objectInitPos1;
//        Ans2.transform.position = objectInitPos2;
//        Ans3.transform.position = objectInitPos3;
//        Vector3 originalPos = RandomAddGameObjects.transform.position;
//        Vector3 leftOffScreen = originalPos + new Vector3(-1 * Screen.width, 0, 0);
//        Vector3 rightOffScreen = originalPos + new Vector3(Screen.width, 0, 0);
//        float elapsedTime = 0;
//        int moveSpeed = 8;

//        while (elapsedTime < 1)
//        {
//            RandomAddGameObjects.transform.position = Vector3.Lerp(RandomAddGameObjects.transform.position, leftOffScreen, Time.deltaTime * moveSpeed);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        RandomAddGameObjects.transform.position = rightOffScreen;
//        DisplayMathProblem();

//        while (elapsedTime < 2)
//        {
//            RandomAddGameObjects.transform.position = Vector3.Lerp(RandomAddGameObjects.transform.position, originalPos, Time.deltaTime * moveSpeed);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        RandomAddGameObjects.transform.position = originalPos; // ensure end at original position since Lerp is inexact


//        yield return null;
//    }
//}
