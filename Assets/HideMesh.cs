using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HideMesh : NetworkBehaviour
{
    public GameObject mesh;
    void Start()
    {
        if (isLocalPlayer)
        {
            var layer = LayerMask.NameToLayer("LocalPlayer");
            mesh.layer = layer;
            Transform[] children = mesh.GetComponentsInChildren<Transform>();
            foreach (Transform child in children)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}
