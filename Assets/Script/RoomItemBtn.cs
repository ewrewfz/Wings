using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemBtn : MonoBehaviour
{
    public string RoomName;

    public void OnBtnPressed()
    {
        RoomList.instance.JoinRoomByName(RoomName);
    }
}
