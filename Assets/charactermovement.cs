using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public Camera cam;
    public CharacterController controller;

    Vector3 forward;
    Vector3 right;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = GetComponent < CharacterController >();
        forward = cam.transform.forward;
        right = cam.transform.right;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovementVars();
        Vector2 v = GetInput();
        controller.Move((v.y * forward + v.x * right)*movementSpeed*Time.deltaTime);
    }

    Vector2 GetInput()
    { Vector2 inp = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            inp.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inp.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inp.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inp.x += 1;
        }
        return inp;

    

    }

    void UpdateMovementVars()
    {
        forward = cam.transform.forward;
        right = cam.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized; 

    }
}
