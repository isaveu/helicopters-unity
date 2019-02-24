using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Heli_Camera : MonoBehaviour, IP_IHeliCamera
    {
        #region Variables
        [Header("Camera Properties")]
        public Rigidbody rb;
        public Transform lookAtTarget;
        public float height = 2f;
        public float distance = 2f;
        public float smoothSpeed = 0.35f;

        private Vector3 wantedPos;
        private Vector3 refVelocity;
        #endregion


        #region builtin Methods
        // Update is called once per frame
        void FixedUpdate()
        {
            if(rb)
            {
                UpdateCamera();
            }
        }
        #endregion

        #region Interface Methods
        public void UpdateCamera()
        {
            //Debug.Log("Camera is Updating");
            Vector3 flatfwd = rb.transform.forward;
            flatfwd.y = 0f;
            flatfwd = flatfwd.normalized;

            //wanted position
            wantedPos = rb.position + (flatfwd * distance) + (Vector3.up * height);

            //lets position the camera
            transform.position = Vector3.SmoothDamp(transform.position, wantedPos, ref refVelocity, smoothSpeed);
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
