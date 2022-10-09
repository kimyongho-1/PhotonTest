using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class CreatePanel : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI _roomName;

    private RoomsCanvas _roomCanvas;
    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }

    //  ����� �ɼ��Լ�
    public RoomOptions MakeOption()
    {
        Photon.Realtime.RoomOptions option = new RoomOptions();
        
        option.MaxPlayers = 2;
        return option;
    }

    // ���ӹ� ������ư ������
    public void OnClickedCreateRoom()
    {
        // api ����
        // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_photon_network.html
        // �游��� ����, Ŀ���� üũ
        // ���� ������� False����, Connect�ķδ� True
        // ���� Connect.cs���� Ŀ��ƽ����, ����Ȯ���� �Ϸ��� ������ �ش� ������Ʈ ���翩�� Ȯ��
        if (!PhotonNetwork.IsConnected) { Debug.Log("Current Connecting is Lose");  return; }

        // �游���
        PhotonNetwork.JoinOrCreateRoom
            (_roomName.text, 
            MakeOption(),
            TypedLobby.Default
            );
    }

    //����
    // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html#a50318462f4512ceacacfe57c3af3f50c
    // ����� ������
    public override void OnCreatedRoom()
    {
        Debug.Log("CreateRoom Success!");
        _roomCanvas.CurrentRoomCanvas.Show();
    }

    // ����� ���н�
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"CreateRoom Failed : "  + message + $", From {this.name}");
    }
}
