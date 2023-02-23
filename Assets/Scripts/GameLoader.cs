using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLoader : MonoBehaviour
{
    [SerializeField] public TMP_Text onScreenTMP;

    string onScreenText = "Hello";
    public void PuzzleLevel()
    {
        onScreenText = "Puzzle Coming Soon";

        onScreenTMP.text = onScreenText;
    }


    public void FunLevel()
    {
        onScreenText = "Subtraction Fun coming Soon";
        onScreenTMP.text = onScreenText;
    }

    public void QuizLevel()
    {
        onScreenText = "Quiz Level Coming Soon";
        onScreenTMP.text = onScreenText;
    }

    public void PracticeLevel()
    {
        onScreenText = "Practice Level Coming Soon";
        onScreenTMP.text = onScreenText;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
