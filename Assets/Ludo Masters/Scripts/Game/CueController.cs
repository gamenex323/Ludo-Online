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
using AssemblyCSharp;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class CueController : MonoBehaviour, IOnEventCallback
{


    [HideInInspector]
    public bool isServer;

    public GameObject youWonMessage;
    private bool canShowControllers = true;
    public GameObject prizeText;
    private AudioSource[] audioSources;
    public GameObject audioController;
    public GameObject invitiationDialog;
    public GameObject chatButton;
    public GameControllerScript gameControllerScript;


    void Start()
    {

        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();

        if (GameManager.Instance.offlineMode)
        {
            chatButton.SetActive(false);
        }


        if (!GameManager.Instance.offlineMode)
            GameManager.Instance.playfabManager.addCoinsRequest(-GameManager.Instance.payoutCoins);


        GameManager.Instance.audioSources = audioController.GetComponents<AudioSource>();
        audioSources = GetComponents<AudioSource>();

        GameManager.Instance.iWon = false;
        GameManager.Instance.iLost = false;
        GameManager.Instance.iDraw = false;


        setPrizeText();


        GameManager.Instance.cueController = this;

        isServer = false;

        if (GameManager.Instance.roomOwner)
        {
            isServer = true;
        }

    }


    void OnApplicationPause(bool pauseStatus)
    {
        // Create an instance of RaiseEventOptions
        RaiseEventOptions options = new RaiseEventOptions();
        options.Receivers = ReceiverGroup.All; // Optional: Customize the options based on your needs

        // Send the event with RaiseEventOptions
        if (pauseStatus)
        {
            PhotonNetwork.RaiseEvent(151, 1, options, SendOptions.SendReliable); // Using RaiseEventOptions here
            //PhotonNetwork.SendOutgoingCommands();
            Debug.Log("Application paused");
        }
        else
        {
            PhotonNetwork.RaiseEvent(152, 1, options, SendOptions.SendReliable); // Using RaiseEventOptions here
            //PhotonNetwork.SendOutgoingCommands();
            Debug.Log("Application resumed");
        }
    }



    private void setPrizeText()
    {
        int prizeCoins = GameManager.Instance.payoutCoins * 2;

        if (prizeCoins >= 1000)
        {
            if (prizeCoins >= 1000000)
            {
                if (prizeCoins % 1000000.0f == 0)
                {
                    prizeText.GetComponent<Text>().text = (prizeCoins / 1000000.0f).ToString("0") + "M";

                }
                else
                {
                    prizeText.GetComponent<Text>().text = (prizeCoins / 1000000.0f).ToString("0.0") + "M";

                }

            }
            else
            {
                if (prizeCoins % 1000.0f == 0)
                {
                    prizeText.GetComponent<Text>().text = (prizeCoins / 1000.0f).ToString("0") + "k";
                }
                else
                {
                    prizeText.GetComponent<Text>().text = (prizeCoins / 1000.0f).ToString("0.0") + "k";
                }

            }
        }
        else
        {
            prizeText.GetComponent<Text>().text = prizeCoins + "";
        }

        if (GameManager.Instance.offlineMode)
        {
            prizeText.GetComponent<Text>().text = "Practice";
        }
    }




    void Awake()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void removeOnEventCall()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }


    void Update()
    {

    }

    void FixedUpdate()
    {

    }


    void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    // Multiplayer data received
    private void OnEvent(byte eventcode, object content, int senderid)
    {

        // if (!isServer && eventcode == 0)
        // {

        // }
        // else if (eventcode == 19)
        // { // Opponent Won!
        //     HideAllControllers();
        //     GameManager.Instance.audioSources[3].Play();
        //     youWonMessage.SetActive(true);
        //     youWonMessage.GetComponent<YouWinMessageChangeSprite>().changeSprite();
        //     youWonMessage.GetComponent<Animator>().Play("YouWinMessageAnimation");
        //     GameManager.Instance.iWon = false;
        // }
        // else if (eventcode == 20)
        // { // You won!
        //     HideAllControllers();
        //     GameManager.Instance.audioSources[3].Play();
        //     youWonMessage.SetActive(true);
        //     youWonMessage.GetComponent<Animator>().Play("YouWinMessageAnimation");
        //     GameManager.Instance.iWon = true;
        // }
        // else if (eventcode == 21)
        // { // You draw!
        //     HideAllControllers();
        //     GameManager.Instance.audioSources[3].Play();
        //     youWonMessage.SetActive(true);
        //     youWonMessage.GetComponent<Animator>().Play("YouWinMessageAnimation");
        //     GameManager.Instance.iDraw = true;
        // }
        // else if (eventcode == 192)
        // { // Invitiation received
        //     invitiationDialog.GetComponent<PhotonChatListener2>().showInvitationDialog(null, null, null);
        // }
        // else if (eventcode == 151)
        // { // Opponent paused game
        //     // if (isServer)
        //     //     ShotPowerIndicator.anim.Play("ShotPowerAnimation");
        //     GameManager.Instance.opponentActive = false;
        //     GameManager.Instance.stopTimer = true;
        //     GameManager.Instance.gameControllerScript.showMessage(StaticStrings.waitingForOpponent + " " + StaticStrings.photonDisconnectTimeout);
        // }
        // else if (eventcode == 152)
        // { // Opponent resumed game
        //     // if (canShowControllers && isServer && !shotMyTurnDone)
        //     //     ShotPowerIndicator.anim.Play("MakeVisible");
        //     GameManager.Instance.opponentActive = true;

        //     // if ((isServer && !shotMyTurnDone) || !isServer)
        //     GameManager.Instance.stopTimer = false;
        //     // GameManager.Instance.gameControllerScript.hideBubble();

        // }
        // else if (eventcode == 9)
        // { // My turn - show cue and lines

        //     setMyTurn();
        // }

    }

    public void setOpponentTurn()
    {
        isServer = false;
        gameControllerScript.resetTimers(2, true);
        GameManager.Instance.miniGame.setOpponentTurn();
    }

    public void setMyTurn()
    {
        GameManager.Instance.myTurnDone = false;
        isServer = true;
        gameControllerScript.resetTimers(1, true);
        GameManager.Instance.miniGame.setMyTurn();
    }

    public void checkShot()
    {
        if (GameManager.Instance.iWon)
        {
            IWon();
        }
        else if (GameManager.Instance.iLost)
        {
            ILost();
        }
    }


    public void IWon()
    {
        GameManager.Instance.iWon = true;
        HideAllControllers();
        GameManager.Instance.audioSources[3].Play();
        youWonMessage.SetActive(true);
        youWonMessage.GetComponent<Animator>().Play("YouWinMessageAnimation");
        // Define event options
        RaiseEventOptions options = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.All // Send to all players in the room
        };

        // Send reliable options
        PhotonNetwork.RaiseEvent(19, null, options, SendOptions.SendReliable);
    }

    public void Draw()
    {
        GameManager.Instance.iDraw = true;
        HideAllControllers();
        GameManager.Instance.audioSources[3].Play();
        youWonMessage.SetActive(true);
        youWonMessage.GetComponent<Animator>().Play("YouWinMessageAnimation");
        if (!GameManager.Instance.offlineMode)
        {
            // Define event options
            RaiseEventOptions options = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All // Send to all players in the room
            };

            // Send reliable options
            PhotonNetwork.RaiseEvent(21, null, options, SendOptions.SendReliable);
        }
    }

    public void ILost()
    {
        GameManager.Instance.iWon = false;
        HideAllControllers();
        GameManager.Instance.audioSources[3].Play();
        youWonMessage.SetActive(true);
        youWonMessage.GetComponent<YouWinMessageChangeSprite>().changeSprite();
        youWonMessage.GetComponent<Animator>().Play("YouWinMessageAnimation");
        if (!GameManager.Instance.offlineMode)
        {
            // Define event options
            RaiseEventOptions options = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All // Send to all players in the room
            };

            // Send reliable options
            PhotonNetwork.RaiseEvent(20, null, options, SendOptions.SendReliable);
        }
    }

    public void setTurnOffline(bool showTurnMessage)
    {

    }





    private void ShowAllControllers()
    {
        if (canShowControllers)
        {
            Debug.Log("Showing controllers");
        }
    }

    public void HideAllControllers()
    {

    }

    public void stopTimer()
    {
        GameManager.Instance.stopTimer = true;
    }

    public void OnEvent(EventData photonEvent)
    {
        throw new NotImplementedException();
    }
}
