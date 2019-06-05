using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SchimAI : MonoBehaviour
{
    public enum SchimStates { Idle, Run }
    public SchimStates state;

    public float runRange = 5;
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
        state = SchimStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteState();
    }

    private void ExecuteState()
    {

        if (CheckPlayerInRange(runRange))
        {
            state = SchimStates.Run;
        }

        switch (state)
        {
            case SchimStates.Run:
                RunState();
                break;
            case SchimStates.Idle:
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

    private void RunState()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1 * speed * Time.deltaTime);
        //Vector2 awayFromPlayerDirection = transform.position - player.transform.position;

        if (!CheckPlayerInRange(runRange * 1.5f))
        {
            SwitchState(SchimStates.Idle);
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

    public void SwitchState(SchimStates newState)
    {
        state = newState;
    }
}
