using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AsteroidConsole : NetworkBehaviour
{
    [SerializeField] LightMode lights;
    [SerializeField] GameObject progressBar, warningDisplay;
    [SerializeField] float maxTime = 45;
    [SyncVar] float timeElapsed = 0;
    private float barSize;
    public bool isDisabled = true;
    private void Start()
    {
        barSize = progressBar.transform.localScale.x;
    }

    private void Update() 
    {
        if (isServer && !isDisabled)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > maxTime)
            {
                ShutOffPower();
            }
        }
        var ls = progressBar.transform.localScale;
        progressBar.transform.localScale = new Vector3((maxTime - timeElapsed)/maxTime * barSize, ls.y, ls.z);
    }

    public void FireWeapons()
    {
        var nextAsteroidDistanceInSeconds = 5;
        timeElapsed -= nextAsteroidDistanceInSeconds;
        if (timeElapsed < 0)
        {
            timeElapsed = 0;
        }
    }

    public void ShutOffPower()
    {
        isDisabled = true;
        timeElapsed = 0;
        progressBar.SetActive(false);
        warningDisplay.SetActive(false);
        lights.DimLights();
    }

    public void PowerOn()
    {
        isDisabled = false;
        progressBar.SetActive(true);
        var ls = progressBar.transform.localScale;
        progressBar.transform.localScale = new Vector3(barSize, ls.y, ls.z);
        warningDisplay.SetActive(true);
    }
}
