using UnityEngine;
using UnityEngine.SceneManagement;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.instance.AddPoint();
            YouWin.instance.GemCollect(); 
            Destroy(gameObject);
        }
    }
}