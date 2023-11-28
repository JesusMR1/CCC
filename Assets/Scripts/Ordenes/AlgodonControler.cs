using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct EstructuraAlgodon
{
    public Texture2D colorAlgodon;
}
public class AlgodonControler : MonoBehaviour
{
    public ScriptAlgodon algodonPrefab;

    public EstructuraAlgodon[] structArray = new EstructuraAlgodon[3];
     
    // Start is called before the first frame update
    void Start()
    {
        ScriptAlgodon newAlgodon = Instantiate(algodonPrefab);
    }

    // Update is called once per frame
    void Update()
    {

        ScriptAlgodon newAlgodon = algodonPrefab;
        if (Input.GetMouseButtonDown(0) && tag == "ColorAzul")
        {
            newAlgodon.texturaAlgodon = structArray[0].colorAlgodon;
        }
    }
}
