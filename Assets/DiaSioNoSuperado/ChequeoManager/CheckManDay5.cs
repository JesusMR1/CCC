using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CheckManDay5 : MonoBehaviour
{



    [SerializeField] Ordenes refOrdenes;
    [SerializeField] AlgodonesEZ refAlgodones;

    public int contadorAlgodones = 0;
    public TMP_Text textoContador;

    [SerializeField] Button yourTextMeshProButton; // Reference to your TextMeshPro 


    public ContadorOrdenes refContador;



    // Start is called before the first frame upd
    void Start()
    {
        contadorAlgodones = 0;
        textoContador.text = contadorAlgodones + "/30";
        yourTextMeshProButton.gameObject.SetActive(false); // Initially hide the button

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompararOrdenes()
    {
        if (refOrdenes.OrdenesCreadas[0] == null) Debug.Log("null order");
        if (refAlgodones.newAlgodon == null) Debug.Log("null algodon");

        if (refOrdenes.OrdenesCreadas[0].OrdenEstructura.formaAlgodon == refAlgodones.newAlgodon.InstanciaEstructura.formaAlgodon)
        {
            if (refOrdenes.OrdenesCreadas[0].OrdenEstructura.colorAlgodon == refAlgodones.newAlgodon.InstanciaEstructura.colorAlgodon)
            {
                Debug.Log("Orden Correcta");
                Destroy(refAlgodones.newAlgodon.gameObject);
                DestroyImmediate(refOrdenes.OrdenesCreadas[0].gameObject, true);
                refOrdenes.OrdenesCreadas.RemoveAt(0);

                refOrdenes.ContadorOrdenes = 0;
                refContador.contadorOrdenes = 0;

                contadorAlgodones++;


                {
                    // Assuming contadorAlgodones is a variable that gets updated somewhere in your code
                    if (contadorAlgodones <= 30)
                    {
                        textoContador.text = contadorAlgodones + "/30";

                        // Enable the canvas when contadorAlgodones reaches 10
                        if (contadorAlgodones == 30)
                        {
                            yourTextMeshProButton.gameObject.SetActive(true);

                        }
                    }
                }



            }
            else
            {
                Debug.Log("Orden InCorrecta");
                Destroy(refAlgodones.newAlgodon.gameObject);


            }
        }
        else
        {
            Debug.Log("Orden InCorrecta");
            Destroy(refAlgodones.newAlgodon.gameObject);


        }
    }

    void UpdateCounterText()
    {
        textoContador.text = contadorAlgodones + "/30";
    }

    private void OnMouseDown()
    {
        if (tag == "EntregarOrdenes")
        {
            CompararOrdenes();
            UpdateCounterText(); // Update the counter text after each click

        }
    }
}