using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class ReplacePump : MonoBehaviourPunCallbacks
{
    public Transform OldPump;
    private Transform transformPump;
    public GameObject Pump;
    public float time;

    // Start is called before the first frame update
    [PunRPC]
    void Start()
    {
        transformPump = OldPump;
    }

    [PunRPC]
    private void OnTriggerEnter(Collider other)
    {
        Quaternion startRotation = Pump.transform.rotation;
        Vector3 startPosition = Pump.transform.position;
        if (other.gameObject.name == Pump.name)
        {
            for (float t = 0; t < time; t += Time.deltaTime)
            {
                Pump.transform.rotation = Quaternion.Lerp(startRotation, transformPump.rotation, Mathf.SmoothStep(0.0f, 1.0f, t / time));
                Pump.transform.position = Vector3.Lerp(startPosition, transform.position, Mathf.SmoothStep(0.0f, 1.0f, t / time));
            }
        }
    }
}
