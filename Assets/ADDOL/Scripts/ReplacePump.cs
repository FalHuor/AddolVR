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
        Debug.Log(other.name);
        Debug.Log("Where is the new Pump : " + Pump.transform.position);

        if (other.gameObject.name == Pump.name)
        {
            StartCoroutine(Rotate(Pump.transform.rotation, new Quaternion(0, 0.7f, 0.7f, 0), time));
            StartCoroutine(Move(Pump.transform.position, new Vector3(92.8f, 35.4f, 6.6f), time));           
        }
    }

    public IEnumerator Rotate(Quaternion startRotation, Quaternion endRotation, float seconds)
    {
        for (float t = 0; t < seconds; t += Time.deltaTime)
        {
            Pump.transform.rotation = Quaternion.Lerp(startRotation, endRotation, Mathf.SmoothStep(0.0f, 1.0f, t / seconds));
            yield return null;
        }
    }

    public IEnumerator Move(Vector3 startpos, Vector3 endpos, float seconds)
    {
        for (float t = 0; t < seconds; t += Time.deltaTime)
        {
            Pump.transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0.0f, 1.0f, t / seconds));
            yield return null;
        }
        FixedJoint fixedJoint = Pump.AddComponent<FixedJoint>();
        fixedJoint.breakForce = Mathf.Infinity;
        fixedJoint.breakTorque = Mathf.Infinity;
        GameObject.Destroy(Pump.GetComponent<Valve.VR.InteractionSystem.Throwable>());
        GameObject.Destroy(Pump.GetComponent<Valve.VR.InteractionSystem.Interactable>());
    }
}
