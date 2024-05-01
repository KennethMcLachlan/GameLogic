using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{

    private enum AIState
    {
        Walking,
        Jumping,
        Attack,
        Death
    }
    
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private AIState _currentState;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    private bool _inReverse;
    private bool _attacking;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        if (_agent != null)
        {
            _agent.destination = _wayPoints[_currentPoint].position;
        }
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentState = AIState.Jumping;
            _agent.isStopped = true;
        }

        //Determine current Ai Behavior
        switch (_currentState)
        {
            case AIState.Walking:
                Debug.Log("Walking...");
                CalculateAIMovement();
                break;
            case AIState.Jumping:
                Debug.Log("Jumping...");
                break;
            case AIState.Attack:
                Debug.Log("Attack...");
                if (_attacking == false)
                {
                    StartCoroutine(AttackRoutine());
                    _attacking = true;
                }
                break;
            case AIState.Death:
                Debug.Log("Dead...");
                break;

        }
    }

    private void CalculateAIMovement()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            
            if (_inReverse == true)
            {
                Reverse();
            }
            else
            {
                Forward();
            }

            _agent.SetDestination(_wayPoints[_currentPoint].position);

            _currentState = AIState.Attack;
        }
    }
    private void Forward()
    {
        if (_currentPoint == _wayPoints.Count - 1)
        {
            _inReverse = true;
            _currentPoint--;
        }
        else
        {
            _currentPoint++;
        }
    }

    private void Reverse()
    {
        if (_currentPoint == 0)
        {
            _inReverse = false;
            _currentPoint++;
        }
        else
        {
            _currentPoint--;
        }
    }

    IEnumerator AttackRoutine()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(3.0f);
        _agent.isStopped = false;
        _currentState = AIState.Walking;
        _attacking = false;
    }
}
