using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RoomSlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _playersText;
    
    // �ش� ���ӹ�
    public RoomInfo CurrRoom { get; set; }

    //���� , Pun�� �ƴ� RealTime���
    // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_realtime_1_1_room_info.html
    // ���ӹ��� �����ɶ����� �ش���� ���� ����
    public void SetRoomInfo(Photon.Realtime.RoomInfo roomInfo)
    {
        CurrRoom = roomInfo;
        _nameText.text = roomInfo.Name;
        _playersText.text = roomInfo.PlayerCount.ToString()
            + " / "+ roomInfo.MaxPlayers.ToString();
    }

    // �뽽���� ������, ������ ����
    public void OnClickedJoinButton()
    {
        // Ÿ������ ���� ������
        // CreatePanel.cs �� OnClickedCreateRoom�Լ� ����
        // ���� ������ InputField�� text������ ���ӷ� �������� ����
        // ���� �ٸ� �������� ����Ͽ�����
        // RoomListening.cs�� ������Ʈ�� �Լ���
        // ���� RoomSlot.cs��ü�� �����̵Ǹ�,
        // �����Լ���, ���� ���� CurrRoom�� ���� �Ҵ�Ϸ�
        // �� ������Ʈ, RoomSlot�� ��ư�� Ŭ���� ���� �Լ� ����
        // ���� ��ũ��Ʈ�� CurrRoom���� ���� ������ ������ ����
        PhotonNetwork.JoinRoom(CurrRoom.Name);
        // ȣ��ƮŬ���� ��� ��������
        // �����ϴ� Ŭ�����忡����,
        // CurrRoomCanvas�� Ȱ��ȭ ���־���մϴ�
        // �װ��� RoomListening.cs�� �������̵� JoinRoom�Լ����� ����
    }
}
