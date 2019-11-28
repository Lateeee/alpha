using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    public bool isGrounded;
    public float Speed;
    public float jump;
    Rigidbody rb;
    static Animator anim;
    public AudioSource lol;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
       
        PlayerMovement();
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            lol.Play();
            anim.SetInteger("jump", 1);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("jump", 0);

        }
        if (Input.GetKey(KeyCode.W))    
        { 
            anim.SetInteger("walk", 1);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("walk", 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("walk", 2);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("walk", 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("walk", 3);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("walk", 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("walk", 4);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("walk", 0);

        }
     

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            isGrounded = false;

        }
        



    }
}