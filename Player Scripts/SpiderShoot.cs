using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShoot : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] private float minShootWaitime = 1f;
    [Range(3 , 5)]
    [SerializeField] private float maxShootWaitime = 3f;
    [Range(20 , 25)]
    [SerializeField] private int initiaBullet = 20;

    [SerializeField] private GameObject spideBullet;

    [SerializeField] private List<GameObject> bullet = new List<GameObject>();

    [SerializeField] private Transform bulletSpanwPos;
    
    private float waiTime;

    private void Awake()
    {
        this.CreatBullet();
    }
    private void Start()
    {
        waiTime = Time.time + Random.Range(minShootWaitime, maxShootWaitime);
    }
    private void Update()
    {
        if (Time.time > waiTime)
        {
            waiTime = Time.time + Random.Range(minShootWaitime , maxShootWaitime);
            this.Shoot(); 

        }

    }
    private void CreatBullet()
    {
        for (int i = 0; i < initiaBullet; i++)
        {
            GameObject newBullet = Instantiate(spideBullet);
            newBullet.SetActive(false);
            bullet.Add(newBullet);
        }
    }
    private void Shoot()
    {
        for (int i = 0; i < bullet.Count; i++)
        {
            if (!bullet[i].activeInHierarchy)
            {
                bullet[i].SetActive(true);
                bullet[i].transform.position = bulletSpanwPos.position;
                break;
            }
        }
    }

  
}
