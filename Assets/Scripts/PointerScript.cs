using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerScript : MonoBehaviour
{
    [SerializeField] private PointerPlayer _player;
    void Start()
    {
        _player = FindObjectOfType<PointerPlayer>();
        if (_player == null)
        {
            Debug.Log("Failed to find the Player");
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.name == "Floor")
                {
                    _player.UpdateDestination(hitInfo.point);
                }
            }
        }
    }
}
