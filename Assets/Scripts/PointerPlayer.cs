using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _targetDestination;

    void Update()
    {
        var distance = Vector3.Distance(_targetDestination, transform.position);

        if (distance > 1.0f)
        {
            var direction = _targetDestination - transform.position;
            direction.Normalize();

            transform.Translate(direction * 3.0f * Time.deltaTime);
        }
    }

    public void UpdateDestination(Vector3 pos)
    {
        pos.y = 0.5f;
        _targetDestination = pos;
    }
}
