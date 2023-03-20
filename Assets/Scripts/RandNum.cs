using UnityEngine;
using UnityEngine.UI;

public class RandNum : MonoBehaviour
{
    public Text input1Text;
    public Text input2Text;
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;

    private int input1;
    private int input2;
    private int correctAnswer;

    void Start()
    {
        GenerateQuiz();
    }

    public void GenerateQuiz()
    {
        input1 = Random.Range(0, 11);
        input2 = Random.Range(0, input1);

        correctAnswer = input1 - input2;

        int correctOption = Random.Range(0, 3);

        if (correctOption == 0)
        {
            option1Text.text = correctAnswer.ToString();
            option2Text.text = (correctAnswer + Random.Range(1, 3)).ToString();
            option3Text.text = (correctAnswer - Random.Range(1, 3)).ToString();
        }
        else if (correctOption == 1)
        {
            option1Text.text = (correctAnswer + Random.Range(1, 3)).ToString();
            option2Text.text = correctAnswer.ToString();
            option3Text.text = (correctAnswer - Random.Range(1, 3)).ToString();
        }
        else
        {
            option1Text.text = (correctAnswer + Random.Range(1, 3)).ToString();
            option2Text.text = (correctAnswer - Random.Range(1, 3)).ToString();
            option3Text.text = correctAnswer.ToString();
        }

        input1Text.text = input1.ToString();
        input2Text.text = input2.ToString();
    }
}
