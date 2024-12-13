using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPrivateCodeDialogController : MonoBehaviourPunCallbacks
{
    public GameObject inputField;
    public GameObject confirmationText;
    public GameObject joinButton;
    private Button join;
    private InputField field;
    public GameObject GameConfiguration;
    public GameObject failedDialog;

    void OnEnable()
    {
        if (field != null)
            field.text = "";
        if (confirmationText != null)
            confirmationText.SetActive(false);
        if (join != null)
            join.interactable = false;
    }

    void Start()
    {
        field = inputField.GetComponent<InputField>();
        join = joinButton.GetComponent<Button>();
        join.interactable = false;
    }

    public void onValueChanged()
    {
        if (field.text.Length < 8)
        {
            confirmationText.SetActive(true);
            join.interactable = false;
        }
        else
        {
            confirmationText.SetActive(false);
            join.interactable = true;
        }
    }

    public void JoinByRoomID()
    {
        GameManager.Instance.JoinedByID = true;
        GameManager.Instance.payoutCoins = 0;
        string roomID = field.text;

        // Join the lobby to get the list of rooms
        PhotonNetwork.JoinLobby();
    }

    // This callback is called when the room list updates
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Rooms count: " + roomList.Count);

        if (roomList.Count == 0)
        {
            Debug.Log("No rooms available!");
            failedDialog.SetActive(true);
        }
        else
        {
            bool foundRoom = false;
            foreach (RoomInfo room in roomList)
            {
                if (room.Name.Equals(field.text))
                {
                    foundRoom = true;
                    if (room.CustomProperties.ContainsKey("pc"))
                    {
                        GameManager.Instance.payoutCoins = int.Parse(room.CustomProperties["pc"].ToString());

                        if (GameManager.Instance.myPlayerData.GetCoins() >= GameManager.Instance.payoutCoins)
                        {
                            PhotonNetwork.JoinRoom(room.Name);
                            // You can initiate the game start here if needed
                            GameConfiguration.GetComponent<GameConfigrationController>().startGame();
                        }
                    }
                    else
                    {
                        GameManager.Instance.payoutCoins = int.MaxValue;
                        GameConfiguration.GetComponent<GameConfigrationController>().startGame();
                    }
                    break;
                }
            }

            if (!foundRoom)
            {
                failedDialog.SetActive(true);
            }
        }
    }
}
