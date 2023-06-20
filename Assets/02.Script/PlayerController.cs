using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    Rigidbody rigid;
    public float maxhp = 100;
    private float nowhp = 100;
    public float jumpForce = 1.0f;
    public float walk = 1.0f;
    public float dash = 1.0f;
    private float nowSpeed;

    private Vector3 dir = Vector3.zero;
    private PlayerController controller;
    public Slider hpbar;




    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
        nowSpeed = walk;
        hpbar.value = (float) nowhp / (float) maxhp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("runningenemy"))
        {
            nowhp -= 10;
        }
        HandleHp();
    }
        private void HandleHp()
    {
        hpbar.value = (float) nowhp / (float) maxhp;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jump = Vector3.up * jumpForce;
            rigid.AddForce(jump, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            nowSpeed = dash;
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            nowSpeed = walk; 
        }
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir = transform.forward * dir.z + transform.right * dir.x;
        rigid.MovePosition(this.gameObject.transform.position + dir*nowSpeed*Time.deltaTime);

        if (nowhp <= 0)
        {
            SceneManager.LoadScene("FailScene");
        } 
    }
}

