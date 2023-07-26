using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJum : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator amin;
    private bool canJump;               // có thể nhảy

    [Range(5 , 8)]
    [SerializeField] private float minJumpForce = 5f;   // lực nhảy tối thiếu
    [Range(12, 15)]
    [SerializeField] private float maxJumpForce = 12f;   // lực nhảy tối đa
    [Range(-1 , 1)]
    [SerializeField] private float minWaiTime = 1f;     // thời gian nhảy tối thiếu
    [Range(-1 , 1)]
    [SerializeField] private float maxWaiTime = 1f;     // thời gian nhảy tối đa

    [SerializeField] private float jumTimer;              // bộ đếm thời gian

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        this.CheckStar();
    }

    // Update is called once per frame
   private void Update()
    {
        this.HandleJum();
        this.HandleAnimator();
    }
    private void CheckStar()
    {
        jumTimer = Time.time + Random.Range(minJumpForce, maxJumpForce);
    }
    private void HandleJum()  // xử lý khi nhảy
    {
        if(Time.time > jumTimer)
        {
            jumTimer = Time.time + Random.Range(minWaiTime, maxWaiTime);
            this.Jump();
        }
        if (rb.velocity.magnitude == 0)
        {
            canJump = true;
        }
    }
    private void Jump()
    {
        if (canJump)
        {
            Music.instance.SpiderAatackSound(); // nhạc
            canJump = false;
            rb.velocity = new Vector2(0f, Random.Range(minJumpForce, maxJumpForce));  
        }
        
    }
    private void HandleAnimator()  // xử lý chuyển động
    {
        if(rb.velocity.magnitude == 0)
        {
         amin.SetBool(TagManager.JUMPBETA, false);
        }
        else
        {
            amin.SetBool(TagManager.JUMPBETA, true);
        }
        
    }

}
