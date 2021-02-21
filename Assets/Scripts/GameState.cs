using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameState : ChainEvent
{
    public TextMesh countdownTimer;
    [SerializeField] float countdownTime = 600;
    private float timeElapsed = 0;
    private bool hasStarted = false;

    public override void DoEvent()
    {
        BeginCountdown();
    } 
    public void BeginCountdown()
    {
        if (!hasStarted)
        {
            hasStarted = true;
            StartCoroutine(Countdown());
            RpcBeginCountdown();
        }
    }

    [ClientRpc]
    public void RpcBeginCountdown()
    {
        GetComponent<AudioSource>().Play();
        if (!isServer)
        {
            StartCoroutine(Countdown());
        }
    }
    public IEnumerator Countdown()
    {
        while (timeElapsed < countdownTime)
        {
            timeElapsed += Time.deltaTime;
            var timeLeft = countdownTime - timeElapsed;
            countdownTimer.text = string.Format("{0:0}:{1:00.00}", (int)(timeLeft/60), timeLeft%60);
            yield return null;
        }
    }
}
