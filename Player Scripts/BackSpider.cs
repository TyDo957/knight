using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSpider : MonoBehaviour
{
    [Range(2 , 8)] // thuộc tính phạm vi
    [SerializeField] private float moveSpeed = 5f;  // tốc độ di chuyển

    [Range(2 , 6)]
    [SerializeField] private float maxWalkDistanceValue = 10f; // enemy di chuyển trong giới hạn cho phép
    private float minWalk;
    private float maxWalk;
    private bool moveleft;   // đã di chuyển

    private Vector3 temPos;
    private SpriteRenderer sprites;
    private Transform groundCheckPos;

    private void Awake()
    {
        sprites = GetComponent<SpriteRenderer>();
        groundCheckPos = transform.GetChild(0);
    }
    // Start is called before the first frame update
    private  void Start()
    {
       this.CheckStar();
    }

    // Update is called once per frame
    private void Update()
    {
        this.HandleWalking(); 
    }
  
    private void CheckStar()
    {
        moveleft = Random.Range(0 ,2) > 0 ? true : false;

        minWalk = transform.position.x - maxWalkDistanceValue;
        maxWalk = transform.position.x + maxWalkDistanceValue;
    }

    private void HandleWalking()  // enemy di chuyển trong giới hạn cho phép
    {
        temPos = transform.position;
        if(moveleft)
        {
            temPos.x -= moveSpeed * Time.deltaTime;
        }
        else
        {
            temPos.x += moveSpeed * moveSpeed * Time.deltaTime;
        }
        transform.position = temPos;

        sprites.flipX = moveleft;
        if(temPos.x < minWalk)
        {
            moveleft = false;
        }
        if(temPos.x > maxWalk)
        {
            moveleft = true;
        }
    }
}
