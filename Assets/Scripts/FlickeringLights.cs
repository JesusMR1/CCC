using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    private bool Flicker = false;
    [SerializeField] private float TimeDelay;

    private void Update()
    {
        if (Flicker == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }
    IEnumerator FlickeringLight()
    {
        Flicker = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        TimeDelay = Random.Range(0.01f, 0.6f);
        yield return new WaitForSeconds(TimeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        TimeDelay = Random.Range(0.01f, 0.6f);
        yield return new WaitForSeconds(TimeDelay);
        Flicker = false;
    }
}
