using QFramework;
using UnityEngine;

    namespace ZeldaGame2D{
    public class ZeldaGameController : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return ZeldaGame.Interface;
        }

        
    }

}