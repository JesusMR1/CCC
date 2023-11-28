using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Material algodonMat;
    public Texture2D texturaAlgodon;

    private void Start()
    {
        
    }
    public void CambiarTextura()
    {
        algodonMat.SetTexture("_Base_Color_Texture", texturaAlgodon);
    }

}
