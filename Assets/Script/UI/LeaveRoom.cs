using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoom : MonoBehaviour
{
    private RoomsCanvas _roomCanvas;

    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }

    // �÷��̾ ���� ���������� ȣ��
    public void OnClickedLeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        // �÷��̾ ���� ������, �ٽ� ������·� ����
        _roomCanvas.CurrentRoomCanvas.Hide();
    }

}
