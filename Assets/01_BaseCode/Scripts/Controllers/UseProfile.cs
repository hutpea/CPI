using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MoreMountains.NiceVibrations;
using Newtonsoft.Json;
using Facebook.Unity;

public class UseProfile : MonoBehaviour
{
    public static int CurrentLevel
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_LEVEL, 1);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_LEVEL, value);
            GPlayerPrefs.Save();
        }
    }

    public int CurrentLevelPlay
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_LEVEL_PLAY, 1);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_LEVEL_PLAY, value);
            GPlayerPrefs.Save();
        }
    }

    public bool IsRemoveAds
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.REMOVE_ADS, 0) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.REMOVE_ADS, value ? 1 : 0);
            GPlayerPrefs.Save();
        }
    }

    public bool OnVibration
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.ONOFF_VIBRATION, 1) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.ONOFF_VIBRATION, value ? 1 : 0);
            MMVibrationManager.SetHapticsActive(value);
            GPlayerPrefs.Save();
        }
    }

    public bool OnSound
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.ONOFF_SOUND, 1) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.ONOFF_SOUND, value ? 1 : 0);
            GameController.Instance.musicManager.SetSoundVolume(value ? 1 : 0);
            GPlayerPrefs.Save();
        }
    }

    public bool OnMusic
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.ONOFF_MUSIC, 1) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.ONOFF_MUSIC, value ? 1 : 0);
            GameController.Instance.musicManager.SetMusicVolume(value ? 0.4f : 0);
            GPlayerPrefs.Save();
        }
    }

    public static bool IsFirstTimeInstall
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.FIRST_TIME_INSTALL, 1) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.FIRST_TIME_INSTALL, value ? 1 : 0);
            GPlayerPrefs.Save();
        }
    }

    public static int RetentionD
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.RETENTION_D, 0);
        }
        set
        {
            if (value < 0)
                value = 0;

            GPlayerPrefs.SetInt(StringHelper.RETENTION_D, value);
            GPlayerPrefs.Save();
        }
    }
    public static bool LoggedRevenueCents
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.LOGGED_REVENUE_CENTS, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.LOGGED_REVENUE_CENTS, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static int PreviousRevenueD0_D1
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.PREVIOUS_REVENUE_D0_D1, 0);
        }
        set
        {
            if (value < 0)
                value = 0;

            PlayerPrefs.SetInt(StringHelper.PREVIOUS_REVENUE_D0_D1, value);
            PlayerPrefs.Save();
        }
    }
    
    public static float RevenueD0_D1
    {
        get
        {
            return PlayerPrefs.GetFloat(StringHelper.REVENUE_D0_D1, 0);
        }
        set
        {
            if (value < 0f)
                value = 0f;

            PlayerPrefs.SetFloat(StringHelper.REVENUE_D0_D1, value);
            PlayerPrefs.Save();
        }
    }
    public static int NumberOfDisplayedInterstitialD0_D1
    {
       get
       {
           return PlayerPrefs.GetInt(StringHelper.NUMBER_OF_DISPLAYED_INTERSTITIAL_D0_D1, 0);
       }
       set
       {
            PlayerPrefs.SetInt(StringHelper.NUMBER_OF_DISPLAYED_INTERSTITIAL_D0_D1, value);
            PlayerPrefs.Save();
        }
    }


    public static int PreviousRevenueD1
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.PREVIOUS_REVENUE_D1, 0);
        }
        set
        {
            if (value < 0)
                value = 0;

            PlayerPrefs.SetInt(StringHelper.PREVIOUS_REVENUE_D1, value);
            PlayerPrefs.Save();
        }
    }

    public static float RevenueD1
    {
        get
        {
            return PlayerPrefs.GetFloat(StringHelper.REVENUE_D1, 0);
        }
        set
        {
            if (value < 0f)
                value = 0f;

            PlayerPrefs.SetFloat(StringHelper.REVENUE_D1, value);
            PlayerPrefs.Save();
        }
    }
    public static int NumberOfDisplayedInterstitialD1
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.NUMBER_OF_DISPLAYED_INTERSTITIAL_D1, 0);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.NUMBER_OF_DISPLAYED_INTERSTITIAL_D1, value);
            PlayerPrefs.Save();
        }
    }


  
   

    public static int DaysPlayed
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.DAYS_PLAYED, 1);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.DAYS_PLAYED, value);
            GPlayerPrefs.Save();
        }
    }

    public static int PayingType
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.PAYING_TYPE, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.PAYING_TYPE, value);
            GPlayerPrefs.Save();
        }
    }


    public static DateTime FirstTimeOpenGame
    {
        get
        {
            if (GPlayerPrefs.HasKey(StringHelper.FIRST_TIME_OPEN_GAME))
            {
                var temp = Convert.ToInt64(GPlayerPrefs.GetString(StringHelper.FIRST_TIME_OPEN_GAME));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
                GPlayerPrefs.SetString(StringHelper.FIRST_TIME_OPEN_GAME, newDateTime.ToBinary().ToString());
                GPlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.FIRST_TIME_OPEN_GAME, value.ToBinary().ToString());
            GPlayerPrefs.Save();
        }
    }

    public static DateTime LastTimeOpenGame
    {
        get
        {
            if (GPlayerPrefs.HasKey(StringHelper.LAST_TIME_OPEN_GAME))
            {
                var temp = Convert.ToInt64(GPlayerPrefs.GetString(StringHelper.LAST_TIME_OPEN_GAME));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
                GPlayerPrefs.SetString(StringHelper.LAST_TIME_OPEN_GAME, newDateTime.ToBinary().ToString());
                GPlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.LAST_TIME_OPEN_GAME, value.ToBinary().ToString());
            GPlayerPrefs.Save();
        }
    }
    public static DateTime LastTimeResetSalePackShop
    {
        get
        {
            if (GPlayerPrefs.HasKey(StringHelper.LAST_TIME_RESET_SALE_PACK_SHOP))
            {
                var temp = Convert.ToInt64(GPlayerPrefs.GetString(StringHelper.LAST_TIME_RESET_SALE_PACK_SHOP));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
                GPlayerPrefs.SetString(StringHelper.LAST_TIME_RESET_SALE_PACK_SHOP, newDateTime.ToBinary().ToString());
                GPlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.LAST_TIME_RESET_SALE_PACK_SHOP, value.ToBinary().ToString());
            GPlayerPrefs.Save();
        }
    }


    public static bool CanShowRate
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CAN_SHOW_RATE, 1) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CAN_SHOW_RATE, value ? 1 : 0);
            GPlayerPrefs.Save();
        }
    }

    public bool IsTutedReturn
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.IS_TUTED_RETURN, 0) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.IS_TUTED_RETURN, value ? 1 : 0);
            GPlayerPrefs.Save();
            
        }
    }

    public int CurrentNumReturn
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_RETURN, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_RETURN, 2));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_RETURN, value);
            GPlayerPrefs.Save();
            
        }
    }
    public int CurrentNumAddBranch
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_ADD_STAND, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_ADD_BRANCH, 1));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_ADD_STAND, value);
            GPlayerPrefs.Save();
            
        }
    }
    public int CurrentNumRemoveBomb
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_REMOVE_BOMB, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_REMOVE_BOMB, 0));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_REMOVE_BOMB, value);
            GPlayerPrefs.Save();
            
        }
    }
    public int CurrentNumRemoveCage
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_REMOVE_CAGE, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_REMOVE_CAGE, 0));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_REMOVE_CAGE, value);
            GPlayerPrefs.Save();
            
        }
    }
    public int CurrentNumRemoveEgg
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_REMOVE_EGG, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_REMOVE_EGG, 0));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_REMOVE_EGG, value);
            GPlayerPrefs.Save();
            
        }
    }
    public int CurrentNumRemoveSleep
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_REMOVE_SLEEP, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_REMOVE_SLEEP, 0));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_REMOVE_SLEEP, value);
            GPlayerPrefs.Save();
            
        }
    }
    public int CurrentNumRemoveJail
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_REMOVE_JAIL, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_REMOVE_JAIL, 0));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_REMOVE_JAIL, value);
            GPlayerPrefs.Save();
            
        }
    }

    public bool IsTutedBuyStand
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.IS_TUTED_BUY_STAND, 0) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.IS_TUTED_BUY_STAND, value ? 1 : 0);
            GPlayerPrefs.Save();
            
        }
    }

    public string CurrentBirdSkin
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.CURRENT_BIRD_SKIN, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.CURRENT_BIRD_SKIN, value);
            GPlayerPrefs.Save();
        }
    }

    public string OwnedBirdSkin
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.OWNED_BIRD_SKIN, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.OWNED_BIRD_SKIN, value);
            GPlayerPrefs.Save();
        }
    }
    public string RandomBirdSkinInShop
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.RANDOM_BIRD_SKIN_IN_SHOP, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.RANDOM_BIRD_SKIN_IN_SHOP, value);
            GPlayerPrefs.Save();
        }
    }
    public string RandomBirdSkinSaleWeekend1
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.RANDOM_BIRD_SKIN_SALE_WEEKEND_1, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.RANDOM_BIRD_SKIN_SALE_WEEKEND_1, value);
            GPlayerPrefs.Save();
        }
    }
    public string RandomBranchSaleWeekend2
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.RANDOM_BRANCH_SALE_WEEKEND_2, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.RANDOM_BRANCH_SALE_WEEKEND_2, value);
            PlayerPrefs.Save();
        }
    }
    public string RandomThemeSaleWeekend2
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.RANDOM_THEME_SALE_WEEKEND_2, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.RANDOM_THEME_SALE_WEEKEND_2, value);
            PlayerPrefs.Save();
        }
    }
   


    public int CurrentBranchSkin
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_BRANCH_SKIN, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_BRANCH_SKIN, value);
            GPlayerPrefs.Save();
        }
    }

    public string OwnedBranchSkin
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.OWNED_BRANCH_SKIN, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.OWNED_BRANCH_SKIN, value);
            GPlayerPrefs.Save();
        }
    }
    public string RandomBranchInShop
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.RANDOM_BRANCH_IN_SHOP, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.RANDOM_BRANCH_IN_SHOP, value);
            GPlayerPrefs.Save();
        }
    }
    public int CurrentTheme
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_THEME, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_THEME, value);
            GPlayerPrefs.Save();
        }
    }
    public string OwnedThemeSkin
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.OWNED_THEME, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.OWNED_THEME, value);
            GPlayerPrefs.Save();
        }
    }
    

    public string RandomThemeInShop
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.RANDOM_THEME_IN_SHOP, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.RANDOM_THEME_IN_SHOP, value);
            GPlayerPrefs.Save();
        }
    }

    public string CurrentRandomBird
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.CURRENT_RANDOM_BIRD_SKIN, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.CURRENT_RANDOM_BIRD_SKIN, value);
            GPlayerPrefs.Save();
        }
    }
    public int CurrentRandomBranch
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_RANDOM_BRANCH_SKIN, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_RANDOM_BRANCH_SKIN, value);
            GPlayerPrefs.Save();
        }
    }
    public int CurrentRandomTheme
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_RANDOM_THEME, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_RANDOM_THEME, value);
            GPlayerPrefs.Save();
        }
    }

    public int NumShowedAccumulationRewardRandom//Khi có chim mới => bản mới sẽ NumShowedAccumulationRewardRandom = 0
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.NUM_SHOWED_ACCUMULATION_REWARD_RANDOM, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.NUM_SHOWED_ACCUMULATION_REWARD_RANDOM, value);
            GPlayerPrefs.Save();
        }
    }

    public static bool StarterPackIsCompleted
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.STARTER_PACK_IS_COMPLETED, 0) == 1;
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.STARTER_PACK_IS_COMPLETED, value ? 1 : 0);
            GPlayerPrefs.Save();
        }
    }

    public static bool HasPackInWeekToday
    {
         get
        {
            return PlayerPrefs.GetInt(StringHelper.HAS_PACK_IN_WEEK_TODAY, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.HAS_PACK_IN_WEEK_TODAY, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool HasPackWeekendToday
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.HAS_PACK_WEEKEND_TODAY, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.HAS_PACK_WEEKEND_TODAY, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static string CurrentPackInWeek
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.CURRENT_PACK_IN_WEEK, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.CURRENT_PACK_IN_WEEK, value);
            PlayerPrefs.Save();
        }
    }
    public static string CurrentPackWeekend
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.CURRENT_PACK_WEEKEND, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.CURRENT_PACK_WEEKEND, value);
            PlayerPrefs.Save();
        }
    }
    public static string CurrentRandomSetSkin
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.CURRENT_RANDOM_SET_SKIN, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.CURRENT_RANDOM_SET_SKIN, value);
            PlayerPrefs.Save();
        }
    }

 
    public static int NumberOfAdsInPlay;
    public static int NumberOfAdsInDay
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.NUMBER_OF_ADS_IN_DAY, 0);
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.NUMBER_OF_ADS_IN_DAY, value);
            GPlayerPrefs.Save();
        }
    }

    public static DateTime LastTimeOnline
    {
        get
        {
            if (GPlayerPrefs.HasKey(StringHelper.LAST_TIME_ONLINE))
            {
                var temp = Convert.ToInt64(GPlayerPrefs.GetString(StringHelper.LAST_TIME_ONLINE));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
                GPlayerPrefs.SetString(StringHelper.LAST_TIME_ONLINE, newDateTime.ToBinary().ToString());
                GPlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.LAST_TIME_ONLINE, value.ToBinary().ToString());
            GPlayerPrefs.Save();
        }
    }

    public static DateTime LastTimePlayFab
    {
        get => DateTime.Parse(GPlayerPrefs.GetString(StringHelper.LAST_TIME_PLAYFAB, new DateTime().ToString()));
        set
        {
            GPlayerPrefs.SetString(StringHelper.LAST_TIME_PLAYFAB, value.ToString());
            GPlayerPrefs.Save();
        }
    }

    public static string BirdOfPlayer
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.BIRD_OF_PLAYER, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.BIRD_OF_PLAYER, value);
            GPlayerPrefs.Save();
        }

    }

    public static string DecorUserData
    {
        get
        {

            return GPlayerPrefs.GetString(StringHelper.DECOR_USER_DATA, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.DECOR_USER_DATA, value);
            GPlayerPrefs.Save();
        }
    }

    public static string PieceData
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.PIECE_DATA, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.PIECE_DATA, value);
            GPlayerPrefs.Save();
        }
    }

    public static Action evtCoinChange;
    public static int Coin
    {
        get
        {
          
			    return GPlayerPrefs.GetInt(StringHelper.COIN, 0);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.COIN, value);
            evtCoinChange?.Invoke();
            GPlayerPrefs.Save();
        }
    }
    public static int VersionData
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.VERSION_DATA, -1);
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.VERSION_DATA, value);
            PlayerPrefs.Save();
        }
    }
    public int CurrentNumAddStand
    {
        get
        {
            return GPlayerPrefs.GetInt(StringHelper.CURRENT_NUM_ADD_STAND, RemoteConfigController.GetIntConfig(FirebaseConfig.DEFAULT_NUM_ADD_STAND, 2));
        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.CURRENT_NUM_ADD_STAND, value);
            GPlayerPrefs.Save();
        }
    }

    public static string NamePlayer
    {
        get
        {
            return GPlayerPrefs.GetString("FB_NAME_v2", "");
        }
        set
        {
            GPlayerPrefs.SetString("FB_NAME_v2", value);
            GPlayerPrefs.Save();
        }
    }
    public static string AvatarLink
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.AVATAR_LINK, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.AVATAR_LINK, value);
            GPlayerPrefs.Save();
        }
    }
    public static string FlagLink
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.FLAG_LINK, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.FLAG_LINK, value);
            GPlayerPrefs.Save();
        }
    }
    public static int AvatarIDLocal
    {
        get
        {
            return GPlayerPrefs.GetInt("Avatar_ID");
        }
        set
        {

            GPlayerPrefs.SetInt("Avatar_ID", value);
            GPlayerPrefs.Save();

        }
    }

    public static int ScorePvP
    {
        get
        {
            return GPlayerPrefs.GetInt("ScorePvP");
        }
        set
        {
        
            GPlayerPrefs.SetInt("ScorePvP", value);
            GPlayerPrefs.Save();
        }
    }

    public static string JsonDataPlay
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.JSON_DATA_PLAY, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.JSON_DATA_PLAY, value);
            GPlayerPrefs.Save();
        }
    }
    public static string PlayFabId
    {
        get
        {
            return GPlayerPrefs.GetString("PlayFabId", string.Empty);
        }
        set
        {

            GPlayerPrefs.SetString("PlayFabId", value);
            GPlayerPrefs.Save();
        }
    }
    public static bool IsLoggedIn
    {
        get
        {

            return GPlayerPrefs.GetInt(StringHelper.IS_LOGGED_IN, 0) == 1;

        }
        set
        {
            GPlayerPrefs.SetInt(StringHelper.IS_LOGGED_IN, value ? 1 : 0);
            GPlayerPrefs.Save();
            
        }
    }
    public static int LastSeasonScorePvP
    {
        get
        {
            return GPlayerPrefs.GetInt("LastSeasonScorePvP");
        }
        set
        {

            GPlayerPrefs.SetInt("LastSeasonScorePvP", value);

            GPlayerPrefs.Save();

        }
    }
    public static int Tickit
    {
        get
        {
            return AdsAndIapTickit + FreeTickitPVP1;
        }
    }
    public static int AdsAndIapTickit
    {
        get
        {
            return GPlayerPrefs.GetInt("AdsAndIapTickit");
        }
        set
        {

            GPlayerPrefs.SetInt("AdsAndIapTickit", value);
            GPlayerPrefs.Save();

        }
    }
    public static int FreeTickitPVP1
    {
        get
        {
            return GPlayerPrefs.GetInt("FreeTickit", 5);
        }
        set
        {

            GPlayerPrefs.SetInt("FreeTickit", value);
            GPlayerPrefs.Save();
        }
    }
    public static bool IsLoggedInByFBorGG
    {
        get
        {
            return IsLoggedIn;
        }
    }
    public static DateTime LastTimeOnlineHomedecor
    {
        get
        {
            if (GPlayerPrefs.HasKey(StringHelper.LAST_TIME_ONLINE_HOME_DECOR))
            {
                var temp = Convert.ToInt64(GPlayerPrefs.GetString(StringHelper.LAST_TIME_ONLINE_HOME_DECOR));
                return DateTime.FromBinary(temp);
            }
            else
            {
                var newDateTime = UnbiasedTime.Instance.Now().AddDays(-1);
                GPlayerPrefs.SetString(StringHelper.LAST_TIME_ONLINE_HOME_DECOR, newDateTime.ToBinary().ToString());
                GPlayerPrefs.Save();
                return newDateTime;
            }
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.LAST_TIME_ONLINE_HOME_DECOR, value.ToBinary().ToString());
            GPlayerPrefs.Save();
        }
    }

    public static string UsedDecorItem
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.USED_DECOR_ITEM, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.USED_DECOR_ITEM, value);
            PlayerPrefs.Save();
        }
    }
    public static string OwnedDecorItem
    {
        get
        {
            return PlayerPrefs.GetString(StringHelper.OWNED_DECOR_ITEM, "");
        }
        set
        {
            PlayerPrefs.SetString(StringHelper.OWNED_DECOR_ITEM, value);
            PlayerPrefs.Save();
        }
    }
    public static string AuthCodeGG
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.AUTH_CODE_GG, "");
        }
        set
        {
            GPlayerPrefs.SetString(StringHelper.AUTH_CODE_GG, value);
            GPlayerPrefs.Save();
        }
    }

    public static long LastTimeSync
    {
        get
        {
            return long.TryParse(GPlayerPrefs.GetString(StringHelper.LAST_TIME_SYNC),out long rt) ? rt : 0;
        }
    }
    public static string LinkedId
    {
        get
        {
            return GPlayerPrefs.GetString(StringHelper.LINKED_ID,"");
        }
        set
        {
            Debug.Log("ERR: " + value);
            GPlayerPrefs.SetString(StringHelper.LINKED_ID, value);
            GPlayerPrefs.Save();
        }
    }

    public static bool IsTrackedPremission
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.IS_TRACKED_PREMISSION, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_TRACKED_PREMISSION, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static bool IsAcceptTracker
    {
        get
        {
            return PlayerPrefs.GetInt(StringHelper.IS_ACCEPT_TRACKED_PREMISSION, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(StringHelper.IS_ACCEPT_TRACKED_PREMISSION, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}



