 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamnod : MonoBehaviour
{
    // Start is called before the first frame update
    private  void Start()
    {
      //  Door.instance.RegistecDiamnod();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            Music.instance.CollectabSound();
           // Door.instance.diamnodColecter();
            gameObject.SetActive(false);
        }
    }

}
