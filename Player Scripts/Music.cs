using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music instance;

    [SerializeField] private AudioClip playerJumSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip spiderAttackSound;
    [SerializeField] private AudioClip colectabSound;
    // Start is called before the first frame update
    private void Start()
    {
        if(instance == null)
        {
            instance = this;

        }
    }
    public void PlayerJumSound()
    {
        AudioSource.PlayClipAtPoint(playerJumSound, transform.position);
    }
    public void GameOverSound()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);

    }
    public void SpiderAatackSound()
    {
        AudioSource.PlayClipAtPoint(spiderAttackSound, transform.position);
    }
    public void CollectabSound()
    {
        AudioSource.PlayClipAtPoint(colectabSound, transform.position);
    }
}
