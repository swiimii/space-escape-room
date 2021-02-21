using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsButton : Interactable
{
    [SerializeField] AsteroidConsole asteroidConsole;
    public override void Interact()
    {
        asteroidConsole.FireWeapons();
        base.Interact();
    }
}
