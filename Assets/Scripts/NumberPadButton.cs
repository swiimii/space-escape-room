using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPadButton : Interactable
{
    [SerializeField] string inputValue;
    [SerializeField] NumberPad numberPad;
    public override void Interact()
    {
        numberPad.InputDigit(inputValue);
    }
}
