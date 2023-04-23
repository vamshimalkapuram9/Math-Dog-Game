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

    public Text Question;
   
    public Text Minus;
    
    public Text Equal;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;

    public Text answerOption1;
    public Text answerOption2;
    public Text answerOption3;

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

            AnsB.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            Crt_ans.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            Question.color = new Color(1f, 1f, 1f, 0f);

            if(AnsB == Option1 && answerOption1 == Ans)
            {
                Option2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                Option3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                answerOption2.color = new Color(1f, 1f, 1f, 0f);
                answerOption3.color = new Color(1f, 1f, 1f, 0f);

            }

            if (AnsB == Option2 && answerOption2 == Ans)
            {
                Option1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                Option3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                answerOption1.color = new Color(1f, 1f, 1f, 0f);
                answerOption3.color = new Color(1f, 1f, 1f, 0f);

            }

            if (AnsB == Option3 && answerOption3 == Ans)
            {
                Option2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                Option1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

                answerOption2.color = new Color(1f, 1f, 1f, 0f);
                answerOption1.color = new Color(1f, 1f, 1f, 0f);

            }


            RectTransform noOneTxtRT = num1.GetComponent<RectTransform>();
            noOneTxtRT.anchoredPosition = new Vector3((Screen.width / 2f - 850), Screen.height / 2f - 250, 10f);

            RectTransform minusTxtRT = Minus.GetComponent<RectTransform>();
            minusTxtRT.anchoredPosition = new Vector3((Screen.width / 2f - 750), Screen.height / 2f - 250, 10f);

            RectTransform noTwoTxtRT = num2.GetComponent<RectTransform>();
            noTwoTxtRT.anchoredPosition = new Vector3((Screen.width / 2f - 660), Screen.height / 2f - 250, 10f);

            RectTransform equalTxtRT = Equal.GetComponent<RectTransform>();
            equalTxtRT.anchoredPosition = new Vector3((Screen.width / 2f - 550), Screen.height / 2f - 250, 10f);
            
            RectTransform AnswerTxtRT = AnsB.GetComponent<RectTransform>();
            AnswerTxtRT.anchoredPosition = new Vector3((Screen.width / 2f - 450), Screen.height / 2f - 250, 10f);

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