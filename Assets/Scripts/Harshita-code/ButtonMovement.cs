using UnityEngine;

public class ButtonMovement: MonoBehaviour
{
    public Transform[] buttons;
    public Transform centerPoint;
    public float speed = 10f;

    private bool allButtonsMoved = false;

    void Update()
    {
        if (!allButtonsMoved)
        {
            bool allButtonsAtCenter = true;
            foreach (Transform button in buttons)
            {
                if (button.position != centerPoint.position)
                {
                    allButtonsAtCenter = false;
                    break;
                }
            }

            if (allButtonsAtCenter)
            {
                allButtonsMoved = true;
            }
            else
            {
                foreach (Transform button in buttons)
                {
                    button.position = Vector3.MoveTowards(button.position, centerPoint.position, speed * Time.deltaTime);
                }
            }
        }
    }
}
