using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BreakerReceiver : NetworkBehaviour
{
    [SerializeField] Material correct, incorrect;
    [SyncVar] public bool isCorrect;
    public void Flip()
    {   
        isCorrect = !isCorrect;
        RpcFlip();
    }
    [ClientRpc]
    public void RpcFlip()
    {
        var ls = transform.localScale;
        transform.localScale = new Vector3(ls.x*-1, ls.y, ls.z);

        if(isCorrect)
        {
            GetComponent<MeshRenderer>().material = correct;
        }
        else
        {
            GetComponent<MeshRenderer>().material = incorrect;
        }
    }
}
