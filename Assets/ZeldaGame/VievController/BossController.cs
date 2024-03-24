using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

namespace ZeldaGame2D{

      public enum BossState
        {
            Idle ,
            AttackPlayer,

            WitchMode
        }

    public class BossController : ZeldaGameController
    {

        public BossState bossState;
        public GameObject[] EnemiesPrefab;

        public GameObject bulletEffect;
        [Header("Hrut")]
        private SpriteRenderer sp;
        public float hurtLength;
        private float hurtCounter;

        [Header("属性")]
        public int Hp;
        private int MaxHP = 50;
        public float speed;

        private Transform target;

        private bool canMove;

        [HideInInspector] public bool isAttacked;

        public Image HealthUI;
        private bool canAttacked = true;

        /// <summary>
        /// 追击时间 单位：s
        /// </summary>
        public float attackTime = 10;
        /// <summary>
        /// 召唤时间 单位：s
        /// </summary>
        public float witchTime = 10;

        /// <summary>
        /// 当前状态开始时间
        /// </summary>
        private float curStateStartTime;
        /// <summary>
        /// 当前状态时长
        /// </summary>
        private float curStateTimeNum;


        // Start is called before the first frame update
        void Start()
        {
            isAttacked = true;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            ChangeState(BossState.AttackPlayer);
            Hp = MaxHP;
            sp = GetComponent<SpriteRenderer>();
            HealthUI = transform.Find("BoosHealthCanvas/ImageRed/ImageGreen").GetComponent<Image>();
        }

        private void ChangeState(BossState state)
        {
            bossState = state;
            curStateStartTime = Time.time;
            switch (state)
            {
                case BossState.AttackPlayer:
                    curStateTimeNum = attackTime;
                    break;
                case BossState.WitchMode:
                    curStateTimeNum = witchTime;
                    break;
                default:
                    curStateTimeNum = 0;
                    break;
            }

        }

        // Update is called once per frame
        void Update()
        {
            SiwtchState();
            Flip();
            CheckChangeState();
            if (hurtCounter <= 0)
            {
                sp.material.SetFloat("_FlashAmount", 0);
            } else hurtCounter -= Time.deltaTime;
        }

        private void CheckChangeState()
        {
            if (Time.time - curStateStartTime >= curStateTimeNum)
            {
                switch (bossState)
                {
                    case BossState.AttackPlayer:
                        ChangeState(BossState.WitchMode);
                        break;
                    case BossState.WitchMode:
                        ChangeState(BossState.AttackPlayer);
                        break;
                    default:
                        ChangeState(BossState.AttackPlayer);
                        break;
                }
            }
        }

        void SiwtchState()
        {
            switch (bossState)
            {
                case BossState.WitchMode:
                    if (isAttacked == true)
                    {
                        SummonEnemy();
                        isAttacked = false;
                    }

                    break;


                case BossState.AttackPlayer:
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    isAttacked = true;
                    break;
            }
        }
        /// <summary>
        /// 召唤怪
        /// </summary>
        private void SummonEnemy()
        {
            var index = Random.Range(0, EnemiesPrefab.Length);
            Instantiate(EnemiesPrefab[index], transform.position, Quaternion.identity);
        }

         private void Flip()
        {
            if (transform.position.x < target.position.x)
                transform.eulerAngles = new Vector3(0, 0, 0);
            if (transform.position.x > target.position.x)
                transform.eulerAngles = new Vector3(0, 180, 0);
        }

        public void BossAttacked(int _Amout)
        {
            if(canAttacked){
            HuterShader();
                if(Hp > 0)
                {
                    Hp -= _Amout;
                    canAttacked = false;
                    this.GetSystem<ITimeSystem>().AddDelayTask(1.0f , ()=> {canAttacked  = true;});

                }

                else 
                {
                    DialogueLua.SetVariable("BossIsDie", true);
                    Destroy(gameObject,1.0f);
                } 
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            var slider = (float)Hp / MaxHP;
            HealthUI.fillAmount = slider;
        }

        private void HuterShader()
        {
            sp.material.SetFloat("_FlashAmount",1);
            hurtCounter =hurtLength;
        }

        
       
    }

}
