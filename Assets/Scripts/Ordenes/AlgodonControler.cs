using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AlgodonControler : MonoBehaviour
{

    public Transform[] posicion = new Transform[1];
    public ScriptAlgodon algodonPrefab;

    public EstructuraAlgodon[] structArray = new EstructuraAlgodon[3];
     
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < posicion.Length; x++)
        {
            ScriptAlgodon newAlgodon = Instantiate(algodonPrefab, posicion[x]);

                newAlgodon.texturaAlgodon = structArray[0].colorAlgodon;
            
        }

    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
