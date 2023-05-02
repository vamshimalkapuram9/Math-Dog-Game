
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class DragInterBtn : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform startParent;

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

        startPosition = transform.position;
        
        startParent = transform.parent;
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
        /**
         * Now we use this script to drag and drop buttons into the Answer Panels. Each button already has a value
         * TODO: If the button value matches panel's value. We get the panel's value like this: Get index of the panel and get correctAnswersList[index]
         * 
         * finally if the button's value = correctAnswersList[index]
         * Then show a Debug.Log with correct value and return the button to it's original position
         * */

        //Debug.Log("Final Mouse Position: " + Input.mousePosition);

        //Debug.Log("Mouse 3D Position: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //for(int i =0; i < 6; i++)
        //{
        //    Debug.Log(i+" APanel Pos: " + Camera.main.WorldToScreenPoint(SubInterHarish.answerPanelsList[i].transform.position));
        //}

        //Debug.Log("Drag Answers List: " + string.Join(", ", SubInterHarish.correctAnswersList));


        // get the position of the mouse cursor in world space
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(transform.position);

        Vector3 mousePosition = transform.position;


        bool snapped = false;
        mousePosition.z = 90f;

        int index = 0;
        
        // loop through all the panels and check if the mouse cursor is within the snap distance
        foreach (GameObject panel in SubInterHarish.answerPanelsList)
        {
            Debug.Log("Distance: " + Vector3.Distance(mousePosition, panel.transform.position));
            if (Vector3.Distance(mousePosition, panel.transform.position) <= snapDistance)
            {
                //GET PANELS index
                int answer = SubInterHarish.correctAnswersList[index];

                if (buttonText.text == answer.ToString())

                {
                    snapped = true;
                    // if the mouse cursor is within the snap distance, snap the button to the center of the panel
                    transform.position = panel.transform.position;
                    break;
                }
                
            }

            index++;
        
        }

        if(!snapped) {
            transform.position = originalPosition;
        }
        

    }
}