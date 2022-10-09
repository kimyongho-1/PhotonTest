using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class Connect : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI idText;
    void Start()
    {
        print("Connecting To Server...");

        PhotonNetwork.NickName =
            MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion =
            MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

        idText.text = "User ID : " + PhotonNetwork.LocalPlayer.NickName;
    }
    public override void OnConnectedToMaster()
    {
        print("Connecting To MasterServer");
        // 접속 유저의 닉네임디버
        print(PhotonNetwork.LocalPlayer.NickName);

        // 유저가 게임룸을 떠날때, 커넥티드투마스터를 거칠텐데, 그떄마다 확인
        // Leave후에, 로비에 머물러있지 않다면 로비로 입장시키기
        if (!PhotonNetwork.InLobby)
        { PhotonNetwork.JoinLobby(); }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected From Server Cause : " + cause.ToString()) ;   
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

}
