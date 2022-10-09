using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListening : MonoBehaviourPunCallbacks
{
    
    [SerializeField] Transform _content; // 게임방프리팹의 부모역할
    [SerializeField] RoomSlot _gameRoomPrefab; // 게임방 역할의 프리팹

    private List<RoomSlot> _roomLists = new List<RoomSlot>();
    private RoomsCanvas _roomCanvas;

    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }

    // 타유저가 룸슬롯, 어느방에 입장시 자동호출
    public override void OnJoinedRoom()
    {
        // RoomSlot.cs의  OnClickedJoinButton()함수 실행시
        // 참여는 하지만, UI상에서 CurrRoomCanvas를 켜준느 작업이
        // 참조문제로 여기서 진행, 불필요한 일회성 참조가 많아질것같으므로
        _roomCanvas.CurrentRoomCanvas.Show();
        // Host클라유저의 경우
        // 방을 만든 입장이기에, CreatePanel.cs의 OnCreatedRoom함수내부에서 실행

        // 게임룸에 입장하기에,
        // 하이어아키창 룸슬롯(자식으로 자리잡은)객체들 모두 삭제
        // 룸슬롯을 모아둔 리스트도 비우기
        _content.DestroyChildren();
        _roomLists.Clear();
    }

    // 참고
    // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html#a0a9ff2be14ffd6aebe603a83a94673cc
    // 마스터서버에 등록된 대기방들 정보 가져오기 (옵션에 따라 분별할수도있는것 주의)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {_roomLists.Clear();
        foreach (RoomInfo info in roomList)
        {
            // 방정보들을 업데이트할떄, 아직 존재하는 방인지 확인필수
            // Realtime.RoomInfo.RemovedFromList
            // 방정보리스트에서 삭제된 방인지 확인

            // 존재하지않는 방이 리스트에 있다면
            if (info.RemovedFromList)
            {
                // 존재하지않느 방의 이름 확인하여 인덱스 찾기
                int index = _roomLists.FindIndex( x=> x.CurrRoom.Name == info.Name);
                if (index != -1)
                {
                    // 해당 오브젝트 삭제 및
                    Destroy(_roomLists[index].gameObject);
                    // 업데이트목록에서도 제거
                    _roomLists.RemoveAt(index);
                }
            }
            // 실제 존재하는 방이라면
            else
            {
                // 새로 추가된방인지 확인 (_roomLists는 기존 방정보 리스트)
                // roomList는 포톤서버로 부터 긁어온 방 정보들
                // 둘의 인덱스별 이름일이 일치하지않는다면 추가해야할 새로운방
                // 반대로, 둘의 이름이 같다면 기존방이 그대로 복사되어 나올수있어 넘어가기
                int index = _roomLists.FindIndex(x=>x.CurrRoom.Name == info.Name);
                if (index == -1)
                {
                    // 프리팹생성하여 콘텐츠오브젝트 자식으로 넣어서 보여주기
                    RoomSlot room = Instantiate(_gameRoomPrefab, _content);
                    if (room != null)
                    {
                        room.SetRoomInfo(info);
                        // 업데이트 방목록 리스트에 추가
                        _roomLists.Add(room);
                    }
                }

                else
                { 
                    
                }
                
            }
            
        }
    }
   
}
