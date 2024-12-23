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
using ExitGames.Client.Photon;
using UnityEngine.UI;
using Photon;
using AssemblyCSharp;
using Photon.Pun;

public class PhotonChatListener : MonoBehaviourPunCallbacks
{

    private Animator animator;
    public Text text;
    private string senderID;
    private string roomName;
    // "invited"
    // "accepted"
    public string type;
    public GameObject okButton;
    public GameObject rejectButton;
    public GameObject acceptButton;
    public GameObject matchPlayersCanvas;
    public GameObject friendsCanvas;
    public GameObject menuCanvas;
    public GameObject gameTitle;
    public GameObject payoutCoinsText;
    bool leftRoom = false;
    bool Joined = false;
    // Use this for initialization
    void Start()
    {
        GameManager.Instance.invitationDialog = this.gameObject;
        animator = GetComponent<Animator>();

    }

    public void showInvitationDialog(int type, string name, string id, string room, int tableNumber)
    {

        if (PlayerPrefs.GetInt(StaticStrings.PrivateRoomKey, 0) == 0)
        {
            leftRoom = false;
            Joined = false;

            payoutCoinsText.GetComponent<Text>().text = "" + GameManager.Instance.payoutCoins;
            rejectButton.SetActive(true);
            acceptButton.SetActive(true);
            okButton.SetActive(false);

            this.type = "invited";
            senderID = id;
            roomName = room;

            text.text = name + " invite you to private room.";
            animator.Play("InvitationDialogShow");
        }
        else
        {
            Debug.Log("Invitations OFF");
        }



    }



    public override void OnConnectedToMaster()
    {
        if (!Joined && leftRoom)
        {
            JoinRoom("accepted");
            Joined = true;
        }
    }

    public void JoinRoom(string a)
    {

        if (a.Equals("accepted"))
        {

            Debug.Log("Trying to join room: " + roomName);
            if (GameManager.Instance.myPlayerData.GetCoins() >= GameManager.Instance.payoutCoins)
            {
                PhotonNetwork.JoinRoom(roomName);
                if (GameManager.Instance.type != MyGameType.Private)
                {
                    GameManager.Instance.facebookManager.startRandomGame();
                }
                else
                {
                    if (GameManager.Instance.JoinedByID)
                    {
                        Debug.Log("Joined by id!");

                        GameManager.Instance.matchPlayerObject.GetComponent<SetMyData>().MatchPlayer();
                    }
                    else
                    {
                        Debug.Log("Joined and created");
                        GameManager.Instance.playfabManager.CreatePrivateRoom();
                        GameManager.Instance.matchPlayerObject.GetComponent<SetMyData>().MatchPlayer();
                    }

                }
            }
            else
            {
                GameManager.Instance.dialog.SetActive(true);
            }
        }

    }

    public void hideDialog(string a)
    {
        GameManager.Instance.type = MyGameType.Private;

        GameManager.Instance.JoinedByID = true;

        if (PhotonNetwork.CurrentRoom != null)
        {
            leftRoom = true;
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            JoinRoom(a);
        }


        animator.Play("InvitationDialogHide");
    }

}
