using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseState5", menuName = "Scriptable Objects/ChaseState5")]
public class ChaseStateSO5 : NodeSO5
{
    public override bool EnterCondition(EnemyController5 ec)
    {
        Debug.Log("CHASE ENTER" + ec.chase.check);
        return ec.chase.check;
    }
    public override bool ExitCondition(EnemyController5 ec)
    {
        return !ec.chase.check || ec.run.check || ec.attack.check;
    }
    public override void OnStart(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.chase.name, ec.chase.check);
    }
    public override void OnUpdate(EnemyController5 ec)
    {
        base.OnUpdate(ec);
        ec.GetComponent<ChaseBehaviour>().Chase(ec.target.transform, ec.transform);
        Debug.Log("te persigo el ano");
        Debug.Log("updateChase");
    }
    public override void OnExit(EnemyController5 ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.chase.name, ec.chase.check);
        ec.GetComponent<ChaseBehaviour>().StopChasing();
        Debug.Log("NO CHASE");
    }
}
