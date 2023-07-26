using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesTroy : MonoBehaviour
{
    [Range(3 , 5)]
    [SerializeField] private float destroyTime = 3.0f;  // sau 3 giây sẽ tự hủy

    private void OnEnable()
    {

        Invoke("Beta", destroyTime);
    }
    private void OnDisable()
    {
        CancelInvoke("Beta");
    }
    private void Beta()
    {
        if(gameObject.activeInHierarchy)
        {
            CancelInvoke("Beta");
            gameObject.SetActive(false);
        }
    }
 
    
}
