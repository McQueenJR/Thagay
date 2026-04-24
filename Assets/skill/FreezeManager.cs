using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FreezeManager : MonoBehaviour
{
    private bool isFrozen = false;

    // เก็บค่า Velocity เดิมไว้เพื่อให้ตอนหายแช่แข็ง วัตถุจะพุ่งต่อด้วยความเร็วเท่าเดิม
    private Dictionary<Rigidbody2D, Vector2> savedVelocities = new Dictionary<Rigidbody2D, Vector2>();

    public void ToggleFreeze()
    {
        isFrozen = !isFrozen; // สลับสถานะ แช่แข็ง / ปลดปล่อย

        GameObject[] items = GameObject.FindGameObjectsWithTag("FallingItem");

        foreach (GameObject item in items)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (isFrozen)
                {
                    // --- ขั้นตอนแช่แข็ง ---
                    // 1. เก็บความเร็วปัจจุบันไว้ก่อน
                    if (!savedVelocities.ContainsKey(rb))
                        savedVelocities.Add(rb, rb.velocity);
                    else
                        savedVelocities[rb] = rb.velocity;

                    // 2. หยุดความเร็ว และ ล็อคตำแหน่ง
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0; // หยุดการหมุน
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                else
                {
                    // --- ขั้นตอนปลดปล่อย ---
                    // 1. คืนค่าการเคลื่อนที่ (ถอดตัวล็อค)
                    rb.constraints = RigidbodyConstraints2D.None;

                    // 2. คืนค่าความเร็วเดิมที่เก็บไว้
                    if (savedVelocities.ContainsKey(rb))
                    {
                        rb.velocity = savedVelocities[rb];
                    }
                }
            }
        }

        // ถ้าปลดแช่แข็งแล้ว ให้ล้างค่าใน Dictionary ออก
        if (!isFrozen) savedVelocities.Clear();
    }
}