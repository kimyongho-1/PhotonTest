using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListening : MonoBehaviourPunCallbacks
{

    [SerializeField] Transform _content; // 게임방프리팹의 부모역할
    [SerializeField] PlayerSlot _playerPrefab; // 게임방 역할의 프리팹

    private RoomsCanvas _roomCanvas;

    // 내가 만들거나, 속한 방의 유저리스트
    private List<PlayerSlot> _playerLists = new List<PlayerSlot>();

    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }
    private void Awake()
    {
        // 방을 생성, 또는 입장시
        // CurrRoomCanvas가 ActiveOn이 되며
        // 해당 방의 유저정보를 긁어오기
        GetCurrPlayerInRoom();
    }

    // 게임방 떠날떄 호출함수
    public override void OnLeftRoom()
    {
        _content.DestroyChildren();
    }

    // 현재방의 유저정보 긁어오기
    void GetCurrPlayerInRoom()
    {
        // 포톤네트워크에서 지원하는 Players 딕셔너리 사용
        // 현재 방속의 유저정보 갱신함수
        // 내가 방을 만든 호스트클라였다면, 나의 정보를 찾아 입력
        foreach (KeyValuePair<int, Player> playerInfo
            in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayer(playerInfo.Value);
        }
    }

    // 해당방에 유저 추가
    void AddPlayer(Player newPlayer)
    {  
        // 인자 newPlayer는 현재 접속된 유저정보
        // 프리팹생성하여 콘텐츠오브젝트 자식으로 넣어서 보여주기
        PlayerSlot player = Instantiate(_playerPrefab, _content);
        if (player != null)
        {
            player.SetPlayerInfo(newPlayer);
            // 해당방에 들어온 유저들 리스트에 추가
            _playerLists.Add(player);
        }
    }


    // 방에 유저 입장 퇴장
    //참고 https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html#add354fba0aebd1c970849bccfd708ff2

    // 방에 유저입장시, 입장할떄마다 방에 유저리스트에 추가해주기
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayer(newPlayer);
    }
    // 방에 유저퇴장시
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // 해당방에 존재하지 않는 플레이어 찾기
        // 당장 방에 등록된 유저정보 _playerLists에서 탐색하여
        // otherPlayer 다른 유저정보들과 매칭하여 찾는다
        // 만약 otherPlayer와 다른다면 false이기에 인덱스를 찾아 제거해주기로 결정
        int index = _playerLists.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            // 해당 오브젝트 삭제 및
            Destroy(_playerLists[index].gameObject);
            // 업데이트목록에서도 제거
            _playerLists.RemoveAt(index);
        }
    }

}
