using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    enum AIState
    {
        Idle, Patrolling, chasing
    }

    [Header("Patrol")]
    [SerializeField] private Transform Waypoints;
    [SerializeField] private float waitAtPoint;
    private int currentWaypoint;
    private float waitCounter;

    [Header("Components")]
    NavMeshAgent agent;

    [Header("AI states")]
    [SerializeField] private AIState currentState;

    [Header("Chasing")]
    [SerializeField] private float chaseRange;

    [Header("Suspicious")]
    [SerializeField] private float suspiciousTime;
    private float timeSinceLastSawPlayer;

    private GameObject player;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        waitCounter = waitAtPoint;
        timeSinceLastSawPlayer = suspiciousTime;
            
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case AIState.Idle:

                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.Patrolling;
                    agent.SetDestination(Waypoints.GetChild(currentWaypoint).position);
                }

                if(distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.chasing;
                }

                break;


            case AIState.Patrolling:

                if (agent.remainingDistance <= 0.2f)
                {
                    currentWaypoint++;
                    if (currentWaypoint >= Waypoints.childCount)
                    {
                        currentWaypoint = 0;
                    }
                    currentState = AIState.Idle;
                    waitCounter = waitAtPoint;
                }

                if (distanceToPlayer <= chaseRange)
                {

                    currentState = AIState.chasing;
                }

                break;


            case AIState.chasing:
                agent.SetDestination(player.transform.position);
                if (distanceToPlayer > chaseRange)
                {
                    agent.isStopped = true;
                    agent.velocity = Vector3.zero;
                    timeSinceLastSawPlayer -= Time.deltaTime;

                    if (timeSinceLastSawPlayer < 0)
                    {
                        currentState = AIState.Idle;
                        timeSinceLastSawPlayer = suspiciousTime;
                        agent.isStopped = false;

                    }
                }

                break;









        }

    }








}
