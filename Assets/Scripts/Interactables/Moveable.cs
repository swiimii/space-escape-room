using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Moveable : Interactable
{
    [SerializeField] [SyncVar] private GameObject holder;

    public bool IsHeld()
    {
        return holder ? true : false;
    }

    public void SetHeld(GameObject inputHolder)
    {
        holder = inputHolder;
    }

    public void Drop()
    {
        holder = null;
    }
    [ClientRpc] public override void RpcInteract()
    {
        // play sound effect?
    }
}
