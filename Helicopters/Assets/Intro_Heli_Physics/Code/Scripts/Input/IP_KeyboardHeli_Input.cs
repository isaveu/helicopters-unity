﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel {
    public class IP_KeyboardHeli_Input : IP_BaseHeli_Input {
        #region Variables
        #endregion

        #region Properties
        protected float throttleInput = 0f;
        public float RawThrottleInput {
            get { return throttleInput; }
        }

        protected float stickyThrottle = 0f;
        public float StickyThrottle {
            get { return stickyThrottle; }
        }

        protected float collectiveInput = 0f;
        public float CollectiveInput {
            get { return collectiveInput; }
        }

        protected float stickyCollectiveInput = 0f;
        public float StickyCollectiveInput {
            get { return stickyCollectiveInput; }
        }

        protected Vector2 cyclicInput = Vector2.zero;
        public Vector2 CyclicInput {
            get { return cyclicInput; }
        }

        protected float pedalInput = 0f;
        public float PedalInput {
            get { return pedalInput; }
        }
        #endregion


        #region Builtin Methods
        #endregion


        #region Custom Methods
        protected override void HandleInputs() {
            base.HandleInputs();

            //Input Methods
            HandleThrottle();
            HandleCollective();
            HandleCyclic();
            HandlePedal();

            //Utility Methods
            ClampInputs();
            HandleStickyThrottle();
            HandleStickyCollective();
        }

        protected virtual void HandleThrottle() {
            throttleInput = Input.GetAxis("Throttle");
        }

        protected virtual void HandleCollective() {
            collectiveInput = Input.GetAxis("Collective");
        }

        protected virtual void HandleCyclic() {
            cyclicInput.y = vertical;
            cyclicInput.x = horizontal;
        }

        protected virtual void HandlePedal() {
            pedalInput = Input.GetAxis("Pedal");
        }


        protected void ClampInputs() {
            throttleInput = Mathf.Clamp(throttleInput, -1f, 1f);
            collectiveInput = Mathf.Clamp(collectiveInput, -1f, 1f);
            cyclicInput = Vector2.ClampMagnitude(cyclicInput, 1);
            pedalInput = Mathf.Clamp(pedalInput, -1f, 1f);
        }

        protected void HandleStickyThrottle() {
            stickyThrottle += RawThrottleInput * Time.deltaTime;
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
            //Debug.Log(stickyThrottle);
        }

        protected void HandleStickyCollective() {
            stickyCollectiveInput += -collectiveInput * Time.deltaTime;
            stickyCollectiveInput = Mathf.Clamp01(stickyCollectiveInput);
            //Debug.Log(stickyCollectiveInput);
        }
        #endregion

    }

}