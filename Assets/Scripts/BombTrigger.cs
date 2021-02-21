using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BombTrigger : NetworkBehaviour
{
    [SerializeField] Door door;
    private void OnTriggerEnter(Collider other) 
    {
        if(isServer)
        {
            if (other.GetComponent<Bomb>())
            {
                other.GetComponent<Bomb>().Detonate();
                door.StartCoroutine("OpenDoor");
            }
        }
    }
}
