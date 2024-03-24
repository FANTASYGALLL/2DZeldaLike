﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D {

    

    [RequireComponent(typeof(Animator))]
    public class Wizard : ZeldaGameController
    {
        public GameObject bulletPrefab;

        private IEnemiesModel mEnemyModel;
        private Animator anim;
        private Transform target;

        private bool canMove;

      //  private Trigger2DCheck mWallCheck;

      //  private Rigidbody2D mrigidbody;

        //怪物的巡逻逻辑
        // private EnemyState enemyState;

        //TODO Totally similiar with Enemy script, LATER interface or inheritence

        [SerializeField] private float moveSpeed = 1.0f;
        [SerializeField] private int maxHp;
        public int hp;

        [Header("Hurt")]
        private SpriteRenderer sp;
        public float hurtLength;//MARKER How Long the hurt Shader Effects
        private float timeBtwHurt;//MARKER Hurt Counter

        [HideInInspector] public bool isAttacked;
        [SerializeField] private GameObject explosionEffect;
        public GameObject DropItem;

        public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }

        public GameObject bulletEffect;

        private void Start()
        {
            mEnemyModel = this.GetModel<IEnemiesModel>();
            anim = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            StartCoroutine(StartAttackCo());
        //     enemyState = EnemyState.Gruard;
         //    mWallCheck = transform.Find("WallCheck").GetComponent<Trigger2DCheck>();
          //   mrigidbody = GetComponent<Rigidbody2D>();


            hp = maxHp;
            sp = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(canMove)
                Move(); 

               

           Flip();

            timeBtwHurt -= Time.deltaTime;
            if (timeBtwHurt <= 0)
                sp.material.SetFloat("_FlashAmount", 0);
        }

        //MARKER This function will be called inside Animation Certain FRAME
        public void Attack()
        {
            GameObject bullet_0 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_0.GetComponent<WizardBullet>().id = 0;

            GameObject bullet_1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_1.GetComponent<WizardBullet>().id = 1;

            //GameObject bullet_2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //bullet_2.GetComponent<WizardBullet>().id = 2;

            GameObject bullet_3 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_3.GetComponent<WizardBullet>().id = 3;

            GameObject bullet_4 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_4.GetComponent<WizardBullet>().id = 4;

            canMove = true;

            StartCoroutine(StartAttackCo());
        }

        IEnumerator StartAttackCo()
        {
            yield return new WaitForSeconds(2f);
            canMove = false;
            anim.SetTrigger("Attack");
            Debug.Log("Start Attack");
        }

        private void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        private void Flip()
        {
            if (transform.position.x < target.position.x)
                transform.eulerAngles = new Vector3(0, 0, 0);
            if (transform.position.x > target.position.x)
                transform.eulerAngles = new Vector3(0, 180, 0);
        }

       

     


        public void TakenDamage(int _amout)
        {
           
            StartCoroutine(isAttackCo());
            HurtEffect();
            UnityEngine.Debug.Log("runs");
            if(hp>0)
            {
                hp -=_amout;
            }
            else
            {
                Instantiate(DropItem, transform.position, Quaternion.identity);
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
               
                Destroy(gameObject);
            }
            
        }

        private void HurtEffect()
        {
            sp.material.SetFloat("_FlashAmount", 1);
            timeBtwHurt = hurtLength;
        }

        IEnumerator isAttackCo()
        {
            yield return new WaitForSeconds(0.2f);
            isAttack = false;
        } 

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Instantiate(bulletEffect, transform.position, Quaternion.identity);
               // this.SendCommand(new AttackPlayerCommand(mEnemyModel.attack.Value));
    
            }
        }
    }

}