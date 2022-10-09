using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class CreatePanel : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI _roomName;

    private RoomsCanvas _roomCanvas;
    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }

    //  방생성 옵션함수
    public RoomOptions MakeOption()
    {
        Photon.Realtime.RoomOptions option = new RoomOptions();
        
        option.MaxPlayers = 2;
        return option;
    }

    // 게임방 생성버튼 누를시
    public void OnClickedCreateRoom()
    {
        // api 참고
        // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_photon_network.html
        // 방만들기 직전, 커넥팅 체크
        // 포톤 연결까지 False지만, Connect후로는 True
        // 현재 Connect.cs에서 커네틱실행, 연결확인을 하려면 언제나 해당 오브젝트 존재여부 확인
        if (!PhotonNetwork.IsConnected) { Debug.Log("Current Connecting is Lose");  return; }

        // 방만들기
        PhotonNetwork.JoinOrCreateRoom
            (_roomName.text, 
            MakeOption(),
            TypedLobby.Default
            );
    }

    //참고
    // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html#a50318462f4512ceacacfe57c3af3f50c
    // 방생성 성공시
    public override void OnCreatedRoom()
    {
        Debug.Log("CreateRoom Success!");
        _roomCanvas.CurrentRoomCanvas.Show();
    }

    // 방생성 실패시
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"CreateRoom Failed : "  + message + $", From {this.name}");
    }
}
