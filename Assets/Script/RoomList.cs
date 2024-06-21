using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Runtime.CompilerServices;
public class RoomList : MonoBehaviourPunCallbacks
{
    public static RoomList instance;

    public GameObject roomManagerGameobject;
    public RoomManager roomManager;



    [Header("UI")] public Transform roomListParent;

    public GameObject roomListPrefab;

    private List<RoomInfo> cachedRoomList = new List<RoomInfo>();

    public void ChangeRoomToCreateName(string _roomname)
    {
         roomManager.roomNameToJoin = _roomname;
    }

    private void Awake()
    {
        instance = this;
    }
    IEnumerator Start()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
        }

        yield return new WaitUntil(() => !PhotonNetwork.IsConnected);


        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       if(cachedRoomList.Count <= 0)
        {
            cachedRoomList = roomList;
        }
       else
        {
            foreach(var room in roomList)
            {
                for(int i=0; i<cachedRoomList.Count; i++)
                {
                    if (cachedRoomList[i].Name == room.Name)
                    {
                        List<RoomInfo> newList = cachedRoomList;

                        if(room.RemovedFromList)
                        {
                            newList.Remove(newList[i]);
                        }
                        else
                        {
                            newList[i] = room;
                        }

                        cachedRoomList = newList;
                    }
                }
            }
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach(Transform roomItem in roomListParent)
        {
            Destroy(roomItem.gameObject);
        }

        foreach(var room in cachedRoomList)
        {
            GameObject roomItem = Instantiate(roomListPrefab, roomListParent);

            roomItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = room.Name;
            roomItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = room.PlayerCount + "/16";

            roomItem.GetComponent<RoomItemBtn>().RoomName = room.Name; 
        }
    }

    public void JoinRoomByName(string _name)
    {
        roomManager.roomNameToJoin = _name;
        roomManagerGameobject.SetActive(true);
        gameObject.SetActive(false);
    }   
}