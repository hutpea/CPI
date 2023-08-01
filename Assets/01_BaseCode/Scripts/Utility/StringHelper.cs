using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringHelper
{
    public const string ONOFF_SOUND = "ONOFF_SOUND";
    public const string ONOFF_MUSIC = "ONOFF_MUSIC";
    public const string ONOFF_VIBRATION = "ONOFF_VIBRATION";
    public const string FIRST_TIME_INSTALL = "FIRST_TIME_INSTALL";

    public const string VERSION_FIRST_INSTALL = "VERSION_FIRST_INSTALL";
    public const string REMOVE_ADS = "REMOVE_ADS";
    public const string CURRENT_LEVEL = "CURRENT_LEVEL";
    public const string CURRENT_LEVEL_PLAY = "CURRENT_LEVEL_PLAY";
    public const string PATH_CONFIG_LEVEL = "Levels/Level_{0}";
    public const string PATH_CONFIG_LEVEL_TEST = "LevelsTest/Level_{0}";

    public const string SALE_IAP = "_sale";

    public const string LOGGED_REVENUE_CENTS = "logged_revenue_cents";

    public const string PREVIOUS_REVENUE_D0_D1 = "previous_revenue_d0";
    public const string REVENUE_D0_D1 = "revenue_d0";
    public const string NUMBER_OF_DISPLAYED_INTERSTITIAL_D0_D1 = "number_of_displayed_interstitial_d0";

    public const string PREVIOUS_REVENUE_D1 = "previous_revenue_d1";
    public const string REVENUE_D1 = "revenue_d1";
    public const string NUMBER_OF_DISPLAYED_INTERSTITIAL_D1 = "number_of_displayed_interstitial_d1";

    public const string RETENTION_D = "retent_type";
    public const string DAYS_PLAYED = "days_played";
    public const string PAYING_TYPE = "retent_type";
    public const string LEVEL = "level";

    public const string LAST_TIME_OPEN_GAME = "LAST_TIME_OPEN_GAME";
    public const string FIRST_TIME_OPEN_GAME = "FIRST_TIME_OPEN_GAME";

    public const string CAN_SHOW_RATE = "CAN_SHOW_RATE";

    public const string IS_TUTED_RETURN = "IS_TUTED_RETURN";
    public const string CURRENT_NUM_RETURN = "CURRENT_NUM_RETURN";
    public const string CURRENT_NUM_ADD_STAND = "CURRENT_NUM_ADD_STAND";
    public const string CURRENT_NUM_REMOVE_BOMB = "CURRENT_NUM_REMOVE_BOMB";
    public const string CURRENT_NUM_REMOVE_CAGE = "CURRENT_NUM_REMOVE_CAGE";
    public const string CURRENT_NUM_REMOVE_EGG = "CURRENT_NUM_REMOVE_EGG";
    public const string CURRENT_NUM_REMOVE_SLEEP = "CURRENT_NUM_REMOVE_SLEEP";
    public const string CURRENT_NUM_REMOVE_JAIL = "CURRENT_NUM_REMOVE_JAIL";


    public const string IS_TUTED_BUY_STAND = "IS_TUTED_BUY_STAND";
    public const string ACCUMULATION_REWARD = "ACCUMULATION_REWARD";
    public const string CURRENT_BIRD_SKIN = "CURRENT_BIRD_SKIN";
    public const string CURRENT_BRANCH_SKIN = "CURRENT_BRANCH_SKIN";
    public const string CURRENT_THEME = "CURRENT_THEME";
    public const string OWNED_BIRD_SKIN = "OWNED_BIRD_SKIN";
    public const string OWNED_BRANCH_SKIN = "OWNED_BRANCH_SKIN";
    public const string OWNED_THEME = "OWNED_THEME";
    public const string RANDOM_BIRD_SKIN_IN_SHOP = "RANDOM_BIRD_SKIN_IN_SHOP";
    public const string RANDOM_BRANCH_IN_SHOP = "RANDOM_BRANCH_IN_SHOP";
    public const string RANDOM_THEME_IN_SHOP = "RANDOM_THEME_IN_SHOP";

    public const string RANDOM_BIRD_SKIN_SALE_WEEKEND_1 = "RANDOM_BIRD_SKIN_SALE_WEEKEND_1";
    public const string RANDOM_BRANCH_SALE_WEEKEND_2 = "RANDOM_BRANCH_SALE_WEEKEND_2";
    public const string RANDOM_THEME_SALE_WEEKEND_2 = "RANDOM_THEME_SALE_WEEKEND_2";

    public const string CURRENT_RANDOM_BIRD_SKIN = "CURRENT_RANDOM_BIRD_SKIN";
    public const string CURRENT_RANDOM_BRANCH_SKIN = "CURRENT_RANDOM_BRANCH_SKIN";
    public const string CURRENT_RANDOM_THEME = "CURRENT_RANDOM_THEME";


    public const string NUM_SHOWED_ACCUMULATION_REWARD_RANDOM = "NUM_SHOWED_ACCUMULATION_REWARD_RANDOM";

    public const string NUMBER_OF_ADS_IN_DAY = "NUMBER_OF_ADS_IN_DAY";
    public const string NUMBER_OF_ADS_IN_PLAY = "NUMBER_OF_ADS_IN_PLAY";

    public const string IS_PACK_PURCHASED_ = "IS_PACK_PURCHASED_";
    public const string NUM_OF_PURCHASED_ = "NUM_OF_PURCHASED_";
    
    public const string IS_PACK_ACTIVATED_ = "IS_PACK_ACTIVATED_";
    public const string LAST_TIME_PACK_ACTIVE_ = "LAST_TIME_PACK_ACTIVE_";
    public const string LAST_TIME_PACK_SHOW_HOME_ = "LAST_TIME_PACK_SHOW_HOME_";
    public const string STARTER_PACK_IS_COMPLETED = "STARTER_PACK_IS_COMPLETED";

    public const string HAS_PACK_IN_WEEK_TODAY = "HAS_PACK_IN_WEEK_TODAY";
    public const string HAS_PACK_WEEKEND_TODAY = "HAS_PACK_WEEKEND_TODAY";

    public const string CURRENT_PACK_IN_WEEK = "CURRENT_PACK_IN_WEEK";
    public const string CURRENT_PACK_WEEKEND = "CURRENT_PACK_WEEKEND";
    public const string CURRENT_RANDOM_SET_SKIN = "CURRENT_RANDOM_SET_SKIN";


    public const string LAST_TIME_RESET_SALE_PACK_SHOP = "LAST_TIME_RESET_SALE_PACK_SHOP";

    public const string LAST_TIME_ONLINE = "LAST_TIME_ONLINE";
    public const string LAST_TIME_ONLINE_HOME_DECOR = "last_time_online_home_decor";
    public const string CURRENT_ID_MINI_GAME = "current_id_mini_game";

    public const string LAST_TIME_PLAYFAB = "Last_Time_PlayFab";
    

    public const string DECOR_USER_DATA = "Decor_User_Data";
    public const string DECOR_ITEM_DATA = "Decor_Item_Data";
    public const string DECOR_ROOM_DATA = "Decor_Room_Data";
    public const string COIN = "Coin";
    public const string PIECE_DATA = "piece_data";

    public const string BIRD_OF_PLAYER = "bird_of_player";
    public const string JSON_DATA_PLAY = "json_data_play";
    public const string VERSION_DATA = "version_data";
    public const string AVATAR_LINK = "avatar_link";
    public const string FLAG_LINK = "flag_link";
    public const string IS_LOGGED_IN = "is_logged_in";
    public static string SENCE_NAME;
    public static string OPEN_POPUP_PVP = "open_popup_pvp";
    public static string TIME_COOLDOWN_FREE_TICKIT = "time_cooldown_free_tickit";
    public static string WAS_CLAIM_REWARD_PVP = "was_claim_reward_pvp";

    public static string FREE_TICKIT_PVP = "free_tickit_pvp";
    public static string OPEN_POPUP_SEASON_ENDED = "open_popup_season_ended";
    public static string CONFIG_ON_OFF_HOME_DECOR = "config_on_off_home_decor";

    public const string AUTH_CODE_GG = "auth_code_gg";
	 public static string USED_DECOR_ITEM = "USED_DECOR_ITEM";
    public static string OWNED_DECOR_ITEM = "OWNED_DECOR_ITEM";


    public const string PVP_CURRENT_ROOM = "PVP_CURRENT_ROOM";
    public const string LAST_TIME_SYNC = "lastTimeSync";
    public const string MAX_RANK = "MAX_RANK";

public static string PURCHASED_PACK = "PURCHASED_PACK";


    public const string VERSION_MINI_GAME_MINIGAME = "version_mini_game_minigame";
    public const string POINT_MINIGAME_CONNECT_BIRD = "point_minigame_connect_bird";
    public const string LIST_REWARD_MINI_GAME_CONNECT_BIRD = "list_reward_mini_game_connect_bird";
    public const string WAS_COMMPLETE_MINI_GAME_CONNECT_BIRD = "was_commplete_mini_game_connect_bird";
    public const string CONNECT_BIRD_TURN_FREE = "connect_bird_turn_free";
    public const string CONNECT_BIRD_TURN_BUY = "connect_bird_turn_buy";
    public const string LIMIT_NUMB_WATCH_VIDEO_IN_DAY = "limit_numb_watch_video_in_day";
    public const string FIRST_OPEN_CONNECT_BIRD_MINI_GAME = "first_open_connect_bird_mini_game";
    public const string FIRST_SHOW_HAND = "first_show_hand";
    public const string CURRENT_NUM_WATCH_VIDEO_IN_DAY_MINI_GAME_CONNECT_BIRD = "current_num_watch_video_in_day_mini_game_connect_bird";
    public const string DATA_TO_RESET_MINI_GAME_CONNECT_BIRD = "data_to_reset_mini_game_connect_bird";
    public const string FIRST_WEEK = "first_week";

    public const string TIME_WATCHED_SPECIAL_VIDEO_ = "time_watched_special_video_";


    public const string LINKED_ID = "linked_id";

    public const string IS_TRACKED_PREMISSION = "is_tracked_premission";
    public const string IS_ACCEPT_TRACKED_PREMISSION = "is_accept_tracked_premission";
}

