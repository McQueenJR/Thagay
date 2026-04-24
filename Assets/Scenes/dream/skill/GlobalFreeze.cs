using UnityEngine;
using System.Collections;

public class GlobalFreeze : MonoBehaviour
{
    private bool isFrozen = false;

    // ฟังก์ชันนี้ผูกกับปุ่ม
    public void ClickToFreeze()
    {
        if (!isFrozen)
        {
            StartCoroutine(FreezeRoutine());
        }
    }

    IEnumerator FreezeRoutine()
    {
        isFrozen = true;

        // --- เริ่มหยุดเวลาทั้งเกม ---
        // ค่า 0 คือหยุดนิ่งสนิท, ค่า 1 คือเวลาปกติ
        Time.timeScale = 0f;

        // คำเตือน: เมื่อ Time.timeScale เป็น 0 
        // เราต้องใช้ WaitForSecondsRealtime แทน WaitForSeconds
        // เพราะเวลาปกติในเกมมันหยุดเดินไปแล้ว!
        yield return new WaitForSecondsRealtime(3f);

        // --- กลับมาเป็นปกติ ---
        Time.timeScale = 1f;

        isFrozen = false;
    }
}