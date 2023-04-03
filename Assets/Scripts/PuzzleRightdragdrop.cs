using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleRightdragdrop : MonoBehaviour
{
    public GameObject NumberOne;
    public GameObject NumberTwo;
    public GameObject Minus;
    public GameObject Equal;
    public GameObject Answer;

    public Text NumberOneText;
    public Text NumberTwoText;
    public Text MinusText;
    public Text EqualText;
    public Text AnswerText;

    public Text NumberOneButtonText, NumberTwoButtonText, MinusButtonText, EqualButtonText, AnswerButtonText;

    const float PROXIMITY_SENSITIVITY = 20;

    public Text CurrentTextLoc;
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
    }


    public void DragObject(GameObject obj)
    {
        obj.transform.position = Input.mousePosition;
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
            Debug.Log(TextTxt.text);
            Debug.Log(ButtonText.text);
            if (TextTxt == null || ButtonText == null || (TextTxt.text != ButtonText.text))
            {
                Debug.Log("WrongMatch");
                return false;
            }
            CurrentTextLoc = TextTxt;
            Debug.Log("RightMatch");
            return true;
        }

        catch (Exception e)
         {
           Debug.Log(e.ToString());
           return false;
         }

    }


    public void DropObject(GameObject obj)
    {
        if (obj == NumberOne)
        {
            if (AreObjectsNear(obj, NumberOneButtonText))
            {
                obj.transform.position = CurrentTextLoc.transform.position;
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
            }
            else
            {
                obj.transform.position = EqualInitialPos;
            }
            return;
        }
    }
}
