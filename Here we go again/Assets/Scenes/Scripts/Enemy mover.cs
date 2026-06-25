using NUnit.Framework.Internal.Filters;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemymover : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform player;


    [Header("settings")]
    [SerializeField] private float patrolWaitTime = 2f;
    [SerializeField] private float StopAtDistance = 0.5f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float viewAngle = 90f;
    [SerializeField] private float losePlayerTime = 3f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private int _currentPatrolIndex;
    private bool _isWaiting;
    private EnemyState _state = EnemyState.Patrolling;
    private float _timeSinceLostPlayer;
    private bool _isAttacking;




    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public enum EnemyState
    {
        Patrolling,
        Following,
        Attacking
    }

    private void Attack()
    {
        _agent.isStopped = true;
        var direction = (player.position - transform.position).normalized;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    private void Start()
    {
        GoToNextPatrolPoint();
    }

    private void OnAttackAnimationEnd()
    {
        _isAttacking = false;
    }

    private void GoToClosestPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        var ClosestIndex = 0;
        var ClosestDistance = float.MaxValue;

        for (var i = 0; i < patrolPoints.Length; i++)
        {  var distance = Vector3.Distance(transform.position, patrolPoints[i].position);
            ClosestDistance = distance;
            ClosestIndex = i;
        }

        _currentPatrolIndex = ClosestIndex;
        _agent.SetDestination(patrolPoints[_currentPatrolIndex].position);
    }

    private void Update()
    {
        var distanceToPlayer = Vector3.Distance(player.position, transform.position);

        switch (_state)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (distanceToPlayer <= detectionRange && CanSeePlayer())
                {
                    _state = EnemyState.Following;
                }

                break;

              
                case EnemyState.Following:
                FollowPlayer();
                if (distanceToPlayer <= isAttacking())
                {
                    _state = EnemyState.Attacking;
                    StartAttack();
                    break;
                }



                if (!CanSeePlayer())
                {
                    _timeSinceLostPlayer += Time.deltaTime;
                    if (_timeSinceLostPlayer >= losePlayerTime)
                    {
                        _state = EnemyState.Patrolling;
                        GoToClosestPatrolPoint();

                    }
                    else
                    {
                        _timeSinceLostPlayer = 0f;
                    }
                    
                    break;
                }

                case EnemyState.Attacking:
                StartAttack();
                if (_isAttacking && distanceToPlayer > _isAttacking)
                {
                    _state = EnemyState.Following;
                        _agent.isStopped = false;
                }
                break;
                UpdateAnimations();

             

                
        }

       
    }

    private void FollowPlayer()
    {
        _agent.SetDestination(player.position);
    }

    private void StartAttack()
    {
        _agent.isStopped = false;
        _isAttacking = true;
        _animator.SetTrigger(StartAttack);
    }


    private void Patrol()
    {
        if (_isWaiting) return;
        if (!_agent.pathPending && _agent.remainingDistance <= StopAtDistance)
        {
            StartCoroutine(WaitAtpatrolPoint());
        }
    }

    private IEnumerator WaitAtpatrolPoint()
    {
        _isWaiting = true;
        _agent.isStopped = true;

        yield return new WaitForSeconds(patrolWaitTime);

        _agent.isStopped = false;
        GoToNextPatrolPoint();
        _isWaiting = false;
    }

    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        _agent.SetDestination(patrolPoints[_currentPatrolIndex].position);
        _currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Length;
    }

    private void UpdateAnimations()
    {
        var isWalking = _agent.velocity.sqrMagnitude > 0.01f;
        _animator.SetBool("IsWalking", isWalking);
    }

    private bool CanSeePlayer()
    {
        return IsFacingPlayer() && HasClearPathToPlayer();
    }

    private bool IsFacingPlayer()
    {
        var dirToPlayer = (player.position - transform.position).normalized;
        var angle = Vector3.Angle(transform.forward, dirToPlayer);
        return angle <= viewAngle / 2f;
    }

    private bool HasClearPathToPlayer()
    {
        var dirToPlayer = player.position - transform.position;

        if (Physics.Raycast(transform.position, dirToPlayer.normalized, out RaycastHit hit, dirToPlayer.magnitude))
        {
            return hit.transform == player;
        }

        return true;


    }

}



