using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using UniRx;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using AppsFlyerSDK;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;

public class Context
{
    public static int MAX_LEVEL
    {
        get
        {
            if (RemoteConfigController.GetBoolConfig(FirebaseConfig.TEST_LEVEL_CAGE_BOOM, true))
                return 4000;
            else
                return 4000;
        }    
    }

    private static ProfileModel profile;
    public static ProfileModel CurrentUserPlayfabProfile
    {
        get
        {
            if (profile == null) return new ProfileModel();
            return profile;
        }
        set
        {
            profile = value;
        }
    }

    public static void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public static int GetSDKLevel()
    {
        var clazz = AndroidJNI.FindClass("android.os.Build$VERSION");
        var fieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
        var sdkLevel = AndroidJNI.GetStaticIntField(clazz, fieldID);
        return sdkLevel;
    }

    public static IObservable<Texture2D> DownloadOrCache(string url, bool isLoadAvatar = true)
    {
        if (string.IsNullOrEmpty(url))
        {
            return Observable.Return(GameServices.defaultAvatar);
        }
        string fileUrl = "";

        if (isLoadAvatar)
        {
            if (url.Contains(Config.Link_Avatar_Save))
            {
                string linkTemp = url;
                var splitLink = url.Split('/');

                if (splitLink != null && splitLink.Length > 0)
                {
                    var splitName = splitLink[splitLink.Length - 1].Split('.');

                    string nameLink = "";
                    if (splitName != null && splitName.Length > 0)
                        nameLink = splitName[0];

                    if (nameLink != "")
                    {
                        // Debug.Log("Reslut " + nameLink);
                        ResourceRequest request = Resources.LoadAsync<Texture2D>(nameLink);
                        return Observable.Return(request.asset as Texture2D);
                    }
                }
            }
        }

        // Debug.Log("url " + url + "  fileID " + fileID);
        string downloadUrl = getCachedWWW(url, out fileUrl);

        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(downloadUrl);

        return webRequest.SendWebRequest().AsObservable().Do(_ =>
        {
            if (_.isDone)
            {
                var strUri = webRequest.uri.AbsoluteUri;
                if (!Regex.IsMatch(strUri.Substring(strUri.Length - 4), @"^.*\.(gif)"))
                    File.WriteAllBytes(fileUrl, webRequest.downloadHandler.data);
            }
        }).Select(www =>
        {
            var strUri = webRequest.uri.AbsoluteUri;
            if (Regex.IsMatch(strUri.Substring(strUri.Length - 4), @"^.*\.(gif)"))
            {
                var _text = Resources.Load("avatar") as Texture2D;
                return _text;
            }
            else
            {
                return DownloadHandlerTexture.GetContent(webRequest);
            }
        }).Where(texture => (texture != null)).CatchIgnore();
    }



    public static IObservable<Texture> Download(string url)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);

        return webRequest.SendWebRequest().AsObservable().Select(www => DownloadHandlerTexture.GetContent(webRequest)).Where(texture => (texture != null)).CatchIgnore();
    }

    public static string getCachedWWW(string url, out string fileUrl, bool forceDownload = false)
    {
        var length = Mathf.Clamp(100, 0, url.Length);
        string fileID = url.Substring(url.Length - length, length);
        string filePath = Application.persistentDataPath;
        filePath += "/" + Regex.Replace(Convert.ToBase64String(Encoding.UTF8.GetBytes(fileID)), "[^A-Za-z0-9_. ]+", "");
        bool useCached = false;
        useCached = File.Exists(filePath);
        if (useCached)
        {
            //check how old
            DateTime written = File.GetLastWriteTimeUtc(filePath);
            DateTime now = DateTime.UtcNow;
            double TotalMinutes = now.Subtract(written).TotalMinutes;
            if (GSocket.IntenetAvaiable)
            {
                if (forceDownload || TotalMinutes > RemoteConfigController.GetIntConfig("download_cached_time", 2880))
                {
                    useCached = false;
                    File.Delete(filePath);
                }
            }
        }

        string pathforwww;
        if (File.Exists(filePath))
        {
            pathforwww = "file://" + filePath;
        }
        else
        {
            pathforwww = url;
        }
        fileUrl = filePath;
        return pathforwww;
    }


    public static CountryCode countryCode = CountryCode.NONE;
    private static string Country_Code
    {
        get
        {
            return PlayerPrefs.GetString("country_code");
        }
        set
        {
            PlayerPrefs.SetString("country_code", value);
        }
    }
    public static CountryCode CountryCode
    {
        get
        {
            if (countryCode == CountryCode.NONE && !string.IsNullOrEmpty(Country_Code))
            {
                countryCode = (CountryCode)Enum.Parse(typeof(CountryCode), Country_Code);
            }
            return countryCode;
        }
    }

    public static void InitOnConnectInterner()
    {
        #region LoadCountry
        ObservableWWW.Get("http://ip-api.com/json/")
        .CatchIgnore()
        .Subscribe(resp =>
        {
            try
            {
                IpLocation ipLocation = JsonUtility.FromJson<IpLocation>(resp);
                Country_Code = ipLocation.countryCode;
                countryCode = (CountryCode)Enum.Parse(typeof(CountryCode), ipLocation.countryCode);
            }
            catch (Exception ex)
            {
                Debug.LogError("Ex" + ex.Message);
                Debug.LogError("Ex" + ex.Message);
            }
        });
        #endregion

    }
}

