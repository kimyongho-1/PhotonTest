using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvas : MonoBehaviour
{
    [SerializeField] CreateJoinRoom _createjoinRoom;
   // [SerializeField] JoinRoom _joinRoom;
    [SerializeField] CurrentRoom _currRoom;
    public CreateJoinRoom CreateJoinRoomCanvas { get { return _createjoinRoom; } }
    //public JoinRoom JoinRoomCanvas { get { return _joinRoom; } }
    public CurrentRoom CurrentRoomCanvas { get { return _currRoom; } }

    private void Awake()
    {
        _createjoinRoom.Initialize(this);
        _currRoom.Initialize(this);

    }
}
