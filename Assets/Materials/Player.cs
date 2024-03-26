using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Requires User input
    //Left mouse click

    //fire raycast from the main camera or the mouse position
    //Access the object that we hit

    //change color

    ////int layerMask = 1 << 6;

    ////[SerializeField] private GameObject _cube;

    ////private void Update()
    ////{
    ////    if (Input.GetMouseButtonDown(0))
    ////    {
    ////        RaycastHit hit;

    ////        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
    ////        {
    ////            Debug.Log("Raycast has been hit and clicked");
    ////            ChangeColor();
    ////        }
    ////    }
    ////}

    //////Coro change method
    ////private void ChangeColor()
    ////{
    ////    _cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    ////}



    private void Start()
    {
        
    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                var hitRenderer = hitInfo.collider.GetComponent<MeshRenderer>();

                if (hitRenderer == null)
                {
                    return;
                }

                switch (hitInfo.collider.tag)
                {
                    case "Cube":
                        hitRenderer.material.color = Random.ColorHSV();
                        break;
                    case "Sphere":
                        //Do Nothing
                        break;
                    case "Plane":
                        hitRenderer.material.color = Color.black;
                        break;
                }
                //Debug.Log("Hit: " + hitInfo.collider.name);
                ////hitInfo.collider.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

                //var hitObject = hitInfo.collider.GetComponent<MeshRenderer>();

                //if (hitObject.CompareTag("Cube"))
                //{
                //    hitObject.material.color = Random.ColorHSV();

                //}

                //if (hitObject.CompareTag("Plane"))
                //{
                //    hitObject.material.color = Color.black;
                //}

                //if (hitObject.GetComponent<MeshRenderer>() != null)
                //{
                //    hitObject.material.color = Random.ColorHSV();
                //}
            }
        }
    }

}
