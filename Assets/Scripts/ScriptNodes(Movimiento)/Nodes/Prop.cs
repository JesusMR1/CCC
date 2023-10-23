using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{
    public Location loc;
    Interactable inter;

    private void Start()
    {
        inter = GetComponent<Interactable>();
    }
    public override void Arrive()
    {
        if (inter != null && inter.enabled)
        {
            inter.Interact();
            return;
        }

        base.Arrive();

        //Hacer el objeto interactuable

        if (inter != null)
        {
            col.enabled = true;
            inter.enabled = true;
        }
    }

    public override void Leave()
    {
        base.Leave();

        if (inter != null)
        {
            inter.enabled = false;
        }
    }
}
