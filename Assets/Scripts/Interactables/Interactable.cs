using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public abstract class Interactable : NetworkBehaviour
{
    public ChainEvent chainEvent;
    public virtual void Interact()
    {
        if (chainEvent)
        {
            chainEvent.DoEvent();
        }
        RpcInteract();
    }
    [ClientRpc] public virtual void RpcInteract()
    {
        // play sound effect?
    }
}
