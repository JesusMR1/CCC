using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventosDia1 : MonoBehaviour
{

    public AdvanceTime advanceTime;
    public AnimDialogo animDialogo;

    public GameObject botonLimpiar;
    public GameObject botonFinDia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MensajeJefe();
    }

    void MensajeJefe()
    {
        if (advanceTime.timeHours == advanceTime.timeLimit)
        {
            animDialogo.Mensaje();
            StartCoroutine(BotonLimpiar());
        }
    }

    IEnumerator BotonLimpiar()
    {
        yield return new WaitForSeconds(7f);
        botonLimpiar.SetActive(true);
    }

    public void boton()
    {
        botonFinDia.SetActive(true);
    }

    public void SiguienteDia()
    {
        SceneManager.LoadScene(4);
    }
}
