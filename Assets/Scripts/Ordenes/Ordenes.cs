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

    void Start()
    {
    }

    void Update()
    {
        // Check for a button press (you can change "Fire1" to your desired button)
        if (Input.GetButtonDown("Fire1"))
        {
            // Call the function to shuffle and select random GameObjects
            StartCoroutine(ShuffleAndSelectGameObjects(5));
        }
    }

    IEnumerator ShuffleAndSelectGameObjects(int count)
    {
        // Shuffle the array
        ShuffleArray(TotalCombinaciones);

        // Randomly select 5 GameObjects
        OrdenesSeleccionadas = new GameObject[count];
        System.Random rand = new System.Random();

        for (int i = 0; i < count; i++)
        {
            OrdenesSeleccionadas[i] = TotalCombinaciones[i];
        }

        // Print the selected GameObjects (names)
        Debug.Log("Selected GameObjects: " + string.Join(", ", OrdenesSeleccionadas.Select(go => go.name)));

        yield return null;
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