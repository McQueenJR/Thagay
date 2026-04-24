using UnityEngine;

public class Senser : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over");
        GameManager.Instance.GameOver();
    }

}
