using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class ChainEvent : NetworkBehaviour
{
    public virtual void DoEvent() {}
}
