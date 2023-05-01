using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SubAdvHarish : MonoBehaviour
{

    //Initialise an Answer Panel Queue
    Queue<GameObject> panelsQueue;
    public int panelCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /**
     * Since Panels Get Dequeued we need to call them again in the animation function
     */

    void getPanels()
    {
        panelCount = 0;
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.FIRST_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.SECOND_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.THIRD_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.FOURTH_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.FIFTH_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.SIXTH_PANEL));

        resetTIAText(panelsQueue);
    }


    void resetTIAText(Queue<GameObject> panelsQueue)
    {
        foreach (GameObject panel in panelsQueue)
        {
            GameObject answerPanelObject = panel.transform.GetChild(4).gameObject;


            //TIA Code
            Transform TIATransform = answerPanelObject.transform.GetChild(0);
            TextMeshProUGUI TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
            TextInAnswerPanel.text = "";
        }
    }
}
