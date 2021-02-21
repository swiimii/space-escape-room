using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Audio;
public class NumberPad : NetworkBehaviour
{
    string inputSequence = "";
    public string correctSequence;
    [SerializeField] Door door;
    public AudioClip input, success, failure;

    public void InputDigit(string digit)
    {
        inputSequence = inputSequence + digit;
        if (inputSequence.Length == correctSequence.Length)
        {
            bool inputIsCorrect = string.Compare(inputSequence, correctSequence) == 0;
            if (inputIsCorrect)
            {
                print("Opened!");
                RpcPlayAudioClip("success");
                door.isLocked = false;
                door.Interact();
            }
            else
            {
                print("Failed to open");
                inputSequence = "";
                RpcPlayAudioClip("failure");
            }
        }
        else
        {
            print("Inputted" + digit);
            RpcPlayAudioClip("input");
        }
    }

    [ClientRpc]
    public void RpcPlayAudioClip(string clip)
    {
        AudioClip selectedclip = input;
        if (string.Compare(clip, "success") == 0)
        {
            selectedclip = success;
        }
        else if (string.Compare(clip, "failure") == 0)
        {
            selectedclip = failure;
        }
        GetComponent<AudioSource>().PlayOneShot(selectedclip);
    }
}