public class PathPrefabs
{
    public const string POPUP_REWARD_BASE = "UI/Popups/PopupRewardBase";
    public const string CONFIRM_POPUP = "UI/Popups/ConfirmBox";
    public const string WAITING_BOX = "UI/Popups/WaitingBox";
    public const string WIN_BOX = "UI/Popups/WinBox";
    public const string REWARD_IAP_BOX = "UI/Popups/RewardIAPBox";
    public const string SHOP_BOX = "UI/ShopBox";
    public const string RATE_GAME_BOX = "UI/Popups/RateGameBox";
    public const string SETTING_BOX = "UI/Popups/SettingBox";
    public const string LOSE_BOX = "UI/Popups/LoseBox";
    public const string REWARD_CONGRATULATION_BOX = "UI/Popups/RewardCongratulationBox";
    public const string SHOP_GAME_BOX = "UI/Popups/ShopBox";
    public const string CONGRATULATION_BOX = "UI/Popups/CongratulationBox";

    public const string STARTER_PACK_BOX = "UI/Popups/PackBoxes/StarterPackBox";
    public const string THREE_SKIN_BIRD_PACK_BOX = "UI/Popups/PackBoxes/ThreeSkinBirdPackBox";
    public const string TWO_BRANCH_THEME_PACK_BOX = "UI/Popups/PackBoxes/TwoBranchThemePackBox";
    public const string SET_SKIN_PACK_BOX = "UI/Popups/PackBoxes/SetSkinPackBox";

