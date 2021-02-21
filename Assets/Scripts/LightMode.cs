using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class LightMode : NetworkBehaviour
{
    public GameObject[] dimLights; 
    public GameObject[] brightLights;
    public bool status = false;

    public void DimLights()
    {
        status = false;
        RpcDimLights();
        
    }
    public void BrightLights()
    {
        status = true;
        RpcBrightLights();
    }
    private void RpcDimLights()
    {
        foreach (GameObject light in dimLights)
        {
            light.SetActive(true);
        }
        foreach (GameObject light in brightLights)
        {
            light.SetActive(false);
        }
    }
    private void RpcBrightLights()
    {
        foreach (GameObject light in dimLights)
        {
            light.SetActive(false);
        }
        foreach (GameObject light in brightLights)
        {
            light.SetActive(true);
        }
    }
    
}
