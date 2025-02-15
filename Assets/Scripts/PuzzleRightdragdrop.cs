using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NewPuzzleRightdragdrop : MonoBehaviour
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

    static bool showConfetti = false;

    public Text NumberOneButtonText, NumberTwoButtonText, MinusButtonText, EqualButtonText, AnswerButtonText;

    const float PROXIMITY_SENSITIVITY = 100;

    private Text CurrentTextLoc;
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
    }

    

    public void restartPuzzle()
    {
        StartCoroutine(RestartPuzzleCoroutine());
    }

    private IEnumerator RestartPuzzleCoroutine()
    {
        yield return new WaitForSeconds(1f); // wait for 1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DragObject(GameObject obj)
    {
        //obj.transform.position = Input.mousePosition;
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    private Text WhichTextIsNearToThisObject(GameObject obj)
    {
        if (Vector3.Distance(obj.transform.position, NumberOneText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (NumberOneText);
        }

        if (Vector3.Distance(obj.transform.position, NumberTwoText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (NumberTwoText);
        }

        if (Vector3.Distance(obj.transform.position, EqualText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (EqualText);
        }

        if (Vector3.Distance(obj.transform.position, MinusText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (MinusText);
        }

        if (Vector3.Distance(obj.transform.position, AnswerText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (AnswerText);
        }

        return (null);
    }

    public bool AreObjectsNear(GameObject Obj, Text ButtonText)
    {
        try
        {
            Text TextTxt;
            TextTxt = WhichTextIsNearToThisObject(Obj);
            //Debug.Log(TextTxt.text);
            //Debug.Log(ButtonText.text);
            if (TextTxt == null || ButtonText == null || (TextTxt.text != ButtonText.text))
            {
                //  Debug.Log("WrongMatch");
                return false;
            }
            CurrentTextLoc = TextTxt;
            //Debug.Log("RightMatch");
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
        Debug.Log("satus " + EqualLocked + NumberOneLocked + NumberTwoLocked + AnswerLocked + MinusLocked);
        if (EqualLocked && NumberOneLocked && NumberTwoLocked && AnswerLocked && MinusLocked)
        {
            Debug.Log("All Locked");
            EqualLocked = NumberOneLocked = NumberTwoLocked = AnswerLocked = MinusLocked = false;
            nextButton.gameObject.SetActive(true);
            OnMouseClick();
        }
    }

    private void OnMouseClick()
    {
        showConfetti = true;
        SceneManager.LoadScene("HarshitaConfetti", LoadSceneMode.Additive);

    }

    public void DropObject(GameObject obj)
    {
        if (obj == NumberOne)
        {
            if (AreObjectsNear(obj, NumberOneButtonText))
            {
                obj.transform.position = CurrentTextLoc.transform.position;
                NumberOneLocked = true;
                Debug.Log("NumberOneLocked");
                check_if_all_objects_are_locked();
            }
            else
            {
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
