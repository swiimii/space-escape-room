using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BreakerSender : Interactable
{
    [SerializeField] BreakerReceiver sibling;
    [SerializeField] BreakerBox box;
    public override void Interact()
    {
        sibling.Flip();
        box.CheckBreaker(sibling);
        base.Interact();
    }
}
