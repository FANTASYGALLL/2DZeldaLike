using System.Collections;
using UnityEngine;
using QFramework;


namespace ZeldaGame2D{

    public class CameraController : ZeldaGameController
    {

        public static CameraController instance;
        private Transform target;
        [SerializeField] private float SmoothSpeed;

        [SerializeField] private float minX, maxX,minY,maxY;

        
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
           
        
        /*  if(instance == null){instance = this;}
            else
            {
                if(instance !=this ){Destroy(gameObject);}
            }

            DontDestroyOnLoad(gameObject); */
        
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {
            // target = MoveMoent.instace.transform;
            target = GameObject.FindWithTag("Player").transform;
             
        }
        
        /// <summary>
        /// LateUpdate is called every frame, if the Behaviour is enabled.
        /// It is called after all Update functions have been called.
        /// </summary>
        private void LateUpdate()
        {
            target = GameObject.FindWithTag("Player").transform;
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x , target.position.y, transform.position.z), SmoothSpeed *Time.deltaTime);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                            Mathf.Clamp(transform.position.y,minY,maxY), transform.position.z);
        }
        

  
 
       

    }

}