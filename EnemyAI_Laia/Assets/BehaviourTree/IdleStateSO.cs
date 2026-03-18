using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "Scriptable Objects/IdleState")]
public class IdleStateSO : NodeSO
{
    public override bool OnEndCondition(EnemyBehaviour eb)
    {
        return eb.chaseRange.check || eb.dead.check;   
    }
    public override bool StateCondition(EnemyBehaviour eb)
    {
        return true;
    }
    public override void OnStart(EnemyBehaviour eb)
    {
    }
    public override void OnFinish(EnemyBehaviour eb)
    {
    }
    public override void OnUpdate(EnemyBehaviour eb)
    {
        if (OnEndCondition(eb))
        {
            OnFinish(eb);
            eb.SelectState();
        }
    }
}
