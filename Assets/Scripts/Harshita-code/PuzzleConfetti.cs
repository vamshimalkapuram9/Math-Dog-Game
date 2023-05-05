using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleConfetti : MonoBehaviour
{
    // Update is called once per frame
    public void puzzlenext()
    {
        SceneManager.LoadScene("Sub-Puzzle");
    }
}
