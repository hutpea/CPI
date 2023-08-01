using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    public static string settingProductName = "Bird Sort Color";

    public const string settingKeyStore = "birdsort";
    public static string keyaliasPass = "12345678two";
    public static string keystorePass = "12345678two";
    public static string settingAliasName = "birdsort";

    public const string settingLogo = "GAME_ICON";

    public static int versionCode = 2022121401;//sua
    public static string versionName = "4.0.0";//sua
    public static int settingVersionCode = 2022121401;//sua
    public static string settingVersionName = "4.0.0";//sua

    public static string productNameBuild = "Bird Sort Color";

    public static int VersionCodeAll
    {
        get
        {
            return versionCode / 100;
        }
    }

    public static int VersionFirstInstall
    {
        get
        {
            int data = PlayerPrefs.GetInt(StringHelper.VERSION_FIRST_INSTALL, 0);
            if (data == 0)
            {
                PlayerPrefs.SetInt(StringHelper.VERSION_FIRST_INSTALL, versionCode);
                data = versionCode;
            }

            return data;
        }
    }

    public static string inappAndroidKeyHash
        = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAxH15vU9+fsUnRq1d9d/ETWrY+DXxhWX3hE310JTGVRo7CLrY8auzrzvummp2MB7ryC5MbYdWrOcKgRPYvpy0qRSOB0HxEDLgHkH2rpia7n5yLoX6gSQ0KwlgC0pLDuK+2XsuayAjTg7xnbQfspzPbY+bP6vkqZAADLAue7Iq94g9QXd7ISOFjN/v7L3dppr5TtwHfZAbD+yZyreFbowGhxdMWKkMKBuskBJYD3KpO3KxSSyo/MUz0zpw2hCizOHqUIh08FG3TA7qd0y0gsWFqcPgSKkgV0JZ/WvvCd5vO4BAFuE8bpdQYKCspdUFeJ9iLqiu2agGz//Q498Iu++ogwIDAQAB";
#if UNITY_ANDROID
    public const string package_name = "com.globalplay.birdsort";
#else
    public const string package_name = "com.globalplay.birdsort";
#endif



#if UNITY_ANDROID
    public static string OPEN_LINK_RATE = "market://details?id=" + package_name;
#else
    public static string OPEN_LINK_RATE = "itms-apps://itunes.apple.com/app/id1615015886";
#endif

    public static string FanpageLinkWeb = "https://www.facebook.com/groups/402513540729752/";
    public static string FanpageLinkApp = "https://www.facebook.com/groups/402513540729752/";

    public static string LinkFeedback = "https://www.facebook.com/groups/402513540729752/";
    public static string LinkPolicy = "https://sites.google.com/view/onesoft/privacy-policy";
    public static string IdFanPage = "100086685782219";
    public static string IdGroup = "1525203137994927";
    public static string LinkTermOfSerice = "";
    public static string LinkMoreGame = "https://gplayjsc.com/";
    public static string LinkTerm = "https://sites.google.com/view/mini-game-puzzle-fun-policy/";

#if UNITY_ANDROID
    public const string IRONSOURCE_DEV_KEY = "13dd135f1";
#else
 public const string IRONSOURCE_DEV_KEY = "15c908abd";
#endif


#if UNITY_ANDROID
    public const string ADJUST_APP_TOKEN = "13dd135f1";
#else
    public const string ADJUST_APP_TOKEN = "15c908abd";
#endif
    public const string Link_Avatar_Save = "BirdSort/avatar";
    public const string FLAG_API = "https://raw.githubusercontent.com/caothecuong91/countries_flag/master/png100px/{0}.png";

    public const string StoreIDPlayFab = "Config";

#if UNITY_ANDROID
    public const string PLAYFAB_TITLE_ID = "C85C2";
#else
 public const string PLAYFAB_TITLE_ID = "C85C2";
#endif
}
