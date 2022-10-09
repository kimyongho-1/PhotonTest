using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListening : MonoBehaviourPunCallbacks
{

    [SerializeField] Transform _content; // ���ӹ��������� �θ���
    [SerializeField] PlayerSlot _playerPrefab; // ���ӹ� ������ ������

    private RoomsCanvas _roomCanvas;

    // ���� ����ų�, ���� ���� ��������Ʈ
    private List<PlayerSlot> _playerLists = new List<PlayerSlot>();

    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }
    private void Awake()
    {
        // ���� ����, �Ǵ� �����
        // CurrRoomCanvas�� ActiveOn�� �Ǹ�
        // �ش� ���� ���������� �ܾ����
        GetCurrPlayerInRoom();
    }

    // ���ӹ� ������ ȣ���Լ�
    public override void OnLeftRoom()
    {
        _content.DestroyChildren();
    }

    // ������� �������� �ܾ����
    void GetCurrPlayerInRoom()
    {
        // �����Ʈ��ũ���� �����ϴ� Players ��ųʸ� ���
        // ���� ����� �������� �����Լ�
        // ���� ���� ���� ȣ��ƮŬ�󿴴ٸ�, ���� ������ ã�� �Է�
        foreach (KeyValuePair<int, Player> playerInfo
            in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayer(playerInfo.Value);
        }
    }

    // �ش�濡 ���� �߰�
    void AddPlayer(Player newPlayer)
    {  
        // ���� newPlayer�� ���� ���ӵ� ��������
        // �����ջ����Ͽ� ������������Ʈ �ڽ����� �־ �����ֱ�
        PlayerSlot player = Instantiate(_playerPrefab, _content);
        if (player != null)
        {
            player.SetPlayerInfo(newPlayer);
            // �ش�濡 ���� ������ ����Ʈ�� �߰�
            _playerLists.Add(player);
        }
    }


    // �濡 ���� ���� ����
    //���� https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html#add354fba0aebd1c970849bccfd708ff2

    // �濡 ���������, �����ҋ����� �濡 ��������Ʈ�� �߰����ֱ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayer(newPlayer);
    }
    // �濡 ���������
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // �ش�濡 �������� �ʴ� �÷��̾� ã��
        // ���� �濡 ��ϵ� �������� _playerLists���� Ž���Ͽ�
        // otherPlayer �ٸ� ����������� ��Ī�Ͽ� ã�´�
        // ���� otherPlayer�� �ٸ��ٸ� false�̱⿡ �ε����� ã�� �������ֱ�� ����
        int index = _playerLists.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            // �ش� ������Ʈ ���� ��
            Destroy(_playerLists[index].gameObject);
            // ������Ʈ��Ͽ����� ����
            _playerLists.RemoveAt(index);
        }
    }

}
