using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleRightdragdrop : MonoBehaviour
{
    public GameObject NumberOne;
    public GameObject NumberTwo;
    public GameObject Minus;
    public GameObject Equal;
    public GameObject Answer;
    public Button nextButton;

    public Text NumberOneText;
    public Text NumberTwoText;
    public Text MinusText;
    public Text EqualText;
    public Text AnswerText;

    static bool EqualLocked;
    static bool NumberOneLocked;
    static bool NumberTwoLocked;
    static bool AnswerLocked;
    static bool MinusLocked;

    static int count = 0;

    public GameObject NumberOnePanel;
    public GameObject NumberTwoPanel;
    public GameObject MinusPanel;
    public GameObject EqualPanel;
    public GameObject AnswerPanel;
   
    
    public Text NumberOneButtonText, NumberTwoButtonText, MinusButtonText, EqualButtonText, AnswerButtonText;

    const float PROXIMITY_SENSITIVITY = 80;

    private Text CurrentTextLoc;
    private GameObject panelObject;
    public Vector2 NumberOneInitialPos, NumberTwoIntialPos, MinusInitialPos, EqualInitialPos, AnswerInitialPos;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting");
        NumberOneInitialPos = NumberOne.transform.position;
        NumberTwoIntialPos = NumberTwo.transform.position;
        MinusInitialPos = Minus.transform.position;
        EqualInitialPos = Equal.transform.position;
        AnswerInitialPos = Answer.transform.position;

        nextButton.gameObject.SetActive(false);

        //nextButton.onClick.AddListener(onMouseClick);

    }

    public void restartPuzzle()
    {
        count++;
        if (count % 2 == 0)
        {
            SceneManager.LoadScene("HarshitaConfetti");
            Debug.Log("Confetti loading");
            count = 0;
        }

        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    //private IEnumerator RestartPuzzleCoroutine()
    //{
    //    yield return new WaitForSeconds(0.7f); // wait for 1 second
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    //}

    public void DragObject(GameObject obj)
    {
        obj.transform.position = Input.mousePosition;
    }

    private (Text, GameObject) WhichTextIsNearToThisObject(GameObject obj)
    {
        if (Vector3.Distance(obj.transform.position, NumberOneText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (NumberOneText, NumberOnePanel);
        }

        if (Vector3.Distance(obj.transform.position, NumberTwoText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (NumberTwoText, NumberTwoPanel);
        }

        if (Vector3.Distance(obj.transform.position, EqualText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (EqualText, EqualPanel);
        }

        if (Vector3.Distance(obj.transform.position, MinusText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (MinusText, MinusPanel);
        }

        if (Vector3.Distance(obj.transform.position, AnswerText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (AnswerText, AnswerPanel);
        }

        //if it reaches here it means that, I am in empty space
        return (null, null);
    }


    /*
     * This functions job is if it finds the right match i.e
     * If the button is dropped on to right panel then it must
     * return true else for anyother case which is either null 
     * or wrong object then return false
     */
    public bool AreObjectsNear(GameObject Obj, Text ButtonText)
    {
        try
        {
            Text TextTxt;

            //This functions job is to give if the button is around an empty space
            //or near an object
            var ret = WhichTextIsNearToThisObject(Obj);
            TextTxt = ret.Item1;
            panelObject = ret.Item2;

            //If the nearby panel is empty or wrong return false
            if (TextTxt == null || ButtonText == null || (TextTxt.text != ButtonText.text))
            {
                return false;
            }

            //if it enter here's it means that the object is in the right place
            CurrentTextLoc = TextTxt;
            return true;
        }

        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return false;
        }

    }

    private void check_if_all_objects_are_locked()
    {
        Debug.Log("status " + EqualLocked + NumberOneLocked + NumberTwoLocked + AnswerLocked + MinusLocked);

        if (EqualLocked && NumberOneLocked && NumberTwoLocked && AnswerLocked && MinusLocked)
        {
            Debug.Log("All Locked");
            EqualLocked = NumberOneLocked = NumberTwoLocked = AnswerLocked = MinusLocked = false;
            nextButton.gameObject.SetActive(true);

            //This is the code to make the panel text transparent after drag and dropping

            NumberOneButtonText.color = new Color(1f, 1f, 1f, 0f);
            NumberTwoButtonText.color = new Color(1f, 1f, 1f, 0f);
            AnswerButtonText.color = new Color(1f, 1f, 1f, 0f);
            MinusButtonText.color = new Color(1f, 1f, 1f, 0f);
            EqualButtonText.color = new Color(1f, 1f, 1f, 0f);


            // this code to move the numbers to the middle of the screen

            NumberOneText.transform.position = new Vector2((Screen.width / 2f) - 225, Screen.height / 2f);
            NumberOneText.color = new Color(1f, 1f, 1f, 1f);

            MinusText.transform.position = new Vector2((Screen.width / 2f) - 125, Screen.height / 2f);
            MinusText.color = new Color(1f, 1f, 1f, 1f);

            NumberTwoText.transform.position = new Vector2((Screen.width / 2f), Screen.height / 2f);
            NumberTwoText.color = new Color(1f, 1f, 1f, 1f);

            EqualText.transform.position = new Vector2((Screen.width / 2f) + 125, Screen.height / 2f);
            EqualText.color = new Color(1f, 1f, 1f, 1f);

            AnswerText.transform.position = new Vector2((Screen.width / 2f) + 225, Screen.height / 2f);
            AnswerText.color = new Color(1f, 1f, 1f, 1f);

        }
    }


/*    private void onMouseClick()
    {


    }
*/
    public void DropObject(GameObject obj)
        {
            if (obj == NumberOne)
            {
                if (AreObjectsNear(obj, NumberOneButtonText))
                {
                    /*if it enters here it means that we need to lock this object
                     * and make the pannel, button disappear
                     */

                    //This will lock the position of button
                    obj.transform.position = CurrentTextLoc.transform.position;

                    //Setting a global variable to indicate that the number one is blocked
                    NumberOneLocked = true;
                    Debug.Log("NumberOneLocked");
                    
                    //Change the button and panel transperency 
                    NumberOne.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    
                    // check if all objects are locked or not
                    check_if_all_objects_are_locked();

                }
                else
                {
                    //If it enters here it means that return back to same position
                    obj.transform.position = NumberOneInitialPos;
                }
                return;
            }

            if (obj == NumberTwo)
            {
                if (AreObjectsNear(obj, NumberTwoButtonText))
                {
                    obj.transform.position = CurrentTextLoc.transform.position;
                    NumberTwoLocked = true;
                    Debug.Log("NumberTwoLocked");

                    NumberTwo.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                    check_if_all_objects_are_locked();
                }
                else
                {
                    obj.transform.position = NumberTwoIntialPos;
                }
                return;
            }

            if (obj == Answer)
            {
                if (AreObjectsNear(obj, AnswerButtonText))
                {
                    obj.transform.position = CurrentTextLoc.transform.position;
                    AnswerLocked = true;
                    Debug.Log("AnswerLocked");

                    Answer.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                check_if_all_objects_are_locked();
                }
                else
                {
                    obj.transform.position = AnswerInitialPos;
                }
                return;
            }

            if (obj == Minus)
            {
                if (AreObjectsNear(obj, MinusButtonText))
                {
                    obj.transform.position = CurrentTextLoc.transform.position;
                    MinusLocked = true;
                    Debug.Log("MinusLocked");

                    //change button transperency 
                    Minus.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                check_if_all_objects_are_locked();
                }
                else
                {
                    obj.transform.position = MinusInitialPos;
                }
                return;
            }

            if (obj == Equal)
            {
                if (AreObjectsNear(obj, EqualButtonText))
                {
                    obj.transform.position = CurrentTextLoc.transform.position;
                    EqualLocked = true;
                    Debug.Log("EqualLocked");

                    Equal.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                    panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                    check_if_all_objects_are_locked();
                }
                else
                {
                    obj.transform.position = EqualInitialPos;
                }
                return;
            }

    }
}

