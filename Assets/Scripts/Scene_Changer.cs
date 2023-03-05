using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer: MonoBehaviour
{
   public void navigate(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void navigate_2(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void navigate_3(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void navigate_back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void navigate_back2(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void navigate_back3(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}



