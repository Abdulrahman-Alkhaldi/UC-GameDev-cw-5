using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public int dir;
    public float speed;
    public Rigidbody2D RB;
    public GameObject LeftTrigger;
    public GameObject RightTrigger;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        dir = 1;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = Vector2.right * speed * dir;
        if (dir > 0)
        {
            Collider2D check = Physics2D.OverlapBox(RightTrigger.transform.position, Vector2.one * 0.25f,0f);
            if (check == null || check.tag != "Ground")
            {
                dir = -dir;
            }
        }
        else if (dir < 0)
        {
            Collider2D check = Physics2D.OverlapBox(LeftTrigger.transform.position, Vector2.one * 0.25f, 0f);
            if (check == null || check.tag != "Ground")
            {
                dir = -dir;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level1");
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {   if (collision.gameObject.tag == "Ground")
        {
            dir = -dir;
        }

        
    }*/

}
