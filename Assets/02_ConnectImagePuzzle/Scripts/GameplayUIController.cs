using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [Title("Buttons")]
    public Button resetButton;
    public Button settingButton;
    public Button hintButton;

    public Button toggleVibrateButton;
    public Button toggleSoundButton;
    public Button toggleMusicButton;
    public Button showSupportButton;

    public Button nextButton;

    [Title("Other UIs")]
    public Text levelText;
    public Transform bottomPanel;
    public RectTransform settingPanel;

    private bool isOpenSettingPanel = false;

    private void Awake()
    {
        resetButton.onClick.AddListener(OnResetLevelButtonClick);
        settingButton.onClick.AddListener(OnSettingButtonClick);
        hintButton.onClick.AddListener(OnHintButtonClick);

        showSupportButton.onClick.AddListener(OnShowSupportButtonClick);

        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    public void OnLevelStart(int level)
    {
        settingPanel.localScale = new Vector3(1, 0, 1);
        bottomPanel.gameObject.SetActive(false);
        SetUpLevelText(level);
    }

    public void SetUpLevelText(int level)
    {
        levelText.text = "Level " + level;
    }

    public void SetUpUIOnWin()
    {
        bottomPanel.gameObject.SetActive(true);
    }

    public void OnResetLevelButtonClick()
    {
        GamePlayController.Instance.connectImagePuzzleGameplayController.InitLevel(UseProfile.CurrentLevel);
    }

    public void OnSettingButtonClick()
    {
        if (!isOpenSettingPanel)
        {
            settingPanel.DOScaleY(1f, 0.25f).OnComplete(delegate
            {
                isOpenSettingPanel = true;
            });
        }
        else
        {
            settingPanel.DOScaleY(0f, 0.1f).SetEase(Ease.Flash).OnComplete(delegate
            {
                isOpenSettingPanel = false;
            });
        }
    }

    public void OnHintButtonClick()
    {
    }

    public void OnShowSupportButtonClick()
    {
        if (!isOpenSettingPanel) return;
        Application.OpenURL("https://www.facebook.com/gplay.globalplaystudio");
    }

    public void OnNextButtonClick()
    {
        UseProfile.CurrentLevel++;
        GamePlayController.Instance.connectImagePuzzleGameplayController.InitLevel(UseProfile.CurrentLevel);
    }
}
