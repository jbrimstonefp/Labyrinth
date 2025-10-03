using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementX_axis;
    public float movementY_axis;
    public float movementZ_axis;
    public float movementSpeed_force = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementZ_axis = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed_force;
        movementX_axis = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed_force;
        
        transform.Translate(movementX_axis, movementY_axis, movementZ_axis);
    }
}