public class IpLocation
{
    public string _as;
    public string city;
    public string country;
    public string countryCode;
    public string isp;
    public float lat;
    public float lon;
    public string org;
    public string query;
    public string region;
    public string regionName;
    public string status;
    public string timezone;
    public string zip;
}

public enum CountryCode
{
    AF,
    AX,
    AL,
    DZ,
    AS,
    AD,
    AO,
    AI,
    AQ,
    AG,
    AR,
    AM,
    AW,
    AU,
    AT,
    AZ,
    BS,
    BH,
    BD,
    BB,
    BY,
    BE,
    BZ,
    BJ,
    BM,
    BT,
    BO,
    BQ,
    BA,
    BW,
    BV,
    BR,
    IO,
    BN,
    BG,
    BF,
    BI,
    KH,
    CM,
    CA,
    CV,
    KY,
    CF,
    TD,
    CL,
    CN,
    CX,
    CC,
    CO,
    KM,
    CG,
    CD,
    CK,
    CR,
    CI,
    HR,
    CU,
    CW,
    CY,
    CZ,
    DK,
    DJ,
    DM,
    DO,
    EC,
    EG,
    SV,
    GQ,
    ER,
    EE,
    ET,
    FK,
    FO,
    FJ,
    FI,
    FR,
    GF,
    PF,
    TF,
    GA,
    GM,
    GE,
    DE,
    GH,
    GI,
    GR,
    GL,
    GD,
    GP,
    GU,
    GT,
    GG,
    GN,
    GW,
    GY,
    HT,
    HM,
    VA,
    HN,
    HK,
    HU,
    IS,
    IN,
    ID,
    IR,
    IQ,
    IE,
    IM,
    IL,
    IT,
    JM,
    JP,
    JE,
    JO,
    KZ,
    KE,
    KI,
    KP,
    KR,
    KW,
    KG,
    LA,
    LV,
    LB,
    LS,
    LR,
    LY,
    LI,
    LT,
    LU,
    MO,
    MK,
    MG,
    MW,
    MY,
    MV,
    ML,
    MT,
    MH,
    MQ,
    MR,
    MU,
    YT,
    MX,
    FM,
    MD,
    MC,
    MN,
    ME,
    MS,
    MA,
    MZ,
    MM,
    NA,
    NR,
    NP,
    NL,
    NC,
    NZ,
    NI,
    NE,
    NG,
    NU,
    NF,
    MP,
    NO,
    OM,
    PK,
    PW,
    PS,
    PA,
    PG,
    PY,
    PE,
    PH,
    PN,
    PL,
    PT,
    PR,
    QA,
    RE,
    RO,
    RU,
    RW,
    BL,
    SH,
    KN,
    LC,
    MF,
    PM,
    VC,
    WS,
    SM,
    ST,
    SA,
    SN,
    RS,
    SC,
    SL,
    SG,
    SX,
    SK,
    SI,
    SB,
    SO,
    ZA,
    GS,
    SS,
    ES,
    LK,
    SD,
    SR,
    SJ,
    SZ,
    SE,
    CH,
    SY,
    TW,
    TJ,
    TZ,
    TH,
    TL,
    TG,
    TK,
    TO,
    TT,
    TN,
    TR,
    TM,
    TC,
    TV,
    UG,
    UA,
    AE,
    GB,
    US,
    UM,
    UY,
    UZ,
    VU,
    VE,
    VN,
    VG,
    VI,
    WF,
    EH,
    YE,
    ZM,
    ZW,
    NONE
}
