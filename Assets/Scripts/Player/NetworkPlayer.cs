using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject childObject;
    void Start()
    {
        if (isLocalPlayer)
        {
            if (childObject.GetComponent<AudioListener>())
            {
                childObject.GetComponent<AudioListener>().enabled = true;
            }
            childObject.GetComponent<Camera>().enabled = true;
            gameObject.tag = "Player";
        }
        else
        {
            if (GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>())
            {
                GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            }
            childObject.tag = "Untagged";
        }
    }

}
