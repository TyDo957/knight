using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    [Range(-2 , 2)]
    [SerializeField] private float deLay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            this.ModeSelect();
        }

    }
    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay());

    }
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(deLay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
