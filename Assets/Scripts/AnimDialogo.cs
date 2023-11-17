using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDialogo : MonoBehaviour
{
    public Animator anim;
    public void Mensaje()
    {
        StartCoroutine(Llega());
    }

    IEnumerator Llega()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("Llega");
        StartCoroutine(SeVa());
    }   
    
    IEnumerator SeVa()
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("SeVa");
    }
}
