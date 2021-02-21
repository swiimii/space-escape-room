using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bomb : Moveable
{
    public void Detonate()
    {
        NetworkManager.Destroy(gameObject);
    }
}
