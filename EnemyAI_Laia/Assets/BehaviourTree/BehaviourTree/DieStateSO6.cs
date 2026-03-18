using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DieState5", menuName = "Scriptable Objects/DieState5")]
public class DieStateSO5 : NodeSO5
{
    public override bool EnterCondition(EnemyController5 ec)
    {
        return ec.die.check;
    }
    public override bool ExitCondition(EnemyController5 ec)
    {
        return !ec.die.check;
    }
    public override void OnStart(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.die.name, ec.die.check);
    }
    public override void OnUpdate(EnemyController5 ec)
    {
        base.OnUpdate(ec);
        Debug.Log("te me explotaste el ano");

    }
    public override void OnExit(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.die.name, ec.die.check);
    }
}
