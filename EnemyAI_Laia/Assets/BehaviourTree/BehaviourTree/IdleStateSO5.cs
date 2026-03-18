using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState5", menuName = "Scriptable Objects/IdleState5")]
public class IdleStateSO5 : NodeSO5
{
    public override bool EnterCondition(EnemyController5 ec)
    {
        return true;
    }
    public override bool ExitCondition(EnemyController5 ec)
    {
        return ec.chase.check || ec.run.check || ec.attack.check;
    }
    public override void OnStart(EnemyController5 ec)
    {
    }
    public override void OnUpdate(EnemyController5 ec)
    {
        base.OnUpdate(ec);
        Debug.Log("me toco el ano");
    }
    public override void OnExit(EnemyController5 ec)
    {
    }
}
