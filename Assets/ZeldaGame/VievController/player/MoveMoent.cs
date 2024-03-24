using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


namespace ZeldaGame2D{

    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveMoent : ZeldaGameController
        {

        IPlayerModel mplayermodel;

        [Header("Items")]
        public GameObject mboob;
        public bool isMoving  = true;
        private Vector3 prePos;
        private Vector3 moveDir;
        // public static MoveMoent instace;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            /*     if(instace == null){instace = this;}
                else
                {
                    if(instace !=this ){Destroy(gameObject);}
                }

                DontDestroyOnLoad(gameObject);  */
            rb = GetComponent<Rigidbody2D>();

            mplayermodel = this.GetModel<IPlayerModel>();
        }

        private Rigidbody2D rb;
        
        private float moveH, moveV;
        [SerializeField] private float moveSpeed;

        
        private void Update()
        {
            if(isMoving){

                moveH = Input.GetAxis("Horizontal") * moveSpeed;
                moveV = Input.GetAxis("Vertical") * moveSpeed;
                Flip();

            

                if(Input.GetKeyDown(KeyCode.X) && mplayermodel.BoobCount.Value !=0 && GameManager.instance.Skill[0])
                {
                    Instantiate(mboob,gameObject.transform.Find("BoobPoint").position,gameObject.transform.rotation);
                    mplayermodel.BoobCount.Value --;
                }

                if (moveH != 0 || moveV != 0)
                {
                    var move = (prePos - transform.position).normalized;
                    if (move != Vector3.zero)
                    {
                        moveDir = move;
                        prePos = transform.position;
                    }
                }
                    
            }
        }
        private void FixedUpdate()
        {
            if(isMoving)
            rb.velocity = new Vector2(moveH, moveV);
        }

        private void Flip()
        {
            //if (moveH > 0)
            if(transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
                transform.eulerAngles = new Vector3(0, 0, 0);
            //if (moveH < 0)
            if(transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
                transform.eulerAngles = new Vector3(0, 180, 0);
        }

        public void SetMoving()
        {
            isMoving = true;
        }

        public void SetUnMoving()
        {
            isMoving = false;
            rb.velocity  = new Vector2(0,0);
        }
        /// <summary>
        /// »÷ÍË
        /// </summary>
        public void BeAttack()
        {
            transform.position = new Vector2(transform.position.x + moveDir.x,
                                                  transform.position.y + moveDir.y);
        }

        

        

    }

}