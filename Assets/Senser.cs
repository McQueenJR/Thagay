using Unity.VisualScripting;
using UnityEngine;

public class Senser : MonoBehaviour
{
    void OnCollisionEnter(OnCollisionEnter2D other)
    {
        Debug.Log("Game Over");
        GameManager.Instance.GameOver();
    }

}
