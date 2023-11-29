using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterSceneTransition : MonoBehaviour
{
    // Specify the name of the scene you want to load for counter range 1-3
    public string sceneToLoad1to3;

    // Specify the name of the scene you want to load for counter range 4-6
    public string sceneToLoad4to6;

    public string sceneToLoad7to9;


    // Function to be called when the button is clicked
    public void CheckCounterAndLoadScene()
    {
        // Access the PistaSave singleton instance
        PistaSave pistaSave = PistaSave.Instance;

        // Check if the counter is between 1 and 3 (inclusive)
        if (pistaSave.Counter >= 1 && pistaSave.Counter <= 3)
        {
            // Load the specified scene for counter range 1-3
            SceneManager.LoadScene(sceneToLoad1to3);
        }
        // Check if the counter is between 4 and 6 (inclusive)
        else if (pistaSave.Counter >= 4 && pistaSave.Counter <= 6)
        {
            // Load the specified scene for counter range 4-6
            SceneManager.LoadScene(sceneToLoad4to6);
        }
        else if (pistaSave.Counter >= 7 && pistaSave.Counter <= 9)
        {
            SceneManager.LoadScene(sceneToLoad7to9);
        }
    }
}