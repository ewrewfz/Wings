using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTest : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform[] spawnPos;
    private void Start()
    {
        PhotonNetwork.Instantiate(Player.name, spawnPos[Random.Range(0,spawnPos.Length)].position, Quaternion.identity);
    }
}
