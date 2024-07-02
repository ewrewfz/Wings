using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goaway : MonoBehaviour
{
    [SerializeField]private int NotinmybackyardCnt;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("body"))
        {
            print("up");
            NotinmybackyardCnt++;
        }
        if (NotinmybackyardCnt == 2)
        {
            PhotonNetwork.LoadLevel("TestScene");
            //RoomManager.instance.SpawnPlayer();

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("body"))
        {
            print("down");
            NotinmybackyardCnt--;
        }
    }


}
