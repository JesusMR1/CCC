using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ordenes : MonoBehaviour
{
    // Array with 12 GameObjects
    public GameObject[] TotalCombinaciones;

    // Selected GameObjects will be stored here
    public GameObject[] OrdenesSeleccionadas;

    public RectTransform[] spawnPoints;

    void Start()
    {
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            SelectRandomGameObjects(5);
        }
    }

    void SelectRandomGameObjects(int count)
    {
        // Shuffle the array of game objects
        ShuffleArray(TotalCombinaciones);

        // Select a subset of the shuffled game objects
        OrdenesSeleccionadas = TotalCombinaciones.Take(count).ToArray();

        for (int i = 0; i < count; i++)
        {
            // Use the i-th spawn point
            RectTransform spawnPoint = spawnPoints[i % spawnPoints.Length];

            // Instantiate the selected UI element at the spawn point
            GameObject instantiatedUIElement = Instantiate(OrdenesSeleccionadas[i], spawnPoint.position, Quaternion.identity);

            // Set the parent to the Canvas to make it a child of the Canvas
            instantiatedUIElement.transform.SetParent(spawnPoint, false);
            RectTransform rectTransform = instantiatedUIElement.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            
        }

        Debug.Log("Selected GameObjects: " + string.Join(", ", OrdenesSeleccionadas.Select(go => go.name)));
    }

    void ShuffleArray<T>(T[] array)
    {
        // Fisher-Yates shuffle algorithm
        System.Random rand = new System.Random();
        int n = array.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);

            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}