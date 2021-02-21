using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsLever : Interactable
{
    [SerializeField] LightMode lights;
    [SerializeField] AsteroidConsole asteroidConsole;
    public override void Interact()
    {
        lights.BrightLights();        
        asteroidConsole.PowerOn();
        base.Interact();
    }
}
