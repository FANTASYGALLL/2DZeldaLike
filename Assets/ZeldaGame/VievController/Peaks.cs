using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class Peaks : ZeldaGameController
    {

        bool isSafe ; 
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public  void SetSafe()
        {
            isSafe = true;
            attacked = false;
        }

        public  void SetUnSafe()
        {
            isSafe = false;
        }
        private bool attacked;
        /// <summary>
        /// Sent each frame where another object is within a trigger collider
        /// attached to this object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!isSafe && other.CompareTag("Player") && !attacked)
            {
                attacked = true;
                this.SendCommand(new AttackPlayerCommand(1));
                other.GetComponent<MoveMoent>().BeAttack();
            }
        }


    }

}