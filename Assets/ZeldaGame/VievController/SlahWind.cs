using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace  ZeldaGame2D{

    public class SlahWind : ZeldaGameController
    {
        private Rigidbody2D mrigid;
       
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            mrigid= GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            var isRight = transform.eulerAngles.y == 0 ? 1 : -1;
            mrigid.velocity = Vector2.right * 10 * isRight;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        

        public  void Speed(Vector2 direction , float force )
        {
             mrigid.AddForce(direction *force);
        }

        /// <summary>
        /// Sent when another object enters a trigger collider attached to this
        /// object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Wall")
            {
                Destroy(gameObject);
            }

            if(other.gameObject.tag == "Enemy")
            {
                var enemy = other.gameObject.GetComponent<Enemy>();
                enemy.Attacked();
                var difference = (other.transform.position - transform.position).normalized * 0.3f;
                other.transform.position = new Vector2(other.transform.position.x + difference.x,
                                                      other.transform.position.y + difference.y);
                Destroy(gameObject);
                                                    }

             else if(other.gameObject.tag == "Wizard")
                {
                    other.gameObject.GetComponent<Wizard>().TakenDamage(1);
                    var different = (other.transform.position - transform.position).normalized;
                    other.transform.position = new Vector2(other.transform.position.x + different.x,
                                                       other.transform.position.y + different.y);
                     Destroy(gameObject);
                }

                else if(other.gameObject.tag == "Boss")
                {
                    other.gameObject.GetComponent<BossController>().BossAttacked(1);
                    Destroy(gameObject);
                }
        }
    }

}