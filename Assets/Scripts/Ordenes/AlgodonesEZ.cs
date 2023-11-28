using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EstructuraAlgodon
{
    public Texture2D colorAlgodon;
    public Mesh formaAlgodon;
}
public class AlgodonesEZ : MonoBehaviour
{
    public ScriptAlgodon algodonPrefab;

    ScriptAlgodon newAlgodon;

    public Transform[] posicion = new Transform[1];
   // public EstructuraAlgodon[] structArray = new EstructuraAlgodon[4];

    public int selectedForma;

    private void Start()
    {
        
    }
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0)&& ColorAzul.tag == "ColorAzul")
        {
            Debug.Log("Ahora es Azul");

            for (int x = 0; x < posicion.Length; x++)
            {
                ScriptAlgodon newAlgodon = Instantiate(algodonPrefab, posicion[x]);

                newAlgodon.texturaAlgodon = structArray[0].colorAlgodon;
                newAlgodon.algodonMat.SetTexture("_Base_Color_Texture", newAlgodon.texturaAlgodon);
            }
        }*/

    }

    private void OnMouseDown()
    {
        if (tag == "ColorAzul" )
        {
            CambiarTexturaAzul();
        }
        else if (tag == "ColorRosa")
        {
            CambiarTexturaRosa();
        }

        else if(tag == "ColorMorado")
        {
            CambiarTexturaMorada();
        }
        else if (tag == "Nota")
        {
            GenerarAlgodon();
        }
    }

    public void CambiarTexturaAzul()
    {
        Debug.Log("Ahora es Azul");

        /*algodonPrefab.texturaAlgodon = structArray[0].colorAlgodon;
        algodonPrefab.algodonMat.SetTexture("_Base_Color_Texture", algodonPrefab.texturaAlgodon);
        // algodonPrefab.Forma = structArray[0].formaAlgodon;*/

        newAlgodon.CambiarTextura(selectedForma, 0);
        

    }
    public void CambiarTexturaRosa()
    {
        Debug.Log("Ahora es Rosa");

        /*algodonPrefab.texturaAlgodon = structArray[1].colorAlgodon;
        algodonPrefab.algodonMat.SetTexture("_Base_Color_Texture", algodonPrefab.texturaAlgodon);
        algodonPrefab.Forma = structArray[1].formaAlgodon;*/

        newAlgodon.CambiarTextura(selectedForma, 2);

    }
    public void CambiarTexturaMorada()
    {
        Debug.Log("Ahora es Morada");


        /*algodonPrefab.texturaAlgodon = structArray[2].colorAlgodon;
        algodonPrefab.algodonMat.SetTexture("_Base_Color_Texture", algodonPrefab.texturaAlgodon);
        //algodonPrefab.Forma = structArray[2].formaAlgodon;*/

        newAlgodon.CambiarTextura(selectedForma, 1);
    }

    public void GenerarAlgodon()
    {
        for (int x = 0; x < posicion.Length; x++)
        {
            newAlgodon = Instantiate(algodonPrefab, posicion[x]);
            newAlgodon.algodonMat.SetTexture("_Base_Color_Texture", newAlgodon.texturaAlgodon);
            //newAlgodon.Forma.GetComponent<GameObject>();
          
            newAlgodon.CambiarForma(selectedForma);


        }
    }

    public void SetForma(int nuevaForma)
    {
        selectedForma = nuevaForma;
    }


}
