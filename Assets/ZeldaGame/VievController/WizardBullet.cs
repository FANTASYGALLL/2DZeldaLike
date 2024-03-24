using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class WizardBullet : ZeldaGameController
    {
        private IEnemiesModel mEnemyModel;

        
        [HideInInspector] public int id;


        [SerializeField] private float bulletSpeed = 3;

        private int hunt = 1;

        public GameObject BulletEffect;

       
        
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
       

        public void Update()
        {
            if (id == 0)
                transform.Translate(-bulletSpeed * Time.deltaTime, bulletSpeed * Time.deltaTime, 0);
            if (id == 1)
                transform.Translate(bulletSpeed * Time.deltaTime, bulletSpeed * Time.deltaTime, 0);
            //if (id == 2)
                //transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
            if (id == 3)
                transform.Translate(-bulletSpeed * Time.deltaTime, -bulletSpeed * Time.deltaTime, 0);
            if (id == 4)
                transform.Translate(bulletSpeed * Time.deltaTime, -bulletSpeed * Time.deltaTime, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Wall"))
            {
                Instantiate(BulletEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if(other.gameObject.tag == "Player")
            {
                Instantiate(BulletEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            
               this.SendCommand(new AttackPlayerCommand(hunt));
            }
        }
    }

}