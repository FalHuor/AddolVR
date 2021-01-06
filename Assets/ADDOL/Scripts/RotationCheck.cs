﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotationCheck : MonoBehaviourPunCallbacks
{
    public int RotationCount;

    public float rotatedAroundX;

    public Vector3 lastUp;

    public ParticleSystem smoke;

    public UnityEvent On3TimesRotated;

    private void Awake()
    {
        rotatedAroundX = 0;

        // initialize
        lastUp = transform.up;
    }

    
    private void Update()
    {
        photonView.RPC("CountRotation", RpcTarget.AllViaServer);
    }

    [PunRPC]
    private void CountRotation()
    {
        var rotationDifference = Vector3.SignedAngle(transform.up, lastUp, transform.right);

        rotatedAroundX += rotationDifference;

        if (rotatedAroundX >= 360.0f)
        {
            Debug.Log("One positive rotation done", this);

            RotationCount++;

            rotatedAroundX -= 360.0f;
        }
        else if (rotatedAroundX <= -360.0f)
        {
            Debug.Log("One negative rotation done", this);

            RotationCount--;

            rotatedAroundX += 360.0f;
        }

        // update last rotation
        lastUp = transform.up;


        // check for fire the event
        if (RotationCount >= 2 && smoke.isPlaying)
        {
            On3TimesRotated?.Invoke();
            smoke.Stop();
            RotationCount = 0;
        }
    }
}
