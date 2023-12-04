using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisappearLigh : MonoBehaviour
{
    [SerializeField] private GameObject luz;
    [SerializeField] private float timeDelay = 0.2f;
    public void Turnoff()
    {
        StartCoroutine(turnoff());
    }
    IEnumerator turnoff()
    {
        luz.SetActive(false);
        yield return new WaitForSeconds(timeDelay);
        luz.SetActive(true);
    }
}
