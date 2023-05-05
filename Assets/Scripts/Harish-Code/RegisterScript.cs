using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterScript : MonoBehaviour
{

    public TextMeshProUGUI userNameTMP;
    // Start is called before the first frame update

    public void loadHomeScreen()
    {
        string username = userNameTMP.text;



        if (username.Length == 1 || username.Length == 0)
        {
            Debug.Log("We ain't going anywhere");
        }
        else
        {

            SceneManager.LoadScene("HomeScreen");
        }
    }
  
}
