using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int homePageIndex = 0;

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

       
    }

    public void GoToHomePage()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void subFun()
    {
        SceneManager.LoadScene("Sub-Fun");

    }


    public void subPuzzle()
    {
        SceneManager.LoadScene("Sub-Puzzle");

    }
        public void subQuiz()
        {
            SceneManager.LoadScene("Sub-Quiz");

        }


    public void register()
    {
        SceneManager.LoadScene("Register");

    }

    public void login()
    {
        SceneManager.LoadScene("Login");

    }

    /**
     * =======================================
     *          CONFETTI LEVELS
     * =======================================
     * */

    public void practiceConfetti()
    {
        SceneManager.LoadScene("PracticeConfetti");

    }

    public void pravallikaConfetti()
    {
        SceneManager.LoadScene("PravallikaConfetti");

    }

    public void Confetti()
    {
        SceneManager.LoadScene("Confetti");

    }

    public void InterConfetti()
    {
        SceneManager.LoadScene("interConfetti");

    }

    /**
     * =======================================
     *          PRACTICE LEVELS
     * =======================================
     * */
    public void subPractice()
    {
        SceneManager.LoadScene("Sub-Practice-Levels");
    }

    public void subBegin()
    {
        SceneManager.LoadScene("Sub-Begin");

    }
    public void subInter()
    {
        SceneManager.LoadScene("Sub-Intemediate");

    }
    public void subAdv()
    {
        SceneManager.LoadScene("Sub-Advanced");

    }


}
