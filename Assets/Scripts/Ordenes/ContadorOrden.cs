using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorOrden : MonoBehaviour
{
    // Counter variable
    int counter = 0;

    void Update()
    {
        // Assuming your counter variable is being incremented somewhere in your code
        // For demonstration purposes, incrementing the counter here
        counter++;

        // Check if the counter reaches a specific number (e.g., 5)
        if (counter == 10)
        {
            // Print "yay" to the debug log
            Debug.Log("yay");
        }
    }
}