using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorTest : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray rayOrigin  = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Hit: " + hitInfo.collider.name);
                Instantiate(_spherePrefab, hitInfo.point, Quaternion.identity);
            }
        }

        LayerMask mask = LayerMask.GetMask("Enemy");
        


    }
}
