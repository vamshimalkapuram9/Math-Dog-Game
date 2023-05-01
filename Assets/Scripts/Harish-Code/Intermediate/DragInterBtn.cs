
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

    GameObject answerPanelObject;
    TextMeshProUGUI FirstNumberText;
    TextMeshProUGUI SecondNumberText;
    TextMeshProUGUI TextInAnswerPanel;
    public Text buttonText;

    List<Button> draggableBtns = new();


    //List of AnswerPanel Game Object
    List<GameObject> answerPanelsList;

    //Correct Answers List
    public int[] correctAnswersList;

    void initAnswersPanelsandAnswersLists()
    {
        answerPanelsList = new();
        
        answerPanelsList = subInterHarish.getAnswerPanels();

        correctAnswersList = subInterHarish.getCorrectAnswersList();
        
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
        //initTextsAndVariables();

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

        //transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

        int firstNo = Convert.ToInt32(FirstNumberText.text);
        int secondNo = Convert.ToInt32(SecondNumberText.text);

        int givenValue = Convert.ToInt32(buttonText.text);

        int correctAnswerValue = firstNo - secondNo;


        if (givenValue == correctAnswerValue)
        {
            transform.position = answerPanelObject.transform.position;

            StartCoroutine(WaitOneSecond());

            TextInAnswerPanel.text = correctAnswerValue.ToString();

            TextInAnswerPanel.enabled = true;


        }

        else
        {
            transform.position = originalPosition;
        }


    }
    IEnumerator WaitOneSecond()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(0.5f);

        transform.position = originalPosition;


        if (subInterHarish.panelCount < 5)
        {
            //subInterHarish.changeCurrentlyActivePanel();
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
