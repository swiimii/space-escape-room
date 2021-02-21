using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public abstract class Interactable : NetworkBehaviour
{
    [ClientRpc] public virtual void RpcInteract()
    {
        
    }
}
