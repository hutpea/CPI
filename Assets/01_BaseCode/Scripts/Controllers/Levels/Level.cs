using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public bool isInited;
 private float timePlayLevel;
    public virtual void Init()
    {
       
        isInited = true;
    }


    public bool IsWin()
    {
        return true;
    }

    public void CheckPassLevel()
    {
        if (GamePlayController.Instance.state == StateGame.Win)
            return;


        if (IsWin())
        {
            Win();
        }
    }

    public virtual void Win()
    {

        int _currentLevel = UseProfile.CurrentLevel;
        GamePlayController.Instance.state = StateGame.Win;

        UseProfile.CurrentLevel += 1;


        if (UseProfile.CurrentLevel > Context.MAX_LEVEL)
            UseProfile.CurrentLevel = Context.MAX_LEVEL;
        GameController.Instance.useProfile.CurrentLevelPlay = UseProfile.CurrentLevel;


        StartCoroutine(WinHandle());
        GameController.Instance.AnalyticsController.LogLevelComplet(UseProfile.CurrentLevel, (int)timePlayLevel);
    }

    public virtual IEnumerator WinHandle()
    {
        yield return new WaitForSeconds(0.5f);
        //Hiện popup win

        GameController.Instance.musicManager.PlayWinSound();
        if (GamePlayController.Instance.IsShowRate())
        {
            var rateBox = DialogueRate.Setup();
            rateBox.Show();
            rateBox.OnCloseBox = () =>
            {
                GameController.Instance.admobAds.ShowInterstitial(actionIniterClose: () =>
                {
                    GameController.Instance.LoadScene(SceneName.GAME_PLAY);
                }, actionWatchLog: "Next_Level");

                rateBox.OnCloseBox = null;
            };
        }
        else
        {
            
        }

        // Scene scene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(scene.name);
    }

    private void Update()
    {
        timePlayLevel += Time.deltaTime;
    }
}
