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
 //   [Space]
 ////   public GameObject roomCam;
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

        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin,null,null);
        Debug.Log("Connecting....");

        //OnJoinedRoom();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We're Connected and in a room now");

        // roomCam.SetActive(false);
        //PhotonNetwork.LoadLevel("Lobby");
        player.transform.position = spawnPos.position;
        
    }

    public void SpawnPlayer()
    { 
        GameObject _player = PhotonNetwork.Instantiate(player.name , spawnPos.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().isLocalPlayer();

        _player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.AllBuffered, nickName);
    }

    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomOrCreateRoom(null,0,Photon.Realtime.MatchmakingMode.FillRoom,null,null,$"Quick{Random.Range(0,1000)}",null,null);
    }
}
