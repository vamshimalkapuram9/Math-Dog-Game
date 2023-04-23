using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizDrag : MonoBehaviour
{

    public GameObject Crt_ans;
    public GameObject AnsB;
    public Text Ans;
    public Text num1;
    public Text num2;
    public Button nextButton;

    //static int countValue = 0;  

    public float dropdistance;

    public bool islocked;

    Vector2 objectInitPos;
    const float PROXIMITY_SENSITIVITY = 90.01f;


    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = AnsB.transform.position;
    }
    public void DragObject()
    {
        if (!islocked)
        {
            var screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f; //distance of the plane from the camera
            AnsB.transform.position = Camera.main.ScreenToWorldPoint(screenPoint); // To move with mouse position
        }
    }

    public void DropObject()
    {
        int a = Convert.ToInt32(num1.text);
        int b = Convert.ToInt32(num2.text);
        int c = Convert.ToInt32(Ans.text);
        dropdistance = Vector3.Distance(AnsB.transform.position, Crt_ans.transform.position);
        
        if (c == a - b) // Check to idenfity correct answer
        {
            islocked = true;
            AnsB.transform.position = Crt_ans.transform.position; // Correct answer will be fixed in answer panel
            nextButton.gameObject.SetActive(true);

            //OnMouseUp();

        }

        else
        {
            islocked = false;
            AnsB.transform.position = objectInitPos; // Worng answer will be pulled to it's original position
            nextButton.gameObject.SetActive(false);
        }

       
    }

    //private void OnMouseUp()
    //{
    //    countValue++;
    //    if (countValue % 2 == 0)
    //    {
    //        SceneManager.LoadScene("Confetti");
    //        Debug.Log("Confetti loading");
    //        countValue = 0;
    //    }

    //    else
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }

        //SceneManager.LoadScene("Confetti");
    
}