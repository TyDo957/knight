using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PlayerMove
{
    private bool canDash = true;
    private bool dashing;
    private float dashingPower = 24f;
    private float dashTime = 0.2f;
    private float dashingCoodow = 1f;
    [SerializeField] private TrailRenderer tr;

    private void Update()
    {
        this.CheckDash();
    }
    private void CheckDash()
    {
        if (Input.GetKeyDown(KeyCode.R) && canDash)
        {
            StartCoroutine(Ddash());
        }
    }
    private IEnumerator Ddash()
    {
        canDash = false;
        dashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        dashing = false;
        yield return new WaitForSeconds(dashingCoodow);
        canDash = true;
    }

}
