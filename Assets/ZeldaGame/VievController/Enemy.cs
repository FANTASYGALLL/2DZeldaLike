using UnityEngine;
using QFramework;



namespace ZeldaGame2D{
    
    enum EnemyState{Gruard , Finded}

    public class Enemy : ZeldaGameController
    {
        

        [Header("属性")]
        public float Speed ; //速度 
        public int Attack ;  //攻击力
        private Transform Target; // 获取Player的位置
        public int HP; //血量

        private EnemyState enemyState;
        private Trigger2DCheck mWallCheck;
        [Header("Music")]
        private AudioSource au;
        public AudioClip Death;

       
        private SpriteRenderer sp;

         [Header("shader")]
        public float hurtLength;
        private float hurtCounter;
        private Rigidbody2D mrigidbody;
        
        private bool canAttack = true;

        
         
        // Start is called before the first frame update
        void Start()
        {
             mWallCheck = transform.Find("WallCheck").GetComponent<Trigger2DCheck>();
             mrigidbody = GetComponent<Rigidbody2D>();
             Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
             sp = GetComponent<SpriteRenderer>();
             enemyState = EnemyState.Gruard;
             au = GetComponent<AudioSource>();
             
 
        }
        // Update is called once per frame
        void Update()
        {
            SwitchState();
            //FollowPlayer();

            if(hurtCounter <=0)
            {
                sp.material.SetFloat("_FlashAmount",0);
            }else hurtCounter -= Time.deltaTime;
        }
        public void Attacked()
        {
            if(canAttack){
            HuterShader();
                au.Play();
            if(HP>0){
                
                HP--;
                canAttack = false;
                this.GetSystem<ITimeSystem>().AddDelayTask(1.0f , ()=> {canAttack  = true;});
            }
            else{
                    au.clip = Death;
                    au.Play();
                    Destroy(gameObject,0.2f);
                }
            }
        }


        private void FollowPlayer() // 准随Player
        {
            mrigidbody.velocity = Vector2.zero;
             transform.position = Vector3.MoveTowards(transform.position ,Target.position, Speed * Time.deltaTime);
        }
    
        private void HuterShader()
        {
            sp.material.SetFloat("_FlashAmount",1);
            hurtCounter =hurtLength;
        }

        public void SwitchState()
        {
            switch(enemyState)
            {
                case EnemyState.Gruard:
                    NotFollow();
                    break;
                case EnemyState.Finded:
                    FollowPlayer();
                    break;
            }
        }

        public  void NotFollow()
        {
              var scaleX = transform.localScale.x;

            if (mWallCheck.Triggered )
            {
               
                var localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
            else
            {
                mrigidbody.velocity = new Vector2(scaleX * 2, mrigidbody.velocity.y);
                UnityEngine.Debug.Log("Runssd");
            }
        }

        /// <summary>
        /// Sent when another object enters a trigger collider attached to this
        /// object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag=="Player")
            {
                enemyState = EnemyState.Finded;
            }
        }


        /// <summary>
        /// Sent when another object leaves a trigger collider attached to
        /// this object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
           //private void OnTriggerExit2D(Collider2D other)
           //{
           //    if(other.tag=="Player")
           //    {
           //        enemyState = EnemyState.Gruard;
           //    }
           //} 
        /// <summary>
        /// This function is called when the MonoBehaviour will be destroyed.
        /// </summary>
        private void OnDestroy()
    {
        
    }

        
    }

   
}