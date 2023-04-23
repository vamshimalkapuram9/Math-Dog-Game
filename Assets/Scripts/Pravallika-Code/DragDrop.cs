using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragDrop : MonoBehaviour
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

    static int count = 0;

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
            AnsB.transform.position = Input.mousePosition; // To move with mouse position
        }
    }

    public void restartPuzzle()
    {
        count++;
        if (count % 2 == 0)
        {
            SceneManager.LoadScene("PravallikaConfetti");
            Debug.Log("Confetti loading");
            count = 0;
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        }
        else
        {
            islocked = false;
            AnsB.transform.position = objectInitPos; // Worng answer will be pulled to it's original position
            nextButton.gameObject.SetActive(false);
        }
    }
}