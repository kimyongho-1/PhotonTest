using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJoinRoom : MonoBehaviour
{
    [SerializeField] CreatePanel _createPanel;
    [SerializeField] RoomListening _roomListening;
    private RoomsCanvas _roomCanvas;
    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
        _createPanel.Initialize(roomCanvas);
        _roomListening.Initialize(roomCanvas);
    }
}
