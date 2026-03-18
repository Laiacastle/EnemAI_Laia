using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public NodeSO root, currentState;
    private Animator _animator;
    private float _attackDistance;
    public GameObject target;
    public Condition attackRange;
    public Condition chaseRange;
    public Condition dead;
    private int HP = 10;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _attackDistance = GetComponent<SphereCollider>().radius / 2f;
        attackRange = new Condition("Attack");
        chaseRange = new Condition("Chase");
        dead = new Condition("Dead");
        SelectState();
    }
    private void OnTriggerEnter2D(Collider other)
    {
        chaseRange.check = true;
    }
    private void OnTriggerStay2D(Collider other)
    {
        attackRange.check = (target.transform.position - transform.position).magnitude <= _attackDistance;
    }
    private void OnTriggerExit2D(Collider other)
    {
        chaseRange.check = false;
    }
    public void SelectState()
    {
        foreach(var child in root.children)
        {
            if(child.StateCondition(this))
            {
                currentState = child;
                currentState.OnStart(this);
                break;
            }
        }
    }
    public void OnHurt()
    {
        HP--;
        dead.check = HP <= 0;
    }
    private void Update()
    {
        currentState.OnUpdate(this);
        if (Input.GetKeyDown(KeyCode.Space))
            OnHurt();
    }
}
