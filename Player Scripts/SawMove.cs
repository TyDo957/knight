 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{
    [Range(5 , 10)] // thuộc tính phạm vi
    [SerializeField] private float moveSpeed = 5f;

    [Range(200 , 400)]
    [SerializeField] private float rotationSpeed = 200f;  // góc xoay trôi nổi

    [SerializeField] private Transform movePiont1, movePiont2;  // di chuyển giữa điểm đánh dấu thứ 1

    private Vector3 temRotation;
    private Transform targetPos;
    private bool fistMovePos;      // điểm di chuyển đầu tiên 
    private float zAngle;
    // Start is called before the first frame update
    private void Start()
    {
        this.MoveRandeom();
    }

    // Update is called once per frame
     private  void Update()
    {
        this.HandleMovement();
        this.HandleRotation();
    }
    private void MoveRandeom()
    {
        if(Random.Range(0 , 2) > 0)
        {
            fistMovePos = false;
            targetPos = movePiont2;

            rotationSpeed *= -1f;

        }
        else
        {
            fistMovePos = true;
            targetPos = movePiont1;
        }
    }
    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position , moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos.position) < 0.1f)
        {
            if(fistMovePos)
            {
                fistMovePos = false;
                targetPos = movePiont2;
            }
            else
            {
                fistMovePos = true;
                targetPos = movePiont1;
            }
        }
    }
    private void HandleRotation()
    {
        zAngle += Time.deltaTime * rotationSpeed;
        temRotation.z = zAngle;
        transform.Rotate(temRotation);
    }
    

    
}
