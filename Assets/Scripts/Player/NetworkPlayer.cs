using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        if (!isLocalPlayer)
        {
            if (GetComponentInChildren<AudioListener>())
            {
                GetComponentInChildren<AudioListener>().enabled = false;
            }
            if (GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>())
            {
                GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            }
        }
    }

}