    public const string HALLOWEEN_SALE_PACK_1_BOX = "UI/Popups/PackBoxes/HalloweenSalePack1Box";
    public const string HALLOWEEN_SALE_PACK_2_BOX = "UI/Popups/PackBoxes/HalloweenSalePack2Box";
 public const string BRANCH_AND_THEME_PACK_BOX = "UI/Popups/PackBoxes/BranchAndThemePackBox";

    public const string BIG_REMOVE_ADS_PACK_BOX = "UI/Popups/PackBoxes/BigRemoveAdsPackBox";
    public const string SALE_WEEKEND_1_PACK_BOX = "UI/Popups/PackBoxes/SaleWeekend1PackBox";
    public const string SALE_WEEKEND_2_PACK_BOX = "UI/Popups/PackBoxes/SaleWeekend2PackBox";
    public const string SALE_WEEKEND_3_PACK_BOX = "UI/Popups/PackBoxes/SaleWeekend3PackBox";

   
    public const string BLACK_FRIDAY_SALE_PACK_1_BOX = "UI/Popups/PackBoxes/BlackFridaySalePack1Box";
    public const string BLACK_FRIDAY_SALE_PACK_2_BOX = "UI/Popups/PackBoxes/BlackFridaySalePack2Box";

    public const string CHRISTMAS_SALE_PACK_1_BOX = "UI/Popups/PackBoxes/ChristmasSalePack1Box";
    public const string CHRISTMAS_SALE_PACK_2_BOX = "UI/Popups/PackBoxes/ChristmasSalePack2Box";
    public const string CHRISTMAS_SALE_PACK_3_BOX = "UI/Popups/PackBoxes/ChristmasSalePack3Box";

