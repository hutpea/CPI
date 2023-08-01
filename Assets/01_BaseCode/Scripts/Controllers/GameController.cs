using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif


public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public UseProfile useProfile;
    public DataContain dataContain;
    public MusicManager musicManager;
    public AdmobAds admobAds;
    public AnalyticsController AnalyticsController;
    public IapController iapController;

    public MoneyEffectController moneyEffectController;

    [HideInInspector] public SceneType currentScene;

    public ModeGame modeGame;
    [HideInInspector] public bool openFeatureBox = false;

    [SerializeField] private StartLoading startLoading;
    protected void Awake()
    {
        Instance = this;
        Input.multiTouchEnabled = false;
        Init();
        DontDestroyOnLoad(this);

        //GameController.Instance.useProfile.IsRemoveAds = true;


#if UNITY_IOS
 //Init();
    if(ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == 
    ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
    {

        ATTrackingStatusBinding.RequestAuthorizationTracking();

    }
//#else
//        if (UseProfile.IsTrackedPremission)
//        {
//            Init();
//        }
//        else
//        {
//            TrackingBox.Setup().Show(() =>
//            {
//                Init();
//            });
//        }
#endif

    }

    private void Start()
    {
        musicManager.PlayBGMusic();
    }

    public void Init()
    {

        UseProfile.NumberOfAdsInPlay = 0;
        //Application.targetFrameRate = 60;

        //useProfile.IsRemoveAds = true;
        
        useProfile.CurrentLevelPlay = UseProfile.CurrentLevel;
        admobAds.Init();
        musicManager.Init();
        iapController.Init();

        MMVibrationManager.SetHapticsActive(useProfile.OnVibration);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (startLoading != null)
            startLoading.Init();
    }

    public void LoadScene(string sceneName)
    {
        Initiate.Fade(sceneName.ToString(), Color.black, 2f);
    }
    public static void SetUserProperties()
    {
        if (UseProfile.IsFirstTimeInstall)
        {
            UseProfile.FirstTimeOpenGame = UnbiasedTime.Instance.Now();
            UseProfile.LastTimeOpenGame = UseProfile.FirstTimeOpenGame;
            UseProfile.IsFirstTimeInstall = false;
        }

        var lastTimeOpen = UseProfile.LastTimeOpenGame;
        UseProfile.RetentionD = (UnbiasedTime.Instance.Now() - UseProfile.FirstTimeOpenGame).Days;

        var dayPlayerd = (TimeManager.ParseTimeStartDay(UnbiasedTime.Instance.Now()) - TimeManager.ParseTimeStartDay(UseProfile.LastTimeOpenGame)).Days;
        if (dayPlayerd >= 1)
        {
            UseProfile.LastTimeOpenGame = UnbiasedTime.Instance.Now();
            UseProfile.DaysPlayed++;
        }

        AnalyticsController.SetUserProperties();
    }
}
public enum SceneType
{
    StartLoading = 0,
    MainHome = 1,
    GamePlay = 2
}