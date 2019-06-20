using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public bool isGrounded = false;

    private bool facingRight;

    public Animator anim;

    void Start()
    {
        facingRight = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
           anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;

            transform.localScale = theScale;
        } if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;

            transform.localScale = theScale;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        }
        
    }

  }
