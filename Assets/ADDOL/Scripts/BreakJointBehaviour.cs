using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class BreakJointBehaviour : MonoBehaviourPunCallbacks
{

    public GameObject TriggerZone;

    [PunRPC]
    private void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint Break");
        TriggerZone.GetComponent<BoxCollider>().enabled = true;
    }
}
