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
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.SceneManagement;
using AssemblyCSharp;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayFabAddFriend : MonoBehaviour
{

    public GameObject menuObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void AddFriend()
    {
        menuObject.GetComponent<Animator>().Play("hideMenuAnimation");
        if (!GameManager.Instance.offlineMode)
        {
            // Create an instance of RaiseEventOptions
            RaiseEventOptions options = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All, // Send to all players
                InterestGroup = 0, // Use 0 if no group restrictions are needed
                CachingOption = EventCaching.DoNotCache // Optional: decide on caching behavior
            };

            // Raise the event with the options object
            PhotonNetwork.RaiseEvent(192, 1, options, SendOptions.SendReliable);




            AddFriendRequest request = new AddFriendRequest()
            {
                FriendPlayFabId = PhotonNetwork.PlayerListOthers[0].NickName
            };



            PlayFabClientAPI.AddFriend(request, (result) =>
            {
                Debug.Log("Added friend successfully");
                GameManager.Instance.friendButtonMenu.SetActive(false);
                GameManager.Instance.smallMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(GameManager.Instance.smallMenu.GetComponent<RectTransform>().sizeDelta.x, 260.0f);
            }, (error) =>
            {
                Debug.Log("Error adding friend: " + error.Error);
            }, null);
        }

    }

    public void showMenu()
    {
        menuObject.GetComponent<Animator>().Play("ShowMenuAnimation");
    }

    public void hideMenu()
    {
        menuObject.GetComponent<Animator>().Play("hideMenuAnimation");
    }

    public void LeaveGame()
    {
        // if (StaticStrings.showAdWhenLeaveGame)
        //     AdsManager.Instance.adsScript.ShowAd();
        SceneManager.LoadScene("MenuScene");
        ////sajidPhotonNetwork.BackgroundTimeout = StaticStrings.photonDisconnectTimeoutLong; ;
        Debug.Log("Timeout 3");
        //GameManager.Instance.cueController.removeOnEventCall();
        PhotonNetwork.LeaveRoom();

        GameManager.Instance.playfabManager.roomOwner = false;
        GameManager.Instance.roomOwner = false;
        GameManager.Instance.resetAllData();

    }
}
