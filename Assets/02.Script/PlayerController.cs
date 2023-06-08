using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    Animator animator;
    float jumpForce = 10.0f;
    float walkForce = 3.0f;
    float runForce = 2.0f;
    float maxWalkSpeed = 2.0f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
