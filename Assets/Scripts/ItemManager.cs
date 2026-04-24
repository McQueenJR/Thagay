using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [Header("Slot Lock Status")]
    public bool slot1Unlocked = true;
    public bool slot2Unlocked = false;
    public bool slot3Unlocked = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        // กด Q = Slot1
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSlot1();
        }

        // กด W = Slot2
        if (Input.GetKeyDown(KeyCode.W))
        {
            UseSlot2();
        }

        // กด E = Slot3
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSlot3();
        }
    }

    // -------------------
    // SLOT 1
    // -------------------
    public void UseSlot1()
    {
        if (!slot1Unlocked) return;

        Debug.Log("Use Slot 1");

        // 🔥 ตัวอย่างสกิล: สโลว์เวลา
        Time.timeScale = 0.5f;
        Invoke(nameof(ResetTime), 2f);
    }

    // -------------------
    // SLOT 2
    // -------------------
    public void UseSlot2()
    {
        if (!slot2Unlocked) return;

        Debug.Log("Use Slot 2");

        // 🔥 ตัวอย่าง: เคลียร์ศัตรู
        ClearAllEnemies();
    }

    // -------------------
    // SLOT 3
    // -------------------
    public void UseSlot3()
    {
        if (!slot3Unlocked) return;

        Debug.Log("Use Slot 3");

        // 🔥 ตัวอย่าง: โล่กันตาย
        ActivateShield();
    }

    // -------------------
    void ResetTime()
    {
        Time.timeScale = 1f;
    }

    void ClearAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var e in enemies)
        {
            Destroy(e);
        }
    }

    void ActivateShield()
    {
        Debug.Log("Shield Activated");
        // ไปต่อยอดเอง เช่น กันดาเมจ 1 ครั้ง
    }
}