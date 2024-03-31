using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShootBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _bulletHole;
    

    void Update()
    {
        //Raycast through the center of the crosshair
        //Instantiate a bullet hole prefab
        //Raycast through the center of the viewprot
        ////if (Input.GetKeyDown(KeyCode.Mouse0))
        ////{
        ////    RaycastHit hitInfo;

        ////    Transform camera = Camera.main.transform;

        ////    if (Physics.Raycast(camera.position, camera.forward, out hitInfo, Mathf.Infinity))
        ////    {
        ////        Instantiate(_bulletHole, hitInfo.point, Quaternion.identity);
        ////    }
        ////}
        ///

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(_bulletHole, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
        
    }

}
