using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "Scriptable Objects/ChaseState")]
public class ChaseStateSO : NodeSO
{
    public override bool OnEndCondition(EnemyBehaviour eb)
    { 
        return !eb.chaseRange.check || eb.attackRange.check || eb.dead.check;
    }
    public override bool StateCondition(EnemyBehaviour eb)
    {
        return eb.chaseRange.check;
    }
    public override void OnStart(EnemyBehaviour eb)
    {
        eb.GetComponent<Animator>().SetBool(eb.chaseRange.name, eb.chaseRange.check);
        eb.GetComponent<ChaseBehaviour>().Chase(eb.target.transform, eb.transform);
    }
    public override void OnFinish(EnemyBehaviour eb)
    {
        eb.GetComponent<Animator>().SetBool(eb.chaseRange.name, eb.chaseRange.check);
        eb.GetComponent<ChaseBehaviour>().StopChasing();

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
