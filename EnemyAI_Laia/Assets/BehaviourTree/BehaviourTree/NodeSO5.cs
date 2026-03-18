using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NodeState5", menuName = "Scriptable Objects/NodeState5")]
public class NodeSO5 : ScriptableObject
{
    public List<NodeSO5> children;
    public virtual bool EnterCondition(EnemyController5 ec)
    {
        return true;
    }
    public virtual bool ExitCondition(EnemyController5 ec)
    {
        return true;
    }
    public virtual void OnStart(EnemyController5 ec)
    {

    }
    public virtual void OnUpdate(EnemyController5 ec)
    {
        if (ExitCondition(ec))
            ec.ChangeState();
    }
    public virtual void OnExit(EnemyController5 ec)
    {

    }
}
