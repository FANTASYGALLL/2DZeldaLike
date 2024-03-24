using QFramework;


namespace ZeldaGame2D{

    public class OpenDorrCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<OpenDoorEvent>();
        }
    }

}