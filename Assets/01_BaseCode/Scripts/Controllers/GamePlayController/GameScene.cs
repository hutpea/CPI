using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
using MoreMountains.NiceVibrations;
using UnityEngine.Events;

public class GameScene : BaseScene
{
    [Header("UI")]
    [SerializeField] private Text levelTxt;
    [SerializeField] private Button replayBtn;
    public Button removeADSBtn;
    [SerializeField] private Button skipBtn;

    public void Init()
    {
        // levelTxt.text = string.Format(Localization.Get("s_level"), GameController.Instance.useProfile.CurrentLevelPlay.ToString());
        levelTxt.text = "Level " + GameController.Instance.useProfile.CurrentLevelPlay.ToString();
        replayBtn.onClick.AddListener(OnClickReplay);
        removeADSBtn.onClick.AddListener(OnClickRemoveAds);
        skipBtn.onClick.AddListener(OnClickSkip);

       
        if (GameController.Instance.useProfile.IsRemoveAds)
            removeADSBtn.gameObject.SetActive(false);
    }

    public void OnClickReplay()
    {
        //GameController.Instance.AnalyticsController.LogLevelFail(GameController.Instance.useProfile.CurrentLevelPlay);
        GameController.Instance.musicManager.PlayClickSound();
        GameController.Instance.admobAds.ShowInterstitial(actionIniterClose: () =>
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }, actionWatchLog: "Replay");
    }

    public void OnClickRemoveAds()
    {
        GameController.Instance.iapController.BuyProduct(TypePackIAP.NoAdsPack);
    }

    public void OnClickSkip()
    {
        GameController.Instance.musicManager.PlayClickSound();
        GameController.Instance.admobAds.ShowVideoReward(
            actionReward: () => { GamePlayController.Instance.connectImagePuzzleGameplayController.Win(); },
            actionNotLoadedVideo: () =>
            {
                GameController.Instance.moneyEffectController.SpawnEffectText_FlyUp
                 (
                 skipBtn.transform.position,
                 "No video at the moment!",
                 Color.white,
                 isSpawnItemPlayer: true
                 );
            },
            actionClose: null,
            ActionWatchVideo.Skip_level,
            GameController.Instance.useProfile.CurrentLevelPlay.ToString());
    }

    public override void OnEscapeWhenStackBoxEmpty()
    {
       
    }
}
