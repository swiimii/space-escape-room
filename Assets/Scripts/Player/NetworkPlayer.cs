using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class NetworkPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject childObject;
    public Text sessionId;
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
            ulong id = GameObject.FindGameObjectWithTag("GameController").GetComponent<Mirror.FizzySteam.FizzySteamworks>().SteamUserID;
            sessionId.text = id.ToString();
            sessionId.gameObject.SetActive(true);
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
