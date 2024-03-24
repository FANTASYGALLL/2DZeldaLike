using UnityEngine;
using QFramework;
using System;
using System.Collections.Generic;

namespace ZeldaGame2D{

    public interface ITimeSystem : ISystem
    {
       float CurrentSeconds {get; }
       void AddDelayTask(float second , Action onDelayFinish);
    }

    public class DelayTask 
    {
        public float Seconds{get; set;}
        public Action OnFinsih{get ; set;}
        public float StartSeconds {get; set;}
        public float FinshSeconds {get; set;}
        public DelayTaskState State {get; set;} 
    }

    public enum DelayTaskState
    {
        NotStart,
        Started,
        Finsih
    }

    public class TimeSystem : AbstractSystem, ITimeSystem
    {
        
        public class TimeSystemUpdateBehaviour : MonoBehaviour
        {
            public event Action OnUpdate;

            /// <summary>
            /// Update is called every frame, if the MonoBehaviour is enabled.
            /// </summary>
            private void Update()
            {
                OnUpdate?.Invoke();
            }
        }

        public float CurrentSeconds {get; private set;} 
        private LinkedList<DelayTask>mDelayTask = new LinkedList<DelayTask>();



        public void AddDelayTask(float seconds, Action onDelayFinish)
        {
            var delayTask = new DelayTask()
            {
                Seconds = seconds,
                OnFinsih = onDelayFinish,
                State = DelayTaskState.NotStart
            };

            mDelayTask.AddLast(delayTask);
            
        }

        protected override void OnInit()
        {
            CurrentSeconds = 0;
            
            var  updateBehaviourGameObj  = new GameObject(nameof(TimeSystemUpdateBehaviour));

            UnityEngine.Object.DontDestroyOnLoad(updateBehaviourGameObj);

            var upadteBehaviour = updateBehaviourGameObj.AddComponent<TimeSystemUpdateBehaviour>();

            upadteBehaviour.OnUpdate += OnUpdate;
            

            
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void OnUpdate()
        {

            CurrentSeconds += Time.deltaTime;

            if(mDelayTask.Count > 0)
            {
               var currentNode = mDelayTask.First;

                while(currentNode != null)
                {
                   
                    var nextNode = currentNode.Next;

                    var delayTask= currentNode.Value;

                    if(delayTask.State == DelayTaskState.NotStart)
                    {
                        delayTask.State = DelayTaskState.Started;
                        delayTask.StartSeconds = CurrentSeconds;
                        delayTask.FinshSeconds = CurrentSeconds +delayTask.Seconds;
                    }else if(delayTask.State == DelayTaskState.Started)
                    {
                        if(CurrentSeconds >= delayTask.FinshSeconds){
                        delayTask.State = DelayTaskState.Finsih;
                        delayTask.OnFinsih();

                        delayTask.OnFinsih = null;

                        mDelayTask.Remove(currentNode);
                        }
                    }
                currentNode = nextNode;
                }

               
            }

        }

        /// <summary>
        /// This function is called when the MonoBehaviour will be destroyed.
        /// </summary>
       
    }

}