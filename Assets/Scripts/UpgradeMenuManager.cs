using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] UpgradeDescriptionPanel upgradeDescriptions;
    PauseManager pauseManager;

    Level characterLevel;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    int selectedUpgradeID;

    List<UpgradeData> upgradeData;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
        characterLevel = GameManager.instance.playerTransform.GetComponent<Level>();
    }

    private void Start()
    {
        HideButtons();
        selectedUpgradeID = -1;
    }

    public void OpenMenu(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);

        this.upgradeData = upgradeDatas;

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
        if (selectedUpgradeID != pressedButtonID) 
        {
            selectedUpgradeID = pressedButtonID;
            ShowDescription();
        }
        else
        {
            characterLevel.Upgrade(pressedButtonID);
            CloseMenu();
            HideDescription();
        }
    }

    private void HideDescription()
    {
        upgradeDescriptions.gameObject.SetActive(false);
    }

    private void ShowDescription()
    {
        upgradeDescriptions.gameObject.SetActive(true);
        upgradeDescriptions.Set(upgradeData[selectedUpgradeID]);
    }

    public void CloseMenu()
    {
        selectedUpgradeID = -1;

        HideButtons();
        HideDescription();

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
