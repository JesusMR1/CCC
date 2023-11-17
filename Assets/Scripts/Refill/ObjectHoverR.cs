using UnityEngine;
using TMPro;

public class ObjectHoverR : MonoBehaviour
{
    public TextMeshProUGUI percentageText;

    private int currentPercentage = 100;
    private bool hasSubtracted = false;

    // Speed factor for controlling the speed of percentage increase
    public float increaseSpeed = 5.0f;

    private void Start()
    {
        // Make sure the TextMeshProUGUI component is assigned in the Inspector
        if (percentageText == null)
        {
            Debug.LogError("Percentage Text not assigned!");
        }
        else
        {
            // Set the initial text value to "100%"
            percentageText.text = $"{currentPercentage}%";

            // Disable the TextMeshProUGUI component initially
            percentageText.gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        // Display the percentage on the TextMeshProUGUI element
        percentageText.text = $"{currentPercentage}%";

        // Activate the TextMeshProUGUI component
        percentageText.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        // Deactivate the TextMeshProUGUI component when the mouse exits the object
        percentageText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Check if the current percentage is between 0% and 19%
        if (currentPercentage >= 0 && currentPercentage <= 19)
        {
            // Player cannot interact when the percentage is below 20%
            return;
        }

        // Subtract 20% instantly when left-clicking on the object
        if (!hasSubtracted && currentPercentage > 0)
        {
            SubtractPercentage(20);
            hasSubtracted = true;
        }
    }

    private void OnMouseUp()
    {
        // Reset the flag on mouse up to allow subtraction on the next click
        hasSubtracted = false;
    }

    private void FixedUpdate()
    {
        // Check if the "R" key is held down and refill the percentage
        if (Input.GetKey(KeyCode.R) && currentPercentage < 100)
        {
            IncreasePercentage(increaseSpeed * Time.deltaTime); // Use a fixed increment for simplicity
            Debug.Log(percentageText.text);
        }
    }

    private void IncreasePercentage(float incrementAmount)
    {
        // Increase the percentage based on the increment amount
        currentPercentage += Mathf.RoundToInt(incrementAmount);

        // Ensure the percentage does not exceed 100
        currentPercentage = Mathf.Min(currentPercentage, 100);

        // Update the TextMeshProUGUI element
        percentageText.text = $"{currentPercentage}%";
    }

    private void SubtractPercentage(int amount)
    {
        // Subtract the specified percentage amount
        currentPercentage -= amount;

        // Ensure the percentage is not less than 0
        currentPercentage = Mathf.Max(currentPercentage, 0);

        // Update the TextMeshProUGUI element
        percentageText.text = $"{currentPercentage}%";
    }
}