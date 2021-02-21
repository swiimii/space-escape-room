using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsLever : Interactable
{
    [SerializeField] LightMode lights;
    public override void Interact()
    {
        lights.BrightLights();
        base.Interact();
    }
}
