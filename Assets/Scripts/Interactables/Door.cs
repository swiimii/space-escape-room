using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Door : Interactable
{
    public float openDuration = 5;
    [SerializeField] GameObject door1, door2;
    [SerializeField] Transform endPosition1, endPosition2;
    Transform startPosition1, startPosition2;
    [SerializeField] AudioClip failedToOpenSound;

    public bool isLocked;

    void Start()
    {
        startPosition1 = door1.transform;
        startPosition2 = door2.transform;
    }
    [ClientRpc] public override void RpcInteract()
    {
        if(!isLocked)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(failedToOpenSound);
        }
    }

    public override void Interact()
    {
        if (!isLocked)
        {
            StartCoroutine(OpenDoor());
            base.Interact();
        }
        else
        {
            RpcInteract();
        }
    }

    public IEnumerator OpenDoor()
    {
        float timeElapsed = 0;
        while (timeElapsed < openDuration)
        {
            timeElapsed += Time.deltaTime;
            door1.transform.position = Vector3.Lerp(startPosition1.position, endPosition1.position, timeElapsed/openDuration);
            door2.transform.position = Vector3.Lerp(startPosition2.position, endPosition2.position, timeElapsed/openDuration);
            yield return null;
        }
    }
}
