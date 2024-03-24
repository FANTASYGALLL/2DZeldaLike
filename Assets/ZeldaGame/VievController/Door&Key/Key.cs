using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using PixelCrushers.DialogueSystem;

namespace ZeldaGame2D{

    public class Key : ZeldaGameController
    {
        public int KeyID;
  
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                  this.SendCommand(new KeyCountCommand(1));
                  GameManager.instance.saveKeyOpen(KeyID);
            
            Destroy(gameObject,1f);
            }
        }
        
        public void PlayerPickTheKey(GameObject other)
        {
           /*  transform.parent = other.gameObject.transform;
                transform.position = new Vector3(other.gameObject.transform.position.x-1 ,
                other.gameObject.transform.position.y,
                other.gameObject.transform.position.z ); 
                */
        }

        
        void Start()
        {
            if(GameManager.instance.LoadKeyOpen(KeyID))
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<DialogueSystemTrigger>().barkText = KeyID.ToString();
            }
        }

        void Update()
        {
            
        }

        
       


    }

}