using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace ZeldaGame2D{

    public class StatsController : ZeldaGameController
    {
        public GameObject[] healthCount;
        public GameObject[] boobCount;

        private IPlayerModel mplayermodel;
        // Start is called before the first frame update
        void Start()
        {
            mplayermodel = this.GetModel<IPlayerModel>();
        }

        // Update is called once per frame
        void Update()
        {
            SwitchHealth ();
            if(!GameManager.instance.Skill[0])
            {
                transform.Find("OrbsContainer").gameObject.SetActive(false);
            }
            else if(GameManager.instance.Skill[0])
            {
                transform.Find("OrbsContainer").gameObject.SetActive(true);
            }
            SwitchBoob();
        }

        void SwitchHealth ()
        {
            switch(mplayermodel.HP.Value)
            {
                case 3 :
                    foreach(GameObject item in healthCount)
                    {
                        item.SetActive(true);
                    }
                break;

                case 2 :
                    healthCount[0].SetActive(false);
                    healthCount[1].SetActive(true);
                    healthCount[2].SetActive(true);

                break;

                case 1 :
                    healthCount[0].SetActive(false);
                    healthCount[1].SetActive(false);
                    healthCount[2].SetActive(true);

                break;

                case 0 :
                    healthCount[0].SetActive(false);
                    healthCount[1].SetActive(false);
                    healthCount[2].SetActive(false);

                break;
            }

          

            
        }

          void SwitchBoob()
            {
                switch(mplayermodel.BoobCount.Value){
                 case 3 :
                    foreach(GameObject item in boobCount)
                    {
                        item.SetActive(true);
                    }
                break;

                case 2 :
                    boobCount[0].SetActive(false);
                    boobCount[1].SetActive(true);
                    boobCount[2].SetActive(true);

                break;

                case 1 :
                    boobCount[0].SetActive(false);
                    boobCount[1].SetActive(false);
                    boobCount[2].SetActive(true);

                break;

                case 0 :
                     boobCount[0].SetActive(false);
                    boobCount[1].SetActive(false);
                    boobCount[2].SetActive(false);
                break;
                }
            }
    
    }


}