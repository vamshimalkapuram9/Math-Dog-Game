using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sub_beginner : MonoBehaviour
{
   public void navigate(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void navigate_back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}



