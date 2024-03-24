using QFramework;
using UnityEngine;


namespace ZeldaGame2D{

public class ClosedAttack : ZeldaGameController
{
    private IEnemiesModel mEnemyModel;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        mEnemyModel = this.GetModel<IEnemiesModel>();
    }
    void Start()
    {
        
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.SendCommand(new AttackPlayerCommand(mEnemyModel.attack.Value));
        }
    }

}

}
