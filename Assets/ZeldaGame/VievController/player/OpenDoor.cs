using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class OpenDoor : ZeldaGameController
    {
        /// Sent each frame where a collider on another object is touching
        /// this object's collider (2D physics only).
        /// </summary>
        /// <param name="other">The Collision2D data associated with this collision.</param>
        
        /*        private void OnTriggerStay2D(Collider2D other)
        {
             if(Input.GetKeyDown(KeyCode.Z))
            {
                if(other.gameObject.CompareTag("Door"))
                {
                   this.SendCommand<OpenDorrCommand>();
                }
            }
        }

        */
       
    }

}