using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptAlgodon : MonoBehaviour
{

    public Material algodonMat;
    public Texture2D texturaAlgodon;
    public GameObject Forma;

    private void Start()
    {
        
    }
    public void CambiarTextura(Texture2D nuevaTextura)
    {
        algodonMat = GetComponent<Material>();
        algodonMat.SetTexture("_Base_Color_Texture", nuevaTextura);
        texturaAlgodon = nuevaTextura;
    }

    public void CambiarForma(GameObject nuevaForma)
    {
        Forma = GetComponent<GameObject>();
        Forma = nuevaForma;
    }
}
