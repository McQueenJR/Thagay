using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerInGame : MonoBehaviour
{
    public static UIManagerInGame Instance;

    public Image[] hearts;
    private int currentHP;

    public  TMP_Text coinText;
    private int coins = 0;
    

    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentHP = hearts.Length;
        UpdateHearts();
        UpdateCoinUI();
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        currentHP = Mathf.Clamp(currentHP, 0, hearts.Length);

        UpdateHearts();

        if (currentHP <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateCoinUI();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHP;
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = coins.ToString();
    }
}