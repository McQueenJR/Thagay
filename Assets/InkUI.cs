using UnityEngine;
using UnityEngine.UI;

public class InkUI : MonoBehaviour
{
    
    
    public DrawLine drawLine;
    public Image inkBar;

    void Update()
    {
        float percent = drawLine.GetInkPercent();
        inkBar.fillAmount = percent;
    }
}