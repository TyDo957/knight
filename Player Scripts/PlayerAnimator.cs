using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private  Animator amin;
    private SpriteRenderer sprites;
    // Stat is called before the first frame update
    private void Start()
    {
        amin = GetComponent<Animator>();
        sprites = GetComponent<SpriteRenderer>();
    }

   public void PlayerWalkAnimator(int walk)
    {
        amin.SetInteger(TagManager.WALKBETA, walk);
    }
    public void PlayerJumAnimator(bool jump)
    {
        amin.SetBool(TagManager.JUMPBETA, jump);
    }
    public void SetFaingDirection(int direction)
    {
        if (direction > 0)
        {
            sprites.flipX = false;
        }else if(direction < 0)
        {
            sprites.flipX = true;
        }
    }
}
