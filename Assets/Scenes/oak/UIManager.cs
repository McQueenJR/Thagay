using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("=== Panels ===")]
    public GameObject mainMenuPanel;
    public GameObject settingPanel;
    public GameObject playPanel;
    public GameObject stageSelectPanel;
    public GameObject subStagePanel;
    public GameObject upgradePanel;

    // เก็บว่าเลือกเกาะไหนอยู่ (ส่งต่อไปหน้าด่านย่อย)
    private int selectedIsland = 0;

    // ============================
    // Unity Lifecycle
    // ============================

    private void Awake()
    {
        // Singleton: มีแค่ตัวเดียวใน Scene
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // เปิดหน้า Main Menu ก่อน
        ShowPanel(mainMenuPanel);
    }

    // ============================
    // Core: สลับ Panel
    // ============================

    /// <summary>ซ่อนทุก Panel แล้วเปิดเฉพาะ Panel ที่ต้องการ</summary>
    public void ShowPanel(GameObject targetPanel)
    {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(false);
        playPanel.SetActive(false);
        stageSelectPanel.SetActive(false);
        subStagePanel.SetActive(false);
        upgradePanel.SetActive(false);

        targetPanel.SetActive(true);
    }

    // ============================
    // Main Menu Buttons
    // ============================

    public void OnClickPlay()
    {
        ShowPanel(playPanel);
    }

    public void OnClickSetting()
    {
        ShowPanel(settingPanel);
    }

    public void OnClickExit()
    {
        Application.Quit();
        // (ใน Editor จะไม่ปิด ต้องกด Stop เอง)
        Debug.Log("Exit Game");
    }

    // ============================
    // Play Panel Buttons
    // ============================

    public void OnClickStageSelect()
    {
        ShowPanel(stageSelectPanel);
    }

    public void OnClickUpgrade()
    {
        ShowPanel(upgradePanel);
    }

    public void OnClickReturnToMainMenu()
    {
        ShowPanel(mainMenuPanel);
    }

    // ============================
    // Stage Select Buttons (เลือกเกาะ)
    // ============================

    /// <summary>
    /// เรียกจากปุ่มแต่ละเกาะ ส่ง islandIndex (0,1,2,...)
    /// ตัวอย่าง: ผูกปุ่มเกาะ 1 → OnClickIsland(0)
    /// </summary>
    public void OnClickIsland(int islandIndex)
    {
        selectedIsland = islandIndex;
        ShowPanel(subStagePanel); 
    }

    public void OnClickReturnToPlay()
    {
        ShowPanel(playPanel);
    }

    // ============================
    // Sub Stage Buttons (เลือกด่านย่อย)
    // ============================

    /// <summary>กดด่านที่เลือกแล้ว โหลด Scene เกม</summary>
    public void OnClickStartLevel(int levelIndex)
    {
        string sceneName = "Island" + selectedIsland + "_Level" + levelIndex;
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickReturnToStageSelect()
    {
        ShowPanel(stageSelectPanel);
    }

    // ============================
    // Setting Panel Buttons
    // ============================

    public void OnClickReturnFromSetting()
    {
        ShowPanel(mainMenuPanel);
    }

    // ============================
    // Upgrade Panel Buttons
    // ============================

    public void OnClickReturnFromUpgrade()
    {
        ShowPanel(playPanel);
    }

    // ============================
    // Helper (ใช้ภายนอกได้)
    // ============================

    public int GetSelectedIsland() => selectedIsland;
}