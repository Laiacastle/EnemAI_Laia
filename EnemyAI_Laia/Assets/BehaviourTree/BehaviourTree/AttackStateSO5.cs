using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtackState5", menuName = "Scriptable Objects/AtackState5")]
public class AttackStateSO5 : NodeSO5
{
    public override bool EnterCondition(EnemyController5 ec)
    {
        return ec.attack.check;
    }
    public override bool ExitCondition(EnemyController5 ec)
    {
        return !ec.attack.check || ec.run.check;
    }
    public override void OnStart(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.attack.name, ec.attack.check);
    }
    public override void OnUpdate(EnemyController5 ec)
    {
        base.OnUpdate(ec);
        Debug.Log("te reviento el ano");
    }
    public override void OnExit(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.attack.name, ec.attack.check);
    }
}
