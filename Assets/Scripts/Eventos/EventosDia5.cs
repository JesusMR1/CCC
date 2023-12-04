using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventosDia5 : MonoBehaviour
{
    public Animator anim;

    public GameObject botonLimpiar;
    public GameObject botonInicioDia;
    public GameObject botonFinDia;

    public GameObject timer;

    public AdvanceTime advanceTime;

    public GameObject reiniciarDia;
    public GameObject pasarDia;
    public CheckManDay4 refContador;

    // Start is called before the first frame update
    void Start()
    {
        MensajeJefe();
    }

    // Update is called once per frame
    void Update()
    {
        FinTimer();
    }

    public void MensajeJefe()
    {
        anim.SetTrigger("Llega");
        StartCoroutine(MensajeOff());
    }

    IEnumerator MensajeOff()
    {
        yield return new WaitForSeconds(5f);
        anim.SetTrigger("SeVa");
        botonInicioDia.SetActive(true);
    }

    public void Timer()
    {
        timer.SetActive(true);
    }

    public void FinTimer()
    {
        if (advanceTime.timeHours == advanceTime.timeLimit)
        {
            if (advanceTime.timeHours == advanceTime.timeLimit)
            {
                if (advanceTime.timeHours == advanceTime.timeLimit)
                {
                    if (refContador.contadorAlgodones < 25)
                    {
                        reiniciarDia.SetActive(true);
                        Debug.Log("ReinciciaDia");
                    }
                    else if (refContador.contadorAlgodones >= 25)
                    {
                        pasarDia.SetActive(true);
                    }
                }

            }
        }
    }

    public void FinDia()
    {
        botonFinDia.SetActive(true);
    }

    public void SiguienteDia()
    {
        SceneManager.LoadScene(8);
    }
}
