using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MoveObjects : NetworkBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField][SyncVar] GameObject heldObject;
    public void Update()
    {
        if (isLocalPlayer)
        {
            var interactableHit = SearchForInteractables();
            if (Input.GetButtonDown("Fire1"))
            {
                if (heldObject)
                {
                    CmdDropObject();
                }
                else if (interactableHit)
                {
                    if (interactableHit.GetComponent<Moveable>())
                    {
                        print("Pick up!");
                        CmdAttemptToPickUp(interactableHit);
                    }
                    else
                    {
                        print("Interact!");
                        CmdInteract(interactableHit);
                    }
                }
                
            }
        }
        if (isServer)
        {
            if (heldObject)
            {
                // Move objects towards pointed-at direction
                var mc = cam;
                var originPosition = mc.transform.position;
                var direction = mc.transform.forward;
                var distanceMax = 2;
                var moveSpeed = 10;
                var hit = Physics.Raycast(originPosition, direction, out var hitInfo, distanceMax, ~(1 << LayerMask.NameToLayer("Player")) + ~(1 << LayerMask.NameToLayer("Interactable")));
                if (hit)
                {
                    var hitDistance = hitInfo.distance;
                    var position = transform.position + cam.transform.forward * (hitDistance-.3f);
                    heldObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude((position - heldObject.transform.position), 1) * moveSpeed;
                }
                else
                {
                    var position = transform.position + cam.transform.forward * distanceMax;
                    heldObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude((position - heldObject.transform.position), 1) * moveSpeed;
                }
            }
        }
    }

    public GameObject SearchForInteractables()
    {
        var mc = cam;
        var originPosition = mc.transform.position;
        var direction = mc.transform.forward;
        var distanceMax = 2;
        var hit = Physics.Raycast(originPosition, direction, out var hitInfo, distanceMax, 1 << LayerMask.NameToLayer("Interactable"));
        Debug.DrawRay(originPosition, direction * distanceMax, Color.red);
        if (hit && hitInfo.collider && hitInfo.collider.GetComponent<Interactable>())
        {
            return hitInfo.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    [Command]
    public void CmdAttemptToPickUp(GameObject obj)
    {
        print("Checking");
        var moveable = obj.GetComponent<Moveable>();
        if (!moveable.IsHeld() && !heldObject)
        {
            print("Check passed!");
            moveable.SetHeld(gameObject);
            heldObject = obj;
        }
    }

    [Command]
    public void CmdDropObject()
    {
        heldObject.GetComponent<Moveable>().Drop();
        heldObject = null;
    }

    [Command]
    public void CmdInteract(GameObject obj)
    {
        var interactable = obj.GetComponent<Interactable>();
        interactable.Interact();
    }

}
