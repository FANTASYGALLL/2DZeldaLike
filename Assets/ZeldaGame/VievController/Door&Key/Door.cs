using UnityEngine;
using QFramework;
using PixelCrushers.DialogueSystem;

namespace ZeldaGame2D{

    public class Door : ZeldaGameController
    {

        IPlayerModel mPlayermodel ;

        public int DoorID;
        private AudioSource au;
        private DialogueSystemTrigger dialogue;
        void Start()
        {
            au= gameObject.GetComponent<AudioSource>();
          mPlayermodel = this.GetModel<IPlayerModel>();
            dialogue = gameObject.GetComponent<DialogueSystemTrigger>();
          if ( GameManager.instance.LoadDoorOpen(DoorID) ) 
          {
              OpenDoor();
            }
            else
            {
                dialogue.barkText = DoorID.ToString();
            }
            
        }

        /// <summary>
        /// Sent each frame where another object is within a trigger collider
        /// attached to this object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
        private void OnTriggerStay2D(Collider2D other)
        {
              if(other.tag=="Player" && Input.GetKey(KeyCode.Z) & mPlayermodel.KeyCount.Value !=0&& GameManager.instance.LoadKeyOpen(DoorID))
            {
                // this.RegisterEvent<OpenDoorEvent>(OpenDoor);
                OpenDoor();
                this.SendCommand(new KeyCountCommand(0));
                au.Play();
                GameManager.instance.saveDoorOpen(DoorID);
               
            }
        }

        public void OpenDoor()
        {
            transform.Find("ClosedDoor").gameObject.SetActive(false);
            transform.Find("OpenedDoor").gameObject.SetActive(true);
            GameManager.instance.saveDoorOpen(DoorID);
            dialogue.enabled = false;
        }

        /// <summary>
        /// This function is called when the MonoBehaviour will be destroyed.
        /// </summary>
    
        
        
    }

}