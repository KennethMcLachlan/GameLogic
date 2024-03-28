using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bitwise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left click ray was pressed");
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 7 | 1 << 8))
            {
                Debug.Log("Hit: " + hitInfo.collider.name);
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
