using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowKeyGenerator : MonoBehaviour
{
    public GameObject[] arrowKeyPrefabs; // Assign the arrow key prefabs in the Inspector.
    public Transform arrowKeySpawnPoint; // Set the spawn point where arrow keys will appear.

    private bool canSpawn = true;
    public float horizontalSpacing = 2.0f; // Adjust the value to control the spacing.

    private int misinputs = 0; // Track the number of misinputs.
    private int misinputThreshold = 3; // Set the threshold for misinputs.

    private List<ArrowKey> spawnedArrowKeys = new List<ArrowKey>(); // Keep track of spawned arrow keys.
    private int inputcount = 0;
    private bool hasMisinput = true;
    private void Start()
    {
        // Ensure you have assigned the arrow key prefabs and spawn point in the Inspector.
        if (arrowKeyPrefabs.Length == 0 || arrowKeySpawnPoint == null)
        {
            Debug.LogError("Arrow key prefabs or spawn point not assigned.");
        }
    }

    private void Update()
    {
       // if (canSpawn && Input.GetMouseButtonDown(0)) // Detect left mouse button click and check if spawning is allowed.
       // {
        //    GenerateArrowKeys();
       // }
      HandleArrowKeyInput2();
        
    }

    private void OnMouseDown()
    {
        if (canSpawn) // Detect left mouse button click and check if spawning is allowed.
        {
          GenerateArrowKeys();
        }
    }

    private void GenerateArrowKeys()
    {
        float spacing = 0; // Initialize the spacing value.

        foreach (GameObject arrowKeyPrefab in arrowKeyPrefabs)
        {
            Vector3 spawnPosition = arrowKeySpawnPoint.position + Vector3.right * spacing;
            GameObject arrowKeyObject = Instantiate(arrowKeyPrefab, spawnPosition, Quaternion.identity);
           
            spacing += horizontalSpacing;
            arrowKeyObject.SetActive(true);
            spawnedArrowKeys.Add(arrowKeyObject.GetComponent<ArrowKey>());
          //  spawnedArrowKeys[0].canGetInput = true;
        }

        canSpawn = false; // Prevent further spawning until the current set of arrow keys is cleared.
    }

    public void HandleArrowKeyInput(KeyCode inputKeyCode, GameObject caller)
    {
      
        if (spawnedArrowKeys.Count > 0)
        {
          
            ArrowKey arrowKey = spawnedArrowKeys[0];
            if (arrowKey.assignedKeyCode == inputKeyCode && caller == arrowKey.gameObject)
            {
                if (spawnedArrowKeys.Count > 1)
                {
                    spawnedArrowKeys.RemoveAt(0);
                    //  spawnedArrowKeys[0].canGetInput = true;

                }
                else
                {
                    spawnedArrowKeys.Clear();
           
                    canSpawn = true;
                    misinputs = 0; // Reset the misinput count when the combination is correct.
                    Debug.Log("Yay"); // Display "Yay" for a correct combination.
           
                }
            }
            /*   if (arrowKey.assignedKeyCode == inputKeyCode && caller == arrowKey.gameObject)
               {
                   Destroy(arrowKey.gameObject);

                   StartCoroutine(delayInput());
               }
               else
               {
                   // If the input is incorrect, you can increase the misinput count.
                 StartCoroutine(delayinputMiss());
               }
               */
        }
        else
        {
            
        }
        
         
         

    }

    public void HandleArrowKeyInput2()  // NUEVA FUNCION, SE USA EN LUGAR DE HANDLEARROWKEYINPUT Y SE LLAMA EN EL UPDATE
    {
        if (spawnedArrowKeys.Count > 0)
        {

            ArrowKey arrowKey = spawnedArrowKeys[0];

            if (Input.GetKeyDown((KeyCode.UpArrow)) || Input.GetKeyDown(KeyCode.DownArrow) ||Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                
                if (Input.GetKeyDown(arrowKey.assignedKeyCode) )
                {
                    Destroy(arrowKey.gameObject);
                    spawnedArrowKeys.RemoveAt(0);
                    Debug.Log(spawnedArrowKeys.Count);
                    if (spawnedArrowKeys.Count == 0)
                    {
                        Debug.Log("Yay");
                    }
                   // hasMisinput = false; 
                }
                else 
                {
                    misinputs++;
                    Debug.Log("misinputs " + misinputs);
                    if (misinputs >= 3)
                    {
                        // If the player has missinput three times, clear the arrow keys and show "Nay."
                        ClearArrowKeys();
                        Debug.Log("Nay");
                    }
                   // hasMisinput = true;
                }
            }
               
            

            
        }
    }
    
/*    IEnumerator delayInput()   /// YA NO SE USA
    {
      yield return new WaitForSeconds(0.2f);
        Debug.Log(spawnedArrowKeys.Count);
        if (spawnedArrowKeys.Count > 1)
        {
            spawnedArrowKeys.RemoveAt(0);
          //  spawnedArrowKeys[0].canGetInput = true;

        }
        else
        {
            spawnedArrowKeys.Clear();
           
                canSpawn = true;
                misinputs = 0; // Reset the misinput count when the combination is correct.
                Debug.Log("Yay"); // Display "Yay" for a correct combination.
           
        }
           

    }
    IEnumerator delayinputMiss()
    {
        yield return new WaitForSeconds(0.2f);
        // If the input is incorrect, you can increase the misinput count.
        misinputs++;
        Debug.Log("misinputs" + misinputs);
        if (misinputs >= 3)
        {
            // If the player has misinput three times, clear the arrow keys and show "Nay."
            ClearArrowKeys();
            Debug.Log("Nay");
        }
        else {
           yield return null;
        }

    }*/
    public void RegisterArrowKey(ArrowKey arrowKey)
    {
        // Mark arrow keys as inactive initially.
        arrowKey.gameObject.SetActive(false);
    }

    private bool AllArrowKeysCompleted()
    {
        return spawnedArrowKeys.Count == 0;
    }

    public void ClearArrowKeys()
    {
        canSpawn = true;
        foreach (var arrowKey in spawnedArrowKeys)
        {
            if (arrowKey != null)
            {
                Destroy(arrowKey.gameObject);
            }
        }
        spawnedArrowKeys.Clear();
        misinputs = 0; // Reset the misinput count.
    }

}