using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class BreakJointBehaviour : MonoBehaviour
{

    public GameObject TriggerZone;

    private void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint Break");
        TriggerZone.GetComponent<BoxCollider>().enabled = true;
    }
}