    public const string MINI_GAME_CONNECT_BIRD_BOX = "UI/Popups/ConnectBirdMGBox";
    public const string MINI_GAME_TRIPLE_BIRD_BOX = "UI/Popups/TripleBirdMGBox";
    public const string CONNECT_BIRD_MINI_GAME_SHOP_BOX = "UI/Popups/ConnectBirdMiniGameShop";
    public const string TRIPLE_BIRD_MINI_GAME_SHOP_BOX = "UI/Popups/TripleBirdMiniGameShop";
    public const string REWARD_CONNECT_BIRD_MN_BOX = "UI/Popups/RewardConnectBirdMNBox";
    public const string REWARD_TRIPLE_BIRD_MN_BOX = "UI/Popups/RewardTripleBirdMNBox";
 

    public const string DECOR_BOX = "UI/Popups/Decoration/DecorBox";
    public const string DECOR_ITEM_BOX = "UI/Popups/Decoration/DecorItemBox";
    public const string SELECT_ROOM_BOX = "UI/Popups/Decoration/SelectRoomBox";
    public const string DECOR_ROOM_BOX = "UI/Popups/Decoration/DecorRoomBox";
    public const string DECOR_SHOP_BOX = "UI/Popups/Decoration/DecorShopBox";
    public const string SHOP_CONFIRM_BOX = "UI/Popups/Decoration/ShopConfirmBox";
    public const string BIRD_SHOP_BOX = "UI/Popups/BirdShopBox";
    public const string BIRD_SHOP_CONFIRM_BOX = "UI/Popups/BirdShopConfirmBox";
    public const string FOOD_BIRD_BOX = "UI/Popups/FoodBirdBox";
    public const string FOOD_SELECT_BOX = "UI/Popups/FoodSelectBox";
    public const string BIRD_CARE_BOX = "UI/Popups/BirdCareBox";
    public const string BATH_ROOM_BOX = "UI/Popups/BathRoomBox";

    public const string LOSE_PVP_BOX = "UI/Popups/LosePvPBox";

    public const string SESON_PVP_END_BOX = "UI/Popups/SesonPvPEndBox";
    public const string END_MINI_GAME_BOX = "UI/Popups/EndMiniGameBox";
    public const string MAKE_UP_ROOM_BOX = "UI/Popups/MakeUpRoomBox";
    public const string PLAY_ROOM_BOX = "UI/Popups/PlayRoomBox";  
    public const string FIGHT_PVP_BOX = "UI/Popups/FightPvPBox";

    public const string MATCH_OTHER_PLAYER_PVP_BOX = "UI/Popups/MatchOtherPlayerPvPBox";
    public const string SHOP_TICKIT_PVP_BOX = "UI/Popups/ShopTickitPvPBox";
 
    public const string SUGGET_LOGIN_PVP_BOX = "UI/Popups/SuggetLoginPvPBox";
    public const string POPUP_SELECT_AVATAR = "UI/Popups/PopupSelectAvatar";

    public const string LEADER_BOARD_PVP_BOX = "UI/Popups/LeaderBoardPvPBox";
    public const string WIN_PVP_BOX = "UI/Popups/WinPvPBox";
    public const string RANK_UP_PVP_BOX = "UI/Popups/RankUpPvPBox";
    public const string POPUP_CLAIM = "UI/Popups/PopupClaim";
    public const string FEATURE_BOX = "UI/Popups/FeatureBox";


    public const string CREDIT_BOX = "UI/Popups/CreditBox";
    public const string TRACKING_BOX = "UI/Popups/TrackingBox";
}


public class SceneName
{
    public const string LOADING_SCENE = "LoadingScene";
    public const string HOME_SCENE = "HomeScene";
    public const string GAME_PLAY = "GamePlay";
    public const string HOME_SCENE_PVP = "HomeScenePvP";
    public const string GAME_PLAY_PVP1 = "GamePlayPvP1";
    public const string HOME_SCENE_HOME_DECOR = "HomeSceneHomeDecor";

}


