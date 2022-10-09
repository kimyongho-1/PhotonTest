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

    // 플레이어가 방을 떠날떄마다 호출
    public void OnClickedLeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        // 플레이어가 방을 떠나면, 다시 대기방상태로 복귀
        _roomCanvas.CurrentRoomCanvas.Hide();
    }

}
