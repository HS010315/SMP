using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemyController : MonoBehaviour 
{
    public Transform player;
    public float minDistance = 2.0f;
    public float moveSpeed = 2.0f;
    private Vector3 initialPosition;
    public Animator animator;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > minDistance)
        {
            transform.LookAt(player);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run",false);
        }
    }
}