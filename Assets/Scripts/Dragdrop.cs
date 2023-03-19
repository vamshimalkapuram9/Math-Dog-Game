using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Dragdrop : MonoBehaviour
{

    public GameObject Crt_ans;
    public GameObject AnsB;
    public Text Ans;
    public Text num1;
    public Text num2;
    public Button nextButton;

    public float dropdistance;

    public bool islocked;

    Vector2 objectInitPos;


    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = AnsB.transform.position;
        nextButton.gameObject.SetActive(false);
        GenerateProblem();
    }

    public void DragObject()
    {
        if (!islocked)
        {
            AnsB.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        int a = Convert.ToInt32(num1.text);
        int b = Convert.ToInt32(num2.text);
        int c = Convert.ToInt32(Ans.text);
        float Distance = Vector3.Distance(AnsB.transform.position, Crt_ans.transform.position);
        if (c == a - b)
        {
            islocked = true;
            AnsB.transform.position = Crt_ans.transform.position;
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            islocked = false;
            AnsB.transform.position = objectInitPos;
            nextButton.gameObject.SetActive(false);
        }
    }

    public void GenerateProblem()
    {
        int maxNumber = 10;
        int numA = UnityEngine.Random.Range(1, maxNumber);
        int numB = UnityEngine.Random.Range(1, maxNumber);
        num1.text = numA.ToString();
        num2.text = numB.ToString();
        Ans.text = "";
        islocked = false;
        AnsB.transform.position = objectInitPos;
        nextButton.gameObject.SetActive(false);
    }

    public void NextProblem()
    {
        GenerateProblem();
    }
}
