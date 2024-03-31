using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sphere : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _rayDistance = 1f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position, Vector3.down * _rayDistance, Color.blue);
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, _rayDistance))
        {
            Debug.Log("Hit the floor");
            if (hitInfo.collider.name == "Floor")
            {
                _rb.isKinematic = true;
                _rb.useGravity = false;
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawLine(transform.position, Vector3.down * _rayDistance);
    //}
}
