using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //store the waypoints
    //select a random waypoint
    //travel to the random waypoint

    [SerializeField] private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    private bool _inReverse;

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
        CalculateAIMovement();
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
}
