using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class GameState : ChainEvent
{
    public TextMesh countdownTimer;
    [SerializeField] float countdownTime = 600;
    private float timeElapsed = 0;
    private bool hasStarted = false, isGameOver = false;
    public bool reactorSuccess, oxygenSuccess;

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
        
        Lose();
    }

    public void CheckWin()
    {
        if (reactorSuccess && oxygenSuccess)
        {
            Win();
        }
    }
    public void Win()
    {
        if(!isGameOver)
        {
            isGameOver = true;
            RpcWin();
            StartCoroutine(NextGame());
        }
    }
    public void Lose()
    {
        if(!isGameOver)
        {
            isGameOver = true;
            RpcLose();
            StartCoroutine(NextGame());
        }
    }

    [ClientRpc]
    public void RpcLose()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PostGameController>().lossDisplay.SetActive(true);
    }
    [ClientRpc]
    public void RpcWin()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PostGameController>().winDisplay.SetActive(true);
    }

    public IEnumerator NextGame()
    {
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<NetworkManager>().ServerChangeScene("SampleScene");
    }
}
