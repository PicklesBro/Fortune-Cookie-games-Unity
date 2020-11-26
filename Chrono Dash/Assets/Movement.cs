using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public Animator animator;
    public bool facingRight = true;
    public bool grounded = false;
    public float doubleJump = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", horizontalMove);
      
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        
        if (horizontalMove > 0 &&! facingRight)
            Flip();

        else if (horizontalMove < 0 && facingRight)
            Flip();
        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded == true && doubleJump == 2)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
            doubleJump = 1;

            // Double jump

        }

        else if (Input.GetButtonDown("Jump") && doubleJump == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 15f), ForceMode2D.Impulse);
            doubleJump = 2;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector4 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
