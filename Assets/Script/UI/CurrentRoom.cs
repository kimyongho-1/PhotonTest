using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �������� ����, �ش� �濡 ���õ� script
public class CurrentRoom : MonoBehaviour
{
    private RoomsCanvas _roomCanvas;

    [SerializeField] PlayerListening _playerListening;
    [SerializeField] LeaveRoom _leaveRoom;
    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
        _playerListening.Initialize(roomCanvas);
        _leaveRoom.Initialize(roomCanvas);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _roomCanvas.CreateJoinRoomCanvas.gameObject.SetActive(false);
       
    }
    public void Hide()
    {
        _roomCanvas.CreateJoinRoomCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
