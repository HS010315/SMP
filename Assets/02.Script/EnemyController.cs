using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
    public Transform player;
    public float minDistance = 2.0f;
    public float moveSpeed = 1.0f;
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
            animator.SetBool("Walk",true);
        }
        else
        {
            animator.SetBool("Walk",false);
        }
    }
}