
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections;

public class DraggableButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;

    public SubHarish subHarishScript;

    public GameObject answerPanelObject;

    TextMeshProUGUI FirstNumberText;
    TextMeshProUGUI SecondNumberText;
   public TextMeshProUGUI TextInAnswerPanel;
    public Text buttonText;


    GameObject PresentlyActivePanel;



    void Start()
    {
        TextInAnswerPanel.enabled = false;
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

            StartCoroutine(WaitTwoSeconds());

            TextInAnswerPanel.text = correctAnswerValue.ToString();

            TextInAnswerPanel.enabled = true;


        }

        else
        {
            transform.position = originalPosition;
        }


    }
    IEnumerator WaitTwoSeconds()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(2);
        Debug.Log("Two seconds have passed");

        transform.position = originalPosition;

        subHarishScript.changeCurrentlyActivePanel();

    }



}
