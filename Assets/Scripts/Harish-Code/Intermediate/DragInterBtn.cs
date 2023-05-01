
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class DragInterBtn : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //For Drag and Drop
    static int count = 0;

    private Vector3 originalPosition;

    public SubInterHarish subInterHarish;

    public Text buttonText;

    List<Button> draggableBtns = new();


    //List of AnswerPanel Game Object
    List<GameObject> answerPanelsList;

    //Correct Answers List
    public int[] correctAnswersList;


    void Start()
    {
        initAnswersPanelsandAnswersLists();
    }
  

    void initAnswersPanelsandAnswersLists()
    {
        answerPanelsList = new List<GameObject>();

        answerPanelsList = subInterHarish.getAnswerPanels();

        //foreach(GameObject aPanelObject in answerPanelsList)
        //{
        //    Debug.Log("APanel Tag: " + aPanelObject.gameObject.tag);
        //}

        Debug.Log("APanel Count: " + answerPanelsList.Count);

        correctAnswersList = subInterHarish.getCorrectAnswersList();

       // Debug.Log("Drag Answers List: " + string.Join(", ", correctAnswersList));


        getButtons();


    }

   




    //void initTextsAndVariables()
    //{

    //    Transform firstChild = cPanel.transform.GetChild(0);

    //    //FirstNumberText TMP
    //    FirstNumberText = firstChild.GetComponent<TextMeshProUGUI>();

    //    Transform secondChild = cPanel.transform.GetChild(2);

    //    //SecondNumberText TMP
    //    SecondNumberText = secondChild.GetComponent<TextMeshProUGUI>();

    //    //Debug.Log(" "+cPanel.transform.GetChild(4).tag);

    //    answerPanelObject = cPanel.transform.GetChild(4).gameObject;


    //    //TIA Code
    //    Transform TIATransform = answerPanelObject.transform.GetChild(0);
    //    TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
    //    TextInAnswerPanel.enabled = false;

    //    /**
    //     * ========================================
    //     *          Button Panel Code 
    //     *=========================================
    //    */

    //    // Get AnswerButtons Panel Object

    //    getButtons();


    //}

    void getButtons()
    {
        GameObject buttonsPanel = GameObject.FindGameObjectWithTag(Tags.ANSWER_BUTTONS_PANEL);

        Button[] buttons = buttonsPanel.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            draggableBtns.Add(button);
        }

        //foreach (Button button in draggableBtns)
        //{
        //    Debug.Log("Btn Tag: " + button.tag);
        //}

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
     
        originalPosition = transform.position;

    }

    public void OnDrag(PointerEventData eventData)
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f;


        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       

        int givenValue = Convert.ToInt32(buttonText.text);

        bool isAnswered = false;

        foreach (GameObject panel in answerPanelsList)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(), Input.mousePosition))
            {
                int index = answerPanelsList.IndexOf(panel);

                if(givenValue == correctAnswersList[index])
                {
                    transform.position = panel.transform.position;
                    StartCoroutine(WaitOneSecond(panel,index));
                    setTIAText(panel, correctAnswersList[index]);
                    isAnswered = true;

                    break;

                }

            }

        }


        if (!isAnswered)
        {
            transform.position = originalPosition;
        }


    }

    void setTIAText(GameObject panel,int answerInt)
    {
        GameObject answerPanelObject = panel.transform.GetChild(4).gameObject;


        //TIA Code
        Transform TIATransform = answerPanelObject.transform.GetChild(0);
        TextMeshProUGUI TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
        TextInAnswerPanel.text = ""+answerInt;
        TextInAnswerPanel.enabled = true;


    }

    IEnumerator WaitOneSecond(GameObject currentAnswerPanel, int index)
    {
        Debug.Log("Coroutine started");


        yield return new WaitForSeconds(0.5f);

        transform.position = originalPosition;


        answerPanelsList.Remove(currentAnswerPanel);


        if (correctAnswersList.Length != 0)
        {
            correctAnswersList = ArrayExtensions.RemoveAt(correctAnswersList, index);
        }

        else
        {
            //subInterHarish.resetTransparency(cPanel);

            subInterHarish.nextBtn.gameObject.SetActive(true);

            // Need some code for nextBtn click
        }
    }
    public void restartPuzzle()
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
    }


   
    /**
     * =========================================================================
     *                          Code For Animation
     * =========================================================================
     */




}

public static class ArrayExtensions
{
    public static T[] RemoveAt<T>(this T[] source, int index)
    {
        T[] dest = new T[source.Length - 1];
        if (index > 0)
            Array.Copy(source, 0, dest, 0, index);

        if (index < source.Length - 1)
            Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

        return dest;
    }
}
