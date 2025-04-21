using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 moveInput;

    private float move;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        //move = Input.GetAxis("Horizontal");
        //rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
