
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class DragInterBtn : MonoBehaviour, IDragHandler, IEndDragHandler
{


    //For Drag and Drop
    static int count = 0;
    private Vector3 originalPosition;

    private float snapDistance = 1f;

    public Text buttonText;

    public SubInterHarish SubInterHarish;



    private void Start()
    {
        
        originalPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f;


        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        Vector3 mousePosition = transform.position;

        GameObject cPanel;

        bool snapped = false;
        mousePosition.z = 90f;

        int index = 0;

        // loop through all the panels and check if the mouse cursor is within the snap distance
        foreach (GameObject panel in SubInterHarish.answerPanelsList)
        {
            //Debug.Log("Distance: " + Vector3.Distance(mousePosition, panel.transform.position));
            if (Vector3.Distance(mousePosition, panel.transform.position) <= snapDistance)
            {
                //GET PANELS index
                int answer = SubInterHarish.correctAnswersList[index];

                if (buttonText.text == answer.ToString())

                {
                    count++;

                    Debug.Log("Panel Count: " + count);
                    snapped = true;

                    cPanel = panel;


                    // if the mouse cursor is within the snap distance, snap the button to the center of the panel
                    transform.position = panel.transform.position;

                    SubInterHarish.resetTransparency(panel);

                    StartCoroutine(WaitOneSecond(index));

                    SetTIA(panel, buttonText.text);


                    break;
                }

            }

            index++;

        }

        //TODO: Remove the panel from the list. If snapped.

        if (!snapped)
        {
            transform.position = originalPosition;
        }

    }

    private void SetTIA(GameObject answerPanelObject, string buttonString)
    {
        Transform TIATransform = answerPanelObject.transform.GetChild(0);
        TextMeshProUGUI TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
        TextInAnswerPanel.text = buttonString;
        TextInAnswerPanel.enabled = true;
    }

    IEnumerator WaitOneSecond(int index)

    {
        yield return new WaitForSeconds(0.2f);
        transform.position = originalPosition;

        if(count < 6)
        {
            SubInterHarish.callNewAnswerButtons(index);
        }
        else
        {
           SubInterHarish.nextBtn.gameObject.SetActive(true);
            count = 0;
            Debug.Log("Nxt btn pos: "+SubInterHarish.nextBtn.transform.position);

        }
    }

}

//public static class ArrayExtensions
//{
//    public static T[] RemoveAt<T>(this T[] source, int index)
//    {
//        T[] dest = new T[source.Length - 1];
//        if (index > 0)
//            Array.Copy(source, 0, dest, 0, index);

//        if (index < source.Length - 1)
//            Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

//        return dest;
//    }
//}