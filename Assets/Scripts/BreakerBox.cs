using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BreakerBox : NetworkBehaviour
{
    public BreakerReceiver[] breakers;
    public GameObject[] lights;
    [SerializeField] int correctBreakers = 0;

    public void Start()
    {
        if (isServer)
        {
            foreach (BreakerReceiver b in breakers)
            {
                if (b.isCorrect)
                {
                    correctBreakers += 1;
                }
            }
        }
    }

    public void CheckBreaker(BreakerReceiver breaker)
    {
        correctBreakers += breaker.isCorrect ? 1 : -1;
        if (correctBreakers >= breakers.Length)
        {
            foreach (GameObject g in lights)
            {
                g.SetActive(true);
            }
        }
    }
}
