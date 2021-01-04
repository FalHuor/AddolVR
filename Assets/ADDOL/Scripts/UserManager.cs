using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

namespace WS3
{
    public class UserManager : MonoBehaviourPunCallbacks
    {
        public static GameObject UserMeInstance;

        public Material PlayerLocalMat;
        /// <summary>
        /// Represents the GameObject on which to change the color for the local player
        /// </summary>
        public GameObject GameObjectLocalPlayerColor;

        /// <summary>
        /// The FreeLookCameraRig GameObject to configure for the UserMe
        /// </summary>
        GameObject goFreeLookCameraRig = null;

        

        #region Snwoball Spawn
        /// <summary>
        /// The Transform from which the snow ball is spawned
        /// </summary>
        [SerializeField] Transform snowballSpawner;
        /// <summary>
        /// The prefab to create when spawning
        /// </summary>
        [SerializeField] GameObject SnowballPrefab;



        // Use to configure the throw ball feature
        [Range(0.2f, 100.0f)] public float MinSpeed;
        [Range(0.2f, 100.0f)] public float MaxSpeed;
        [Range(0.2f, 100.0f)] public float MaxSpeedForPressDuration;
        private float pressDuration = 0;

        #endregion

        void Awake()
        {
            if (photonView.IsMine)
            {
                //Debug.LogFormat("Avatar UserMe created for userId {0}", photonView.ViewID);
                UserMeInstance = gameObject;

            }
        }

        // Start is called before the first frame update
        void Start()
        {
            //Debug.Log("isLocalPlayer:" + photonView.IsMine);
            updateGoFreeLookCameraRig();
            followLocalPlayer();
            activateLocalPlayer();
            //GameObject.Instantiate("Prefabs/", new Vector3(0f,0f,0f), Quaternion.identity);
        }

                /// <summary>
        /// Get the GameObject of the CameraRig
        /// </summary>
        protected void updateGoFreeLookCameraRig()
        {
            if (!photonView.IsMine) return;
            try
            {
                // Get the Camera to set as the followed camera
                goFreeLookCameraRig = transform.Find("/FreeLookCameraRig").gameObject;
            }
            catch (System.Exception ex)
            {
                //Debug.LogWarning("Warning, no goFreeLookCameraRig found\n" + ex);
            }
        }

        /// <summary>
        /// Make the CameraRig following the LocalPlayer only.
        /// </summary>
        protected void followLocalPlayer()
        {
            if (photonView.IsMine)
            {
                if (goFreeLookCameraRig != null)
                {
                    // find Avatar EthanHips
                    Transform transformFollow = transform.Find("EthanSkeleton/EthanHips") != null ? transform.Find("EthanSkeleton/EthanHips") : transform;
                    // call the SetTarget on the FreeLookCam attached to the FreeLookCameraRig
                    goFreeLookCameraRig.GetComponent<FreeLookCam>().SetTarget(transformFollow);
                    //Debug.Log("ThirdPersonControllerMultiuser follow:" + transformFollow);
                }
            }
        }

        protected void activateLocalPlayer()
        {
            // enable the ThirdPersonUserControl if it is a Loacl player = UserMe
            // disable the ThirdPersonUserControl if it is not a Loacl player = UserOther
            GetComponent<ThirdPersonUserControl>().enabled = photonView.IsMine;
            GetComponent<Rigidbody>().isKinematic = !photonView.IsMine;
            if (photonView.IsMine)
            {
                try
                {
                    // Change the material of the Ethan Glasses
                    GameObjectLocalPlayerColor.GetComponent<Renderer>().material = PlayerLocalMat;
                }
                catch (System.Exception)
                {

                }
            }
        }

    }
}
