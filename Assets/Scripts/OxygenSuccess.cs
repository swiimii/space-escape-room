using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OxygenSuccess : ChainEvent
{
    public GameObject lights;
    public GameState gameState;
    public override void DoEvent()
    {
        lights.SetActive(true);
        GetComponent<AudioSource>().Play();
        gameState.oxygenSuccess = true;
        gameState.CheckWin();
    }
}
