using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


namespace ZeldaGame2D{

    public class Boob : ZeldaGameController
    {
        public GameObject bombEffect;
        private Rigidbody2D mirg;
        private bool IsBoobed = false;
        

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            mirg = GetComponent<Rigidbody2D>();

        }

        // Start is called before the first frame update
        void Start()
        {
           
            if(!IsBoobed)
            {
                this.GetSystem<ITimeSystem>().AddDelayTask(1.0f,() =>{mirg.velocity = Vector2.zero;});
            }
            
            this.GetSystem<ITimeSystem>().AddDelayTask(1.5f,()=> {Boobing();});
            
        }

        private void Boobing()
        {
            gameObject.transform.Find("Range").gameObject.SetActive(true);
            Instantiate(bombEffect,transform.position,Quaternion.identity);
            Destroy(gameObject,0.05f);
        }

    }

}