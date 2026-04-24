using Unity.VisualScripting;
using UnityEngine;


public class Senser : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // เช็คว่ามี UIManager จริงไหม
        if (UIManagerInGame.Instance != null)
        {
            UIManagerInGame.Instance.TakeDamage(1);
        }
        else
        {
            Debug.LogError("UIManager not found in Scene!");
        }

        // ลบลูกบอล (กันชนซ้ำ)
        Destroy(collision.gameObject);
    }
}