using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DoorChild : Interactable
{
    public Door doorParent;
    public override void Interact()
    {
        doorParent.Interact();
    }
    [ClientRpc] public override void RpcInteract()
    {
        print("Tried to call RPC of child door. Call that of the parent instead.");
    }
}
