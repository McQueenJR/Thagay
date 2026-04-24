using UnityEngine;
using System.Collections;

public class SlowMotionController : MonoBehaviour
{
    [Header("Settings")]
    public float slowGravityScale = 0.2f; // ค่าแรงโน้มถ่วงตอนสโลว์ (ยิ่งน้อยยิ่งช้า)
    public float normalGravityScale = 1f;  // ค่าปกติ
    public float slowDuration = 3f;        // จะให้สโลว์นานกี่วินาที

    private bool isSlowed = false;

    // ฟังก์ชันหลักที่จะเรียกใช้ตอนกดปุ่ม
    public void TriggerSlowMotion()
    {
        if (!isSlowed)
        {
            StartCoroutine(SlowDownItemsRoutine());
        }
    }

    IEnumerator SlowDownItemsRoutine()
    {
        isSlowed = true;

        // 1. หาวัตถุทั้งหมดที่มี Tag "FallingItem"
        GameObject[] items = GameObject.FindGameObjectsWithTag("FallingItem");

        // 2. ปรับให้ช้าลง
        foreach (GameObject item in items)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = slowGravityScale;
                // แถม: ลดความเร็วปัจจุบันลงด้วยเพื่อให้เห็นผลทันที
                rb.velocity *= 0.5f;
            }
        }

        // 3. รอเวลาตามที่กำหนด
        yield return new WaitForSeconds(slowDuration);

        // 4. ปรับกลับเป็นปกติ
        GameObject[] itemsNormal = GameObject.FindGameObjectsWithTag("FallingItem");
        foreach (GameObject item in itemsNormal)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = normalGravityScale;
            }
        }

        isSlowed = false;
    }
}