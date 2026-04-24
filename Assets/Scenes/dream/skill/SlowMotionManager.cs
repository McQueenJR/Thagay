using UnityEngine;
using System.Collections;

public class SlowMotionManager : MonoBehaviour
{
    [Header("Settings")]
    [Range(0f, 1f)]
    public float slowFactor = 0.2f; // ความช้า (0.2 คือเหลือ 20% ของความเร็วปกติ)
    public float duration = 4f;     // ระยะเวลาที่ต้องการให้สโลว์ (4 วินาที)

    private bool isSlowed = false;

    // ฟังก์ชันสำหรับผูกกับปุ่ม UI
    public void ToggleSlowMotion()
    {
        if (!isSlowed)
        {
            StartCoroutine(SlowRoutine());
        }
    }

    IEnumerator SlowRoutine()
    {
        isSlowed = true;

        // --- เริ่มต้นสโลว์โมชั่น ---
        Time.timeScale = slowFactor;

        // เมื่อเราปรับ timeScale เราควรปรับ fixedDeltaTime ด้วย 
        // เพื่อให้การคำนวณฟิสิกส์ (เช่น การตก) ยังคงลื่นไหล ไม่กระตุก
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        Debug.Log("Slow Motion Started!");

        // --- รอเป็นเวลา 4 วินาที (เวลาจริง) ---
        // ต้องใช้ WaitForSecondsRealtime เพราะเวลาในเกมถูกสั่งให้ช้าลงอยู่
        yield return new WaitForSecondsRealtime(duration);

        // --- กลับสู่สภาวะปกติ ---
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // ค่าพื้นฐานของ Unity

        Debug.Log("Back to Normal Speed!");

        isSlowed = false;
    }
}