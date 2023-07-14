using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 100f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;


    int speed = 7; //스피드
    float xMove, yMove;
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();


        Debug.Assert(playerRigid != null);
        Debug.Assert(animator != null);
        //Debug.Assert(playerAudio != null);
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            //playerAudio.Play();

        }
        else if (Input.GetKeyDown(KeyCode.Space) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
        animator.SetBool("Ground", isGrounded);

        
        float h = Input.GetAxis("Horizontal");
        Vector3 moveVec = new Vector3(h, 0, 0);
        transform.position += moveVec * Time.deltaTime * speed;

        //xMove = 0;
        //yMove = 0;

        //if (Input.GetKey(KeyCode.RightArrow))
        //    xMove = speed * Time.deltaTime;
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //    xMove = -speed * Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Space))
        //    yMove = jumpForce * Time.deltaTime ;

        //playerR
    }


    private void Die()
    {
        animator.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager.Instance.OnPlayerDead();

    }


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag==("Dead"))
        {
            Debug.Log("죽었습니다");
            Die();
        }
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }
}
