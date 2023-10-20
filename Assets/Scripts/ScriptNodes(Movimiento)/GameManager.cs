using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public Node currentNode;

    private void Awake()
    {
        ins = this; 
    }
}
