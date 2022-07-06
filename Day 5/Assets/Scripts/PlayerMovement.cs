using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D RB;
    public float speed;
    public float jump;
    public bool canJump;
    public Animator animate;
    public SpriteRenderer sprite;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            animate.SetBool("Jump", false);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        jump = 7;
        RB = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") <0)
        {
            sprite.flipX=true;
        }

        Vector2 temp = RB.velocity;
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                temp.y = jump;
                canJump = false;
                animate.SetBool("Jump", true);

            }
        }
        temp.x = Input.GetAxis("Horizontal") * speed;
        RB.velocity = temp;

        //RB.velocity = new Vector2 (Input.GetAxis("Horizontal") * speed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}
