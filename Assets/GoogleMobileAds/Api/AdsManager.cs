/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager
{


    private static AdsManager _instance;

    public static AdsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AdsManager();
            }
            return _instance;
        }
    }

    public AdsController interstitialAds;

    //public AdMobObjectController adsScript;

    public void showAd(AdLocation location)
    {
        //adsScript.ShowAd(location);
    }

}
