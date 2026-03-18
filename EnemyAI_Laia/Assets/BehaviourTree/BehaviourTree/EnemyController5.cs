using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyController5 : MonoBehaviour
{
    public Conditions5 attack;
    public Conditions5 chase;
    public Conditions5 die;
    public Conditions5 run;
    public GameObject target;
    public float AttackDistance;
    public int HP = 5;
    public NodeSO5 root;
    public NodeSO5 currentState;
    private void Awake()
    {
        attack = new Conditions5("Attack");
        chase = new Conditions5("Chase");
        die = new Conditions5("Dead");
        run = new Conditions5("Run");
        AttackDistance = GetComponent<SphereCollider>().radius / 2f;
        ChangeState();
    }
    private void OnTriggerEnter2D(Collider collision)
    {
        chase.check = true;
        target = collision.gameObject;
    } 
    private void OnTriggerExit2D(Collider collision)
    {
        chase.check = false;
    }
    private void OnTriggerStay2D(Collider collision)
    {
        attack.check = (target.transform.position-transform.position).magnitude <= AttackDistance;
    }
    private void OnCollisionEnter2D(Collision collision)
    {
        OnHurt();
    }
    public void OnHurt()
    {
        HP--;
        if (HP < 2)
            run.check = true;
        if (HP <= 0)
        {
            die.check = true;
        }
    }
    private void Update()
    {
        currentState.OnUpdate(this);
    }
    public void ChangeState()
    {
        StartCoroutine(WaitToTheEndOfFrame());
    }
    private IEnumerator WaitToTheEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        foreach (var node in root.children)
        {
            if (node.EnterCondition(this))
            {
                if (currentState != null)
                    currentState.OnExit(this);
                currentState = node;
                node.OnStart(this);
                break;
            }
        }
    }
}
