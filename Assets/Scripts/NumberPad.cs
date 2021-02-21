using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NumberPad : NetworkBehaviour
{
    string inputSequence = "";
    public string correctSequence;
    [SerializeField] Door door;

    public void InputDigit(string digit)
    {
        inputSequence = inputSequence + digit;
        if (inputSequence.Length == correctSequence.Length)
        {
            bool inputIsCorrect = string.Compare(inputSequence, correctSequence) == 0;
            if (inputIsCorrect)
            {
                print("Opened!");
                door.isLocked = false;
                door.Interact();
            }
            else
            {
                print("Failed to open");
                inputSequence = "";
                // sad beep
            }
        }
        else
        {
            print("Inputted" + digit);
            // Play input beep
        }
    }
}
