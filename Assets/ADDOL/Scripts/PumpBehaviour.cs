using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpBehaviour : MonoBehaviour
{

    public ParticleSystem smoke;
    public Transform pumpRotation;
    public Rigidbody joint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log();
        //Debug.Log("Rot X : " + pumpRotation.transform.rotation.x);
        if(pumpRotation.transform.rotation.x >= 720 && smoke.isPlaying)
        {
            smoke.Stop();
            joint.constraints = RigidbodyConstraints.FreezeRotationX;
        }
    }
}
