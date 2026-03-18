using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState", menuName = "Scriptable Objects/AttackState")]
public class AttackStateSO : NodeSO
{
    public override bool OnEndCondition(EnemyBehaviour eb)
    {
        return !eb.attackRange.check || eb.dead.check;
    }
    public override bool StateCondition(EnemyBehaviour eb)
    {
        return eb.attackRange;
    }
    public override void OnStart(EnemyBehaviour eb)
    {
        eb.GetComponent<Animator>().SetBool(eb.attackRange.name, eb.attackRange.check);
    }
    public override void OnFinish(EnemyBehaviour eb)
    {
        eb.GetComponent<Animator>().SetBool(eb.attackRange.name, eb.attackRange.check);
    }
    public override void OnUpdate(EnemyBehaviour eb)
    {
        if(OnEndCondition(eb))
        {
            OnFinish(eb);
            eb.SelectState();
        }
    }
}