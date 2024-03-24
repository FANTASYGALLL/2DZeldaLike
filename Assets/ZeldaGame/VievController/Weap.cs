using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class Weap : ZeldaGameController
    {
        private Collider2D mcollider;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            mcollider = GetComponent<Collider2D>();
        }
       public void End()
       {
            gameObject.SetActive(false);
       }

       /// <summary>
       /// Sent when another object enters a trigger collider attached to this
       /// object (2D physics only).
       /// </summary>
       /// <param name="other">The other Collider2D involved in this collision.</param>
       private void OnTriggerEnter2D(Collider2D other)
       {
            if(other.gameObject.tag == "Enemy")
            {
                var enemy = other.gameObject.GetComponent<Enemy>();
                enemy.Attacked();
                var difference = (other.transform.position - transform.position).normalized *0.3f ;
                other.transform.position = new Vector2(other.transform.position.x + difference.x,
                                                      other.transform.position.y + difference.y);
            }

               else if(other.gameObject.tag == "Wizard")
                {
                    other.gameObject.GetComponent<Wizard>().TakenDamage(1);
                    var different = (other.transform.position - transform.position).normalized;
                    other.transform.position = new Vector2(other.transform.position.x + different.x,
                                                       other.transform.position.y + different.y);
                }

                else if(other.gameObject.tag == "Boss")
                {
                    other.gameObject.GetComponent<BossController>().BossAttacked(1);
                }
            
       }
    }

}

