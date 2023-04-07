
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DraggableButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //For Drag and Drop
    private Vector2 originalPosition;
    
    public SubHarish subHarishScript;

    GameObject answerPanelObject;
    TextMeshProUGUI FirstNumberText;
    TextMeshProUGUI SecondNumberText;
    TextMeshProUGUI TextInAnswerPanel;
    public Text buttonText;

    List<Button> draggableBtns = new();


   

    void Start()
    {
        
    }

    // void CheckPanel()
    //{



    //    Transform firstChild = PresentlyActivePanel.transform.GetChild(0);

    //    TextMeshProUGUI firstText = firstChild.GetComponent<TextMeshProUGUI>();

    //    Debug.Log("drag " + firstText.text);
    //    //Debug.Log(PresentlyActivePanel.transform.childCount);



    //}

    void initTextsAndVariables()
    {
        GameObject cPanel = subHarishScript.getCurrentlyActivePanel();
        Transform firstChild = cPanel.transform.GetChild(0);

        //FirstNumberText TMP
        FirstNumberText = firstChild.GetComponent<TextMeshProUGUI>();

        Transform secondChild = cPanel.transform.GetChild(2);

        //SecondNumberText TMP
        SecondNumberText = secondChild.GetComponent<TextMeshProUGUI>();

        //Debug.Log(" "+cPanel.transform.GetChild(4).tag);

        answerPanelObject = cPanel.transform.GetChild(4).gameObject;


        //TIA Code
        Transform TIATransform = answerPanelObject.transform.GetChild(0);
        TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
        TextInAnswerPanel.enabled = false;

        /**
         * ========================================
         *          Button Panel Code 
         *=========================================
        */

        // Get AnswerButtons Panel Object

        getButtons();


    }

    void getButtons()
    {
        GameObject buttonsPanel = GameObject.FindGameObjectWithTag(Tags.ANSWER_BUTTONS_PANEL);

        Button[] buttons = buttonsPanel.GetComponentsInChildren<Button>();

        foreach(Button button in buttons)
        {
            draggableBtns.Add(button);
        }

        foreach (Button button in draggableBtns)
        {
            Debug.Log("Btn Tag: " + button.tag);
        }

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        initTextsAndVariables();

        originalPosition = transform.position;

       
   
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;
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
        yield return new WaitForSeconds(1);
        Debug.Log("Two seconds have passed");

        transform.position = originalPosition;


        if (subHarishScript.panelCount < 5)
        {
            subHarishScript.changeCurrentlyActivePanel();
        }

        else
        {
            subHarishScript.nextBtn.gameObject.SetActive(true);
        }
    }


    /**
     * =========================================================================
     *                          Code For Animation
     * =========================================================================
     */

    public void ShowButton(int index)
    {

    }


}
