using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using UnityEditor.Rendering;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    public GameObject player;
    [Space]
    public Transform spawnPos;
    [Space]
    public GameObject roomCam;
    [Space]
    public GameObject nameUI;
    public GameObject connectingUI;

    private string nickName = "unnamed";


    public string roomNameToJoin = "test";

    private void Awake()
    {
        instance = this;
    }

    public void ChangeNickName(string _name)
    {
        nickName = _name;
    }
    public void JoinRoomBtnPressed()
    {
        Debug.Log("Connecting....");

        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin,null,null);

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We're Connected and in a room now");

        roomCam.SetActive(false);

        SpawnPlayer();
    }

    public void SpawnPlayer()
    { 
        GameObject _player = PhotonNetwork.Instantiate(player.name , spawnPos.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().isLocalPlayer();

        _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.AllBuffered, nickName);
    }
}
