/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AssemblyCSharp;
using Photon.Pun;

public class YouWinMessageChangeSprite : MonoBehaviour
{

    public Sprite other;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeSprite()
    {
        GetComponent<Image>().sprite = other;
    }

    public void loadWinnerScene()
    {
        if (GameManager.Instance.offlineMode)
        {
            GameManager.Instance.playfabManager.roomOwner = false;
            GameManager.Instance.roomOwner = false;
            GameManager.Instance.resetAllData();
            SceneManager.LoadScene("MenuScene");
            ////sajidPhotonNetwork.BackgroundTimeout = StaticStrings.photonDisconnectTimeoutLong; ;
            // if (GameManager.Instance.offlineMode && StaticStrings.showAdWhenLeaveGame)
            //     AdsManager.Instance.adsScript.ShowAd();

        }
        else
        {
            SceneManager.LoadScene("WinnerScene");
        }

    }
}
