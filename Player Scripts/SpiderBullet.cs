using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    private float waiTime;
    private float minShootWaitime = 1f;
    private float maxShootWaitime = 3f;

    [SerializeField] private GameObject spider;
    [SerializeField] private  Transform bullet;

    // Start is called before the first frame update
    private void Start()
    {
        this.CheckStar();
    }

    // Update is called once per frame
    private void Update()
    {
        this.CheckUpdate();
    }
    private void CheckStar()
    {
        waiTime = Time.time + Random.Range(minShootWaitime, maxShootWaitime);
    }
    private void CheckUpdate()
    {
        if(Time.time > waiTime)
        {
            waiTime = Time.time + Random.Range(minShootWaitime, maxShootWaitime);
            this.Shooter();
        }
    }
    private void Shooter()
    {
        Instantiate(spider , bullet.position , Quaternion.identity);
    }
}
