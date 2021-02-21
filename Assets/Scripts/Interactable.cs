using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public abstract class Interactable : NetworkBehaviour
{
    public virtual void Interact()
    {
        RpcInteract();
    }
    [ClientRpc] public virtual void RpcInteract()
    {
        // play sound effect?
    }
}
