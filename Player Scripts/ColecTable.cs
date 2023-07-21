using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColecTable : MonoBehaviour
{
    [Range(5 , 15)] // thuộc tính phạm vi
    [SerializeField] private float colecTableValue = 15f;

    [SerializeField] private bool timeColectable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            Music.instance.CollectabSound();
            if(timeColectable)
            {
                GamePlay.instance.IncreaseTime(colecTableValue);
            }
            else
            {
                GamePlay.instance.IncreaseAir(colecTableValue); 
            }
            gameObject.SetActive(false);
        }
    }
}
