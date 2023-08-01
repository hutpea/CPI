using Crystal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Sirenix.OdinInspector;

public enum ModeGame
{
    Campaign = 0,
    PvP1 = 1,
}
public enum StateGame
{
    Loading = 0,
    Playing = 1,
    Win = 2,
    Lose = 3,
    Pause = 4
}

public class GamePlayController : Singleton<GamePlayController>
{
    /* public PlayerContain playerContain;
     public GameScene gameScene;
     public Level level;*/
    [Title("Connect Image Puzzle Controllers")]
    public ConnectImagePuzzleGameplayController connectImagePuzzleGameplayController;
    public GameplayUIController gameplayUIController;

    [Header("Base nonsense controllers")]
    public StateGame state;

    private static bool isBannerShow;
    [Header("Safe Area")]
    public SafeArea safeArea;


    protected override void OnAwake()
    {
        //GameController.Instance.currentScene = SceneType.GamePlay;
        Init();
    }

    public void Init()
    {
#if UNITY_IOS
if (safeArea != null)
            safeArea.enabled = true;
#endif
        //! WARNING: KHÔNG THAY ĐỔI THỨ TỰ INIT
        connectImagePuzzleGameplayController.Init();
        /*if (GameController.Instance.modeGame == ModeGame.Campaign)
        {
            *//*playerContain.Init();
            InitLevel();
            gameScene.Init();*//*
            CheckShowFeatureBox();
        }
        ResetDay();
        GameController.Instance.admobAds.DestroyBanner();
        GameController.Instance.admobAds.ShowBanner();*/
        isBannerShow = true;
    }

    /*public void InitLevel()
    {
        if (level != null)
        {
            state = StateGame.Loading;
            level.Init();

        }


    }*/
    private void CheckShowFeatureBox()
    {
        if (GameController.Instance.openFeatureBox)
        {
            GameController.Instance.openFeatureBox = false;

        }
    }

    public bool IsShowRate()
    {
        if (!UseProfile.CanShowRate)
            return false;
        int X = GameController.Instance.useProfile.CurrentLevelPlay - 1;
        if (X < RemoteConfigController.GetFloatConfig(FirebaseConfig.LEVEL_START_SHOW_RATE, 5))
            return false;
        if (X == RemoteConfigController.GetFloatConfig(FirebaseConfig.LEVEL_START_SHOW_RATE, 5) || (X <= RemoteConfigController.GetIntConfig(FirebaseConfig.MAX_LEVEL_SHOW_RATE, 31) && X % 10 == 1))
        {
            return true;
        }
        return false;
    }

    public void PlayAnimFly()
    {

    }

    public void PlayAnimFlyOut()
    {

    }

    private void Update()
    {

    }


    public void ResetDay()
    {
        ///Các loại ResetDay ở đây
        long time = TimeManager.CaculateTime(TimeManager.ParseTimeStartDay(UseProfile.LastTimeOnline), TimeManager.ParseTimeStartDay(UnbiasedTime.Instance.Now()));
        if (time >= 86400)
        {
            UseProfile.LastTimeOnline = UnbiasedTime.Instance.Now();
            UseProfile.HasPackInWeekToday = false;
            UseProfile.HasPackWeekendToday = false;
            UseProfile.CurrentPackInWeek = "";
            UseProfile.CurrentPackWeekend = "";

        }

    }
}
