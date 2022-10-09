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
    
    // 해당 게임방
    public RoomInfo CurrRoom { get; set; }

    //참고 , Pun이 아닌 RealTime사용
    // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_realtime_1_1_room_info.html
    // 게임방이 생성될때마다 해당방의 정보 세팅
    public void SetRoomInfo(Photon.Realtime.RoomInfo roomInfo)
    {
        CurrRoom = roomInfo;
        _nameText.text = roomInfo.Name;
        _playersText.text = roomInfo.PlayerCount.ToString()
            + " / "+ roomInfo.MaxPlayers.ToString();
    }

    // 룸슬롯을 누를시, 참여로 시작
    public void OnClickedJoinButton()
    {
        // 타유저가 방을 생성시
        // CreatePanel.cs 의 OnClickedCreateRoom함수 실행
        // 방을 생성시 InputField의 text내용을 게임룸 제목으로 지정
        // 그후 다른 유저들의 대기목록에서는
        // RoomListening.cs의 업데이트룸 함수로
        // 현재 RoomSlot.cs객체가 생성이되며,
        // 생성함수로, 현재 변수 CurrRoom에 내용 할당완료
        // 이 오브젝트, RoomSlot의 버튼을 클릭시 현재 함수 실행
        // 현재 스크립트의 CurrRoom에는 방의 제목이 변수로 존재
        PhotonNetwork.JoinRoom(CurrRoom.Name);
        // 호스트클라의 경우 괜찮지만
        // 참여하는 클라입장에서는,
        // CurrRoomCanvas를 활성화 해주어야합니다
        // 그것을 RoomListening.cs의 오버라이드 JoinRoom함수에서 구현
    }
}
