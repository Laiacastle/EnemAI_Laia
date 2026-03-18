using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float AttackRange;
    public int HP;
    public GameObject target;
    public int DamagedHP;
    public bool OnRange = false, OnAttackRange = false;
    private ChaseBehaviour _chaseB;
    //public StateSO currentNode;
// public List<StateSO> Nodes;
    private Animator _animator;
   void Start()
    {
        _chaseB = GetComponent<ChaseBehaviour>();
        AttackRange = GetComponent<SphereCollider>().radius / 2f;
        Debug.Log(AttackRange);
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        /*target = collision.gameObject;
        OnRange = true;
        CheckEndingConditions();*/
        if (collision.gameObject == target)
            _animator.SetBool("Chase", true);
            
    }
    private void OnTriggerExit(Collider collision)
    {
        /*OnRange = false;
        CheckEndingConditions();*/
        if (collision.gameObject == target)
            _animator.SetBool("Chase", false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        /*OnAttackRange = true;
        CheckEndingConditions();*/
        /*if (collision.gameObject == target)
            CurrentState = EnemyStates.Attack;*/

    }
    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.gameObject == target)
            CurrentState = EnemyStates.Chase;*/
       /* OnAttackRange = false;
        CheckEndingConditions();*/
    }
    private void Update()
    {

        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            HP--;
            CheckEndingConditions();
        }
        currentNode.OnStateUpdate(this);*/
    }
    public void Idle()
    {
        _chaseB.StopChasing();
    }
    public void Attack()
    {
        if ((target.transform.position - transform.position).magnitude > AttackRange)
            _animator.SetBool("Attack", false);
        Debug.Log("Te meto una hostia");
    }
    public void CheckIfOnAttackRange()
    {
        if ((target.transform.position - transform.position).magnitude <= AttackRange)
            _animator.SetBool("Attack", true);
        else 
            _animator.SetBool("Attack", false);

    }
    public void Chase()
    {
        _chaseB.Chase(target.transform, transform);

    }
    public void CheckEndingConditions()
    {
      //  foreach (ConditionSO condition in currentNode.EndConditions)
        //    if (condition.CheckCondition(this) == condition.answer) ExitCurrentNode();
    }
   /* public void ExitCurrentNode()
    {
        foreach (StateSO stateSO in Nodes)
        {
            if (stateSO.StartCondition == null)
            {
                EnterNewState(stateSO);
                break;
            }
            else
            {
                if (stateSO.StartCondition.CheckCondition(this) == stateSO.StartCondition.answer)
                {
                    EnterNewState(stateSO);
                    break;
                }
            }
        }
        //currentNode.OnStateEnter(this);
    }*/
   /* private void EnterNewState(StateSO state)
    {
        currentNode.OnStateExit(this);
        currentNode = state;
        currentNode.OnStateEnter(this);
    }*/
}
