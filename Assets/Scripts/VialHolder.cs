using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class VialHolder : NetworkBehaviour
{
    public VialParent parent;
    public VialColor objective;
    [SerializeField] private VialColor current = VialColor.NONE;
    private void OnCollisionEnter(Collision other) 
    {
        if (isServer)
        {
            if (other.gameObject.tag == "Vial")
            {
                print("Vial Found");
                current = other.collider.gameObject.GetComponent<Vial>().color;
                parent.vialStatuses[(int)objective] = current == objective;
                parent.CheckStatus();
            }
        }
    }
}
