using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class VialParent : NetworkBehaviour
{   
    // Index in this array corresponds with VialColor enum
    public ChainEvent chainEvent;
    public bool[] vialStatuses;
    private bool isDone = false;
    public void Start()
    {
        vialStatuses = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            vialStatuses[i] = false;
        }
    }

    public void CheckStatus()
    {
        if (!isDone)
        {
            foreach (bool b in vialStatuses)
            {
                if (!b)
                {
                    return;
                }
            }
            isDone = true;
            chainEvent.DoEvent();
        }
    }

}
