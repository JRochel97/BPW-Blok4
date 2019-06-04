using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SchimAI : MonoBehaviour
{
    public enum EnemyStates { Idle, Panic }
    public EnemyStates state;

    public float panicRange = 5;
    public float speed = 3;

    private float waitTimer;
    public GameObject player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        waitTimer = Random.Range(3, 5);
        state = EnemyStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteState();
    }

    private void ExecuteState()
    {

        if (CheckPlayerInRange(panicRange))
        {
            state = EnemyStates.Panic;
        }

        switch (state)
        {
            case EnemyStates.Panic:
                PanicState();
                break;
            case EnemyStates.Idle:
                IdleState();
                break;
        }
    }

    private bool CheckPlayerInRange(float range)
    {
        return Vector3.Distance(player.transform.position, transform.position) < range;
    }

    private void IdleState()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0)
        {
            waitTimer = Random.Range(1, 999999999);
            //SwitchState(EnemyStates.Patrol);
        }
    }

    private void PanicState()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1 * speed * Time.deltaTime);
        //Vector2 awayFromPlayerDirection = transform.position - player.transform.position;

        if (!CheckPlayerInRange(panicRange * 1.5f))
        {
            SwitchState(EnemyStates.Idle);
        }
    }

    public void MoveToTarget(Transform target)
    {
        agent.SetDestination(target.transform.position);
    }

    public void MoveToTarget(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void SwitchState(EnemyStates newState)
    {
        state = newState;
    }
}