public class ActionOfBird
{
    public const string IDLE = "GAMEPLAY/idle";
    public const string EAT = "EATING/EATING";
    public const string SHOWER_SHAKING = "SHOWER/SHAKING";
    public const string SHOWER_ARGRY = "SHOWER/ANGRY";
}


public class AudioName
{
    public const string bgMainHome = "Music_BG_MainHome";
    public const string bgGamePlay = "Music_BG_GamePlay";

    //Ingame music
    public const string winMusic = "winMusic";
    public const string spawnerPlayerMusic = "spawnerPlayer";

    //Action Player music
    public const string jumpMusic = "jump";
    public const string jumpEndMusic = "jumpEnd";
    public const string swapMusic = "swap";
    public const string pushRockMusic = "pushRock";
    public const string dieMusic = "die";
    public const string reviveMusic = "revive";
    public const string flyMusic = "fly";

    //Collect music
    public const string collectCoinMusic = "collectCoin";
    public const string collectKeyMusic = "collectKey";
    public const string collectItemSound = "collectItem";

    //Level music
    public const string jumpOnWaterMusic = "jumpOnWater";
    public const string collisionDoorMusic = "collisionDoor";
    public const string doorOpenMusic = "doorOpen";
    public const string doorCloseMusic = "doorClose";
    public const string springMusic = "spring";
    public const string touchSwitchMusic = "touchSwitch";
    public const string bridgeMoveMusic = "bridgeMove";
    public const string bridgeMoveEndMusic = "bridgeMoveEnd";
    public const string iceDropFall = "rock1";
    public const string iceDropExplosion = "bigrock";
    public const string activeDiamond = "crystalactive";
    public const string releaseDiamond = "crystalrelease";
    //UI Music
    public const string buttonClick = "buttonClick";
}

public class KeyPref
{
    public const string SERVER_INDEX = "SERVER_INDEX";
}

public class FirebaseConfig
{

    public const string DELAY_SHOW_INITSTIALL = "delay_show_initi_ads";//Thời gian giữa 2 lần show inital 30
    public const string LEVEL_START_SHOW_INITSTIALL = "level_start_show_initstiall";//Level bắt đầu show initial//3


    public const string LEVEL_START_SHOW_RATE = "level_start_show_rate";//Level bắt đầu show popuprate

    public const string DEFAULT_NUM_ADD_BRANCH = "default_num_add_branch";//2
    public const string DEFAULT_NUM_REMOVE_BOMB = "default_num_remove_bomb";//0
    public const string DEFAULT_NUM_REMOVE_EGG = "default_num_remove_egg";//0
    public const string DEFAULT_NUM_REMOVE_JAIL = "default_num_remove_jail";//0
    public const string DEFAULT_NUM_REMOVE_SLEEP = "default_num_remove_sleep";//0
    public const string DEFAULT_NUM_REMOVE_CAGE = "default_num_remove_cage";//0

    public const string DEFAULT_NUM_RETURN = "default_num_return";//2
    public const string NUM_RETURN_CLAIM_VIDEO_REWARD = "num_return_claim_video_reward";//3

    public const string LEVEL_START_TUT_RETURN = "level_start_tut_return";//4
    public const string LEVEL_START_TUT_BUY_STAND = "level_start_tut_buy_stand";//5

    public const string ON_OFF_REMOVE_ADS = "on_off_remove_ads_2";//5
    public const string MAX_LEVEL_SHOW_RATE = "max_level_show_rate";//30

    public const string TEST_LEVEL_CAGE_BOOM = "test_level_cage_boom_ver2";//30

    public const string ON_OFF_ACCUMULATION_REWARD_LEVEL_START = "on_off_accumulation_reward_level_start";//true
    public const string ACCUMULATION_REWARD_LEVEL_START = "accumulation_reward_level_start";//6
    public const string ACCUMULATION_REWARD_END_LEVEL = "accumulation_reward_end_level_{0}";//
    public const string ACCUMULATION_REWARD_TIME_SHOW_NEXT_BUTTON = "accumulation_reward_time_show_next_button";//1.5
    public const string ACCUMULATION_REWARD_END_LEVEL_RANDOM = "accumulation_reward_end_level_random";//10
    public const string MAX_TURN_ACCUMULATION_REWARD_END_LEVEL_RANDOM = "max_turn_accumulation_reward_end_level_random";//150

