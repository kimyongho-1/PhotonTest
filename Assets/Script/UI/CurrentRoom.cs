using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유저가 공개방을 들어갈시, 해당 방에 관련된 script
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
