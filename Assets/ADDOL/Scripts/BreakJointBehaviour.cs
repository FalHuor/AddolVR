using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class BreakJointBehaviour : MonoBehaviour
{

    public GameObject TriggerZone;

    private void Start()
    {
        //gameObject.GetComponent<Valve.VR.InteractionSystem.Interactable>().enabled = false;
        //gameObject.GetComponent<Valve.VR.InteractionSystem.Throwable>().enabled = false;
    }

    private void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint Break");
        TriggerZone.GetComponent<BoxCollider>().enabled = true;
    }
}