    public const string ON_OFF_SALE_INAPP = "on_off_sale_inapp";//true

    public const string LEVEL_UNLOCK_SALE_PACK = "level_unlock_sale_pack"; //11
    public const string LEVEL_UNLOCK_PREMIUM_PACK = "level_unlock_premium_pack"; //25
    public const string TIME_LIFE_STARTER_PACK = "time_life_starter_pack"; // 3DAY
    public const string TIME_LIFE_PREMIUM_PACK = "time_life_premium_pack"; // 2DAY
    public const string TIME_LIFE_SALE_PACK = "time_life_premium_pack"; // 1DAY
    public const string TIME_LIFE_BIG_REMOVE_ADS_PACK = "time_life_big_remove_ads_pack"; // 3h

    public const string NUMBER_OF_ADS_IN_DAY_TO_SHOW_PACK = "number_of_ads_in_day_to_show_pack"; //5ADS
    public const string NUMBER_OF_ADS_IN_PLAY_TO_SHOW_PACK = "number_of_ads_in_play_to_show_pack"; //3ADS
    public const string TIME_DELAY_SHOW_POPUP_SALE_PACK_ = "time_delay_show_popup_sale_pack_"; // 6H
    public const string TIME_DELAY_ACTIVE_SALE_PACK = "time_delay_active_sale_pack_"; // 6H

    public const string CONFIG_SALE_PACK_HALLOWEEN = "config_sale_pack_halloween";
    public const string CONFIG_SALE_PACK_BLACK_FRIDAY = "config_sale_pack_black_friday";
    public const string CONFIG_SALE_PACK_CHRISTMAS = "config_sale_pack_christmas";

    public const string CONFIG_EVENT_GAME = "config_event_game";

    public const string GAME_THEME_CONFIG = "game_theme_config";
 public const string TIME_COOL_DOWN_RETURN_PVP1 = "time_cool_down_return_pvp1";
    public const string TIME_COOL_DOWN_REPLAY_PVP1 = "time_cool_down_replay_pvp1";
    public const string SENCE_GAMEPLAY_OLD = "sence_gameplay_old";
    public const string ON_OFF_PVP1 = "on_off_pvp1";
    public const string DEFAULT_NUM_ADD_STAND = "default_num_add_stand";
    public const string TIME_COOL_DOWN_PVP1_TICKET = "time_cool_down_pvp1_ticket";


    public const string JSON_DATA_PLAY = "DTXYZ";

    public static string SENCE_NAME;
    public const string OPEN_POPUP_SEASON_ENDED = "open_popup_season_ended";
    public const string WAS_CLAIM_REWARD_PVP = "was_claim_reward_pvp";
    public const string VERSION_DATA = "version_data";
    public const string AVATAR_LINK = "avatar_link";
    public const string FLAG_LINK = "flag_link";
    public const string IS_LOGGED_IN = "is_logged_in";
    public const string OPEN_POPUP_PVP = "open_popup_pvp";

    public const string TIME_COOLDOWN_FREE_TICKIT = "time_cooldown_free_tickit";

    public const string POPUP_PVP = "UI/Popups/PopupPvP";
    public const string POPUP_MACTH = "UI/Popups/PopupMacth";
    public const string POPUP_BUY_TICKIT = "UI/Popups/PopupBuyTickit";
    public const string POPUP_SUGGET_LOGIN = "UI/Popups/PopupSuggetLogin";
    public const string POPUP_SELECT_AVATAR = "UI/Popups/PopupSelectAvatar";
    public const string POPUP_LEADER_BOARD = "UI/Popups/PopupLeaderBoard";
    public const string POPUP_WIN_PVP = "UI/Popups/PopupWinPvP";
    public const string POPUP_RANK_UP = "UI/Popups/PopupRankUp";
    public const string POPUP_CLAIM = "UI/Popups/PopupClaim";
    public const string POPUP_LOSE_PVP = "UI/Popups/PopupLosePvP";
    public const string POPUP_SEASON_ENDED = "UI/Popups/PopupSeasonEnded";
}

public class DataPlayFab
{
    public const string PLAYFAB_ID = "PLAY_FAB_ID";
    public const string TABLE_PLAYERDATA = "DATA_NORMAL_PLAYER";
}
