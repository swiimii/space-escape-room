using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum VialColor {
    RED = 0,
    BLUE = 1,
    GREEN = 2,
    YELLOW = 3,
    NONE = -1
}


public class Vial : NetworkBehaviour
{
    public VialColor color;
    public Quaternion initialRotation;
    public void Start()
    {
        if (isServer)
        {
            initialRotation = transform.rotation;
        }
    }

    public void ResetRotation()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        transform.rotation = initialRotation;
    }

}
