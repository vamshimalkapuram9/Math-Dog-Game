using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterScript : MonoBehaviour
{

    public TextMeshProUGUI userNameTMP;
    // Start is called before the first frame update

    public TextMeshProUGUI warningText;

    public void loadHomeScreen()
    {
        string username = userNameTMP.text;



        if (username.Length < 5)
        {
            warningText.gameObject.SetActive(true);
        }
        else
        {

            SceneManager.LoadScene("HomeScreen");
        }
    }
  
}
