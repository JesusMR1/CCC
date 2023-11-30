using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChequeoManager : MonoBehaviour
{
    [SerializeField] Ordenes refOrdenes;
    [SerializeField] AlgodonesEZ refAlgodones;
 
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompararOrdenes()
    {
        if (refOrdenes.OrdenesCreadas[0]== null) Debug.Log("null order");
        if (refAlgodones.newAlgodon== null) Debug.Log("null algodon");

        if (refOrdenes.OrdenesCreadas[0].OrdenEstructura.formaAlgodon == refAlgodones.newAlgodon.InstanciaEstructura.formaAlgodon)
        {
            if(refOrdenes.OrdenesCreadas[0].OrdenEstructura.colorAlgodon == refAlgodones.newAlgodon.InstanciaEstructura.colorAlgodon)
            {
                Debug.Log("Orden Correcta");
                Destroy(refAlgodones.newAlgodon.gameObject);
                DestroyImmediate(refOrdenes.OrdenesCreadas[0].gameObject, true);
                refOrdenes.OrdenesCreadas.RemoveAt(0);
            
            }
            else
            {
                Debug.Log("Orden InCorrecta");
                
            }
        }   
        else
        {
            Debug.Log("Orden InCorrecta");
            
        }
    }

}