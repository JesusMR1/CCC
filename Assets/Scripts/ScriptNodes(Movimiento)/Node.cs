using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public Transform camaraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnMouseDown()
    {
        Arrive();
    }

    void Arrive()
    {
        if(GameManager.ins.currentNode != null) 
        {
            GameManager.ins.currentNode.Leave();
        }
        

        // Activar current node
        GameManager.ins.currentNode = this;

        //Mover la camara
        Camera.main.transform.position = camaraPosition.position;
        Camera.main.transform.rotation = camaraPosition.rotation;

        //Apagar colliders
        if (col != null)
        {
            col.enabled = false;
        }

        //Prender colliders visibles
        foreach (Node node in reachableNodes )
        {
            if(node.col != null)
            {
                node.col.enabled = true;
            }
        }
    }

    public void Leave()
    {
        //Apagar colliders visibles
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                node.col.enabled = false;
            }
        }
    }
}
