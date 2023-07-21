using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(-5 , 5)] // thuộc tính phạm vi
    [SerializeField] private float offsetX = -5f;

    private Vector3 temPos;
    private Transform taeget;
    // Start is called before the first frame update
    private  void Start()
    {
        taeget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    // Update is called once per frame
   private  void Update()
    {
        this.FollowePlayer();
    }
    private void FollowePlayer()
    {
        if (!taeget)
        {
            return;
        }
        temPos = transform.position;
        temPos.x = taeget.position.x - offsetX;
        transform.position = temPos;
    }
        

        
}
