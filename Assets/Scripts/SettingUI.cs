using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject settingPanel;

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}