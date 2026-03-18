using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DeadState", menuName = "Scriptable Objects/DeadState")]
public class DeadStateSO : NodeSO
{
    public override bool OnEndCondition(EnemyBehaviour eb)
    {
        return !eb.dead.check;
    }
    public override bool StateCondition(EnemyBehaviour eb)
    {
        return eb.dead.check;
    }
    public override void OnStart(EnemyBehaviour eb)
    {
        eb.GetComponent<Animator>().SetBool(eb.dead.name, eb.dead.check);
    }
    public override void OnFinish(EnemyBehaviour eb)
    {
        eb.GetComponent<Animator>().SetBool(eb.dead.name, eb.dead.check);
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
