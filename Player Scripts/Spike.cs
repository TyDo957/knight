using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    private RaycastHit2D playerHit;
    private Rigidbody2D rb;
    private bool playerDetected;
    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    // Update is called once per frame
   private void Update()
    {
        this.DectectPlayer();
    }
    private void OnDisable()
    {
        CancelInvoke("Beta");
    }
    private void DectectPlayer()  // trình phát hiện
    {
        if (playerDetected)
              return;
        playerHit = Physics2D.Raycast(transform.position, Vector2.down, 100f, player);

        if (playerHit)
        {
            playerDetected = true;
            Invoke("Beta", 2f);
            rb.gravityScale = 1f;
        }
    }
    private void Beta()
    {
        gameObject.SetActive(false);
    }
}
