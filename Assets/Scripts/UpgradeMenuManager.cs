using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void OpenMenu(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Clean()
    {
        for(int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButtonID);
        CloseMenu();
    }

    public void CloseMenu()
    {
        HideButtons();

        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

}
