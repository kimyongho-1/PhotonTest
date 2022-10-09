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
        // ���� ������ �г��ӵ��
        print(PhotonNetwork.LocalPlayer.NickName);

        // ������ ���ӷ��� ������, Ŀ��Ƽ���������͸� ��ĥ�ٵ�, �׋����� Ȯ��
        // Leave�Ŀ�, �κ� �ӹ������� �ʴٸ� �κ�� �����Ű��
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
