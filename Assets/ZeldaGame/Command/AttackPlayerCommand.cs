using QFramework;
using UnityEngine.SceneManagement;


namespace ZeldaGame2D{

public class AttackPlayerCommand : AbstractCommand
{
    private int mhurt;
    public AttackPlayerCommand(int hurt)
    {   
        mhurt = hurt;
    }
    protected override void OnExecute()
    {
        var palyermodel = this.GetModel<IPlayerModel>();
        if(palyermodel.CanHurted.Value==true && palyermodel.HP.Value >0){
                palyermodel.HP.Value -= mhurt;
                palyermodel.CanHurted.Value = false;
                this.GetSystem<ITimeSystem>().AddDelayTask(2.0f,() =>{palyermodel.CanHurted.Value = true;} );
            }
        

        
        UnityEngine.Debug.Log("attacked HP = " + palyermodel.HP.Value);
        if(palyermodel.HP.Value <=0)
        {
            SceneManager.LoadScene("GameOver");
            
        }
    }
}


}