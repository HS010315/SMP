using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float chargeTime = 1f; 
    public float MagicSpeed = 10f; 
    public float SingUlarity = 5f;
    public GameObject bhPrefab; 
    public GameObject fbPrefab; 
    public Transform shootPoint; 
    private Animator animator;

    private bool isCharging = false; 
    private float chargeTimer = 0f; 
    public Transform player;
    public Slider gauge;

    void Start() 
    {
        animator = GetComponent<Animator>();
        gauge.value = (float) chargeTimer / (float) chargeTime;    
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            StartCharge();
            Debug.Log("Start");
            gaugeControll();
        }

        if (Input.GetMouseButtonUp(1) && isCharging)
        {

            EndCharge();
            Debug.Log("End");
         
        }
        if(Input.GetMouseButtonDown(0) && !isCharging)
        {
            FireFB();
            animator.SetTrigger("Magic");
        }

        if(Input.GetMouseButtonDown(0) && isCharging)
        {
            if (chargeTimer >= chargeTime)
                {
                    FireBH();
                    animator.SetTrigger("BH");
                }
            else
                {
                    FireFB();
                    animator.SetTrigger("Magic");
                }
        }
    }
    private void gaugeControll()
    {
        gauge.value = (float) chargeTimer / (float) chargeTime;
    }


    void StartCharge()
    {
        isCharging = true;
        animator.SetBool("Spell",true);
    }

    void EndCharge()
    {
        isCharging = false;
        animator.SetBool("Spell",false);   
        chargeTimer = 0f;
    }
    void FixedUpdate()
{
    if (isCharging)
    {
        chargeTimer += Time.deltaTime;
    }
}

    void FireBH()
    {
        GameObject bh = Instantiate(bhPrefab, shootPoint.position, Quaternion.identity);
        Vector3 direction = player.forward;
        bh.GetComponent<Rigidbody>().velocity = direction * SingUlarity;
        chargeTimer = 0f;
    }

    void FireFB()
    {
        GameObject fb = Instantiate(fbPrefab, shootPoint.position, Quaternion.identity);
        Vector3 direction = player.forward;
        fb.GetComponent<Rigidbody>().velocity = direction * MagicSpeed;
        Destroy(fb, 3f);
    }
}
