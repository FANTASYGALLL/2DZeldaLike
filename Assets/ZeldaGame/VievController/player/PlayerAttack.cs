using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class PlayerAttack : ZeldaGameController
    {

        public bool isAttack = true;
        public GameObject SwordWind;
        private AudioSource au ; 

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            au = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if(isAttack){
                if (Input.GetMouseButtonDown(0) && !GameManager.instance.Skill[1])
                {
                    Attack();
                    isAttack = false;
                    au.Play();
                    this.GetSystem<ITimeSystem>().AddDelayTask(0.5f, ()=> {isAttack = true;});
                
                }

                else if(Input.GetMouseButtonDown(0) && GameManager.instance.Skill[1] && this.GetModel<IPlayerModel>().HP.Value ==3)
                {
                   var Wind =  Instantiate(SwordWind,transform.position, transform.rotation);
                   Wind.transform.localScale = gameObject.transform.localScale;
 
                     isAttack = false;
                    au.Play();
                    this.GetSystem<ITimeSystem>().AddDelayTask(0.5f, ()=> {isAttack = true;});
                }

                else if (Input.GetMouseButtonDown(0) && GameManager.instance.Skill[1] && this.GetModel<IPlayerModel>().HP.Value !=3)
                {
                    Attack();
                    isAttack = false;
                    au.Play();
                    this.GetSystem<ITimeSystem>().AddDelayTask(0.5f, ()=> {isAttack = true;});
                
                }

                

            }
        }

        private void Attack()
        {
            transform.GetChild(0).gameObject.SetActive(true);

            //Mouse Direction = mouse Pos - current player pos 鼠标位置「目标点位置」-当前位置「人物所在位置」
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree 弧度转角度
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

            public void SetAttack()
        {
            isAttack =true;
        }

        public void SetUnAttack()
        {
            isAttack = false;
        }
    }

    

}