using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeldaGame2D{
public class Range : MonoBehaviour
{
     private void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().Attacked();
            }
            if(other.tag =="Wizard")
            {
                other.gameObject.GetComponent<Wizard>().TakenDamage(100);
            }
            if(other.tag =="Box")
            {
                other.gameObject.SetActive(false);
            }

            if(other.tag == "Boss")
            {
                other.gameObject.GetComponent<BossController>().BossAttacked(10);
            }
        }
}

}