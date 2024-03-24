using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace ZeldaGame2D{

    public class NextLevel : ZeldaGameController
    {

        public string nextScene;
        private Collider2D mcollider;
        public int LockLevel;
        public int LockSkill;
       
       

        // Start is called before the first frame update
        void Start()
        {
            mcollider =GetComponent<Collider2D>();

        }

       /// <summary>
       /// Sent when another object enters a trigger collider attached to this
       /// object (2D physics only).
       /// </summary>
       /// <param name="other">The other Collider2D involved in this collision.</param>
       private void OnTriggerEnter2D(Collider2D other)
       {
            if(other.CompareTag("Player"))
            {
                SceneManager.LoadScene(nextScene.ToString());
                GameManager.instance.LockLevel(LockLevel);

                GameManager.instance.GetSkill(LockSkill);

            //    MoveMoent.instace.transform.position = gameObject.transform.Find("bronPoint").position;
            }
       }
        // Update is called once per frame
        void Update()
        {
            
        }

       
    }

}