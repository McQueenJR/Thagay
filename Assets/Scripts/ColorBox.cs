using UnityEngine;

public class ColorBox : MonoBehaviour
{
    public string correctTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ถ้าเป็นสีถูก
        if (collision.gameObject.CompareTag(correctTag))
        {
            if (UIManagerInGame.Instance != null)
            {
                UIManagerInGame.Instance.AddCoin(1);
            }

            Destroy(collision.gameObject);
        }
        else // สีผิด
        {
            if (UIManagerInGame.Instance != null)
            {
                UIManagerInGame.Instance.TakeDamage(1);
            }
            else
            {
                Debug.LogError("UIManager not found in Scene!");
            }

            Destroy(collision.gameObject);
        }
    }
}