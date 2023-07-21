using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(2 , 6)]
    [SerializeField] private float moveSpeed = 6f;
    [Range(10 , 15)]
    [SerializeField] private float jumFocer = 10f;

    [SerializeField] Transform groudCheckPos;
    [SerializeField] LayerMask groudLayer;

    public Rigidbody2D rb; 
    private PlayerAnimator playerAmin;  
    private BoxCollider2D box2d;
    // Start is called before the first frame update
  private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAmin = GetComponent<PlayerAnimator>();
        box2d = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
   private void Update()
    {
        this.HandkePlayers();
        this.HandlMovenment();
        this.HandleJum();
    }
    private void HandlMovenment()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            playerAmin.PlayerWalkAnimator(1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed , rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f , rb.velocity.y);
        }
    }
    private void HandkePlayers()  // xử lý người chơi
    {
        playerAmin.PlayerWalkAnimator((int)Mathf.Abs(rb.velocity.x));
        playerAmin.SetFaingDirection((int)rb.velocity.x);
        playerAmin.PlayerJumAnimator(Ground());
    }
    public bool Ground()
    {
        return Physics2D.BoxCast(box2d.bounds.center,
       box2d.bounds.size, 0f, Vector2.down, 0.1f, groudLayer);
       
    }
    private void HandleJum()
    {
        if (Input.GetButtonDown(TagManager.JUM_BUTON))
        {
            if (Ground())
            {
                Music.instance.PlayerJumSound();
                rb.velocity = new Vector2(rb.velocity.x, jumFocer);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.ENEMY_TAG))
        {
            collision.gameObject.SetActive(false);
            GamePlay.instance.Gameover(false);
        }
        if(collision.CompareTag(TagManager.GOAL_TAG))
        {
            GamePlay.instance.Gameover(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            GamePlay.instance.Gameover(false);
        }
    }



}
