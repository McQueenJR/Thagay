using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ติด Script นี้กับ SubStagePanel
/// ใช้สำหรับแสดงด่านย่อยตามเกาะที่เลือก
/// </summary>
public class SubStagePanel : MonoBehaviour
{
    [Header("ปุ่มด่านย่อย (ใส่ตามจำนวนด่านสูงสุด)")]
    public Button[] levelButtons;  // ปุ่มด่าน 1,2,3,4...

    [Header("ข้อมูลด่านของแต่ละเกาะ")]
    // island[i] = จำนวนด่านในเกาะ i
    public int[] levelCountPerIsland = { 4, 4, 4 };

    // ข้อมูลดาวที่ได้ในแต่ละด่าน (island, level) → จำนวนดาว 0-3
    // ตัวอย่าง: stars[0][2] = ดาวของเกาะ 0 ด่าน 2
    private int[][] starsEarned;

    private void Awake()
    {
        // ตั้งค่าเริ่มต้น (ในโปรเจกต์จริงดึงจาก PlayerPrefs หรือ SaveSystem)
        starsEarned = new int[3][];
        starsEarned[0] = new int[] { 3, 2, 1, 0 };
        starsEarned[1] = new int[] { 0, 0, 0, 0 };
        starsEarned[2] = new int[] { 0, 0, 0, 0 };
    }

    /// <summary>เรียกจาก UIManager ตอนเลือกเกาะ</summary>
    public void LoadStages(int islandIndex)
    {
        int totalLevels = levelCountPerIsland[islandIndex];

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < totalLevels)
            {
                levelButtons[i].gameObject.SetActive(true);

                // ตั้ง interactable (ด่านแรกเล่นได้เสมอ ด่านถัดไปต้องได้ดาว)
                bool isUnlocked = (i == 0) || (starsEarned[islandIndex][i - 1] > 0);
                levelButtons[i].interactable = isUnlocked;

                // ส่ง index ให้ปุ่ม (ต้องผูก OnClick ใน Inspector)
                int levelIndex = i; // จับค่าไว้ใน closure
                levelButtons[i].onClick.RemoveAllListeners();
                levelButtons[i].onClick.AddListener(() =>
                {
                    UIManager.Instance.OnClickStartLevel(levelIndex);
                });
            }
            else
            {
                // ซ่อนปุ่มที่เกินจำนวนด่าน
                levelButtons[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>บันทึกดาวหลังจบด่าน</summary>
    public void SaveStars(int islandIndex, int levelIndex, int stars)
    {
        // บันทึกลง PlayerPrefs
        string key = $"stars_{islandIndex}_{levelIndex}";
        int currentBest = PlayerPrefs.GetInt(key, 0);
        if (stars > currentBest)
        {
            PlayerPrefs.SetInt(key, stars);
            PlayerPrefs.Save();
        }
    }
    
    
}