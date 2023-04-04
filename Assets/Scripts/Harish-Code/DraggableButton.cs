
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections;

public class DraggableButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;


    public GameObject answerPanelObject;

    public TextMeshProUGUI FirstNumberText;
    public TextMeshProUGUI SecondNumberText;
    public TextMeshProUGUI TextInAnswerPanel;
    public Text answerText;

    GameObject PresentlyActivePanel;



    void Start()
    {
        TextInAnswerPanel.enabled = false;

    }

    //void CheckPanel()
    //{



    //    Transform firstChild = PresentlyActivePanel.transform.GetChild(0);

    //    TextMeshProUGUI firstText = firstChild.GetComponent<TextMeshProUGUI>();

    //    Debug.Log("drag " + firstText.text);
    //    //Debug.Log(PresentlyActivePanel.transform.childCount);



    //}


    public void OnBeginDrag(PointerEventData eventData)
    {
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

        int givenValue = Convert.ToInt32(answerText.text);

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

    }



}
