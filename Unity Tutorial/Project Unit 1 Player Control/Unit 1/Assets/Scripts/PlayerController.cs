using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variable
    private float speed = 10.0f;
    private float turnSpeed = 30.0f;
    private float forwardInput;
    private float sidewaysInput;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move vehicle forward
        sidewaysInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime *speed * forwardInput);
        if (forwardInput == +1 | forwardInput == -1)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * sidewaysInput);
        }
    }
}
