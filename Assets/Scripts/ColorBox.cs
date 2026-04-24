using UnityEngine;

public class ColorBox : MonoBehaviour
{
   public string correctTag; 

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(correctTag))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
            
        }
    }
}