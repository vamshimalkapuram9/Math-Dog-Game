using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dragdrop : MonoBehaviour
{
    public GameObject Crt_ans;
    public GameObject AnsB;
    public Text Ans;
    public TextMeshProUGUI num1;
    public TextMeshProUGUI num2;
    public float dropdistance;
    public bool islocked;
    Vector2 objectInitPos;
    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = AnsB.transform.position;
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
        }
        else 
        {
            islocked = false;
            AnsB.transform.position = objectInitPos;
        }
    }
}