using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RunState5", menuName = "Scriptable Objects/RunState5")]
public class RunStateSO5 : NodeSO5
{
    public override bool EnterCondition(EnemyController5 ec)
    {
        return ec.run.check;
    }
    public override bool ExitCondition(EnemyController5 ec)
    {
        return !ec.run.check || ec.die.check;
    }
    public override void OnStart(EnemyController5 ec)
    {
        //ec.GetComponent<Animator>().SetBool(ec.chase.name, ec.chase.check);
    }
    public override void OnUpdate(EnemyController5 ec)
    {
        base.OnUpdate(ec);
        ec.GetComponent<ChaseBehaviour>().Chase(ec.transform, ec.target.transform);
        Debug.Log("huyo de tu ano");
    }
    public override void OnExit(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.chase.name, ec.chase.check);
       // ec.GetComponent<ChaseBehaviour>().StopChasing();
    }
}
