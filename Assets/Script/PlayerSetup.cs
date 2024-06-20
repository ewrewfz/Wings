using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviour
{
    public TestMovement movement;

    public GameObject camera;

    public TextMeshPro nickNameText;

    public string nickName;

    public void isLocalPlayer()
    {
        movement.enabled = true;

        camera.SetActive(true);
    }

    [PunRPC] 
    public void SetNickname(string _name)
    {
        nickName = _name;

        nickNameText.text = nickName;
    }
}
