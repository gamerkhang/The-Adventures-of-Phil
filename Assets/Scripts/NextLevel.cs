using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
    public string nextLevel;
    //public float speed = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            Application.LoadLevel(nextLevel);
            //StartCoroutine("LoadNextLevel");
        }
    }

    //IEnumerator LoadNextLevel()
    //{
    //    while(guiTexture.color.a < 0.95f)
    //    {
    //        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, speed * Time.deltaTime);
    //        yield return null;
    //    }
    //    Application.LoadLevel(nextLevel);
    //}
}
