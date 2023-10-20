using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    public CamaraRig camRig;
    

    [HideInInspector]
    public Node currentNode;

    private void Awake()
    {
        ins = this; 
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.Arrive();
        }
    }
}
