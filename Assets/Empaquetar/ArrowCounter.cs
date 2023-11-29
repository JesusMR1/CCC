using TMPro;
using UnityEngine;

public class ArrowCounter : MonoBehaviour
{

    public TextMeshProUGUI counterText;
    private int arrowYesCounter = 0;
    private int maxCounter = 10;
    public float baseSpeed = 2.0f; // Initialize with the desired value
    public float speedIncreaseFactor = 0.5f; // Adjust as needed



    public float BaseSpeed
    {
        get { return baseSpeed; }
    }

    void Start()
    {
        // Set the initial speed of the arrow
        AutoMove autoMoveScript = GetComponent<AutoMove>();
        if (autoMoveScript != null)
        {
            autoMoveScript.SetSpeed(baseSpeed);
        }
    }

    public void IncreaseArrowYesCounter()
    {
        arrowYesCounter++;

        // Ensure the counter does not exceed the maximum value
        arrowYesCounter = Mathf.Clamp(arrowYesCounter, 0, maxCounter);

        // Update the TextMeshProUGUI text
        counterText.text = arrowYesCounter + " / " + maxCounter;

        // Check if the counter has reached 10 before adjusting the speed
        if (arrowYesCounter >= maxCounter)
        {
            Debug.Log("Counter reached 10. Do something here.");
            // Optionally, you can stop the movement or perform other actions
        }
        else
        {
            // Adjust the speed based on the counter and speedIncreaseFactor
            float newSpeed = baseSpeed + arrowYesCounter * speedIncreaseFactor;

            // Log the new speed to check if it's being calculated correctly
            Debug.Log("New Speed: " + newSpeed);

            // Apply the new speed to the arrow
            AutoMove autoMoveScript = GetComponent<AutoMove>();
            if (autoMoveScript != null)
            {
                autoMoveScript.SetSpeed(newSpeed);
            }
        }
    }


    public void ResetCounter()
    {
        arrowYesCounter = 0;
        counterText.text = arrowYesCounter + " / " + maxCounter;
    }

    // Rest of the script...
}