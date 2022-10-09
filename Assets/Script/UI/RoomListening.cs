using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListening : MonoBehaviourPunCallbacks
{
    
    [SerializeField] Transform _content; // ���ӹ��������� �θ���
    [SerializeField] RoomSlot _gameRoomPrefab; // ���ӹ� ������ ������

    private List<RoomSlot> _roomLists = new List<RoomSlot>();
    private RoomsCanvas _roomCanvas;

    public void Initialize(RoomsCanvas roomCanvas)
    {
        _roomCanvas = roomCanvas;
    }

    // Ÿ������ �뽽��, ����濡 ����� �ڵ�ȣ��
    public override void OnJoinedRoom()
    {
        // RoomSlot.cs��  OnClickedJoinButton()�Լ� �����
        // ������ ������, UI�󿡼� CurrRoomCanvas�� ���ش� �۾���
        // ���������� ���⼭ ����, ���ʿ��� ��ȸ�� ������ �������Ͱ����Ƿ�
        _roomCanvas.CurrentRoomCanvas.Show();
        // HostŬ�������� ���
        // ���� ���� �����̱⿡, CreatePanel.cs�� OnCreatedRoom�Լ����ο��� ����

        // ���ӷ뿡 �����ϱ⿡,
        // ���̾��Űâ �뽽��(�ڽ����� �ڸ�����)��ü�� ��� ����
        // �뽽���� ��Ƶ� ����Ʈ�� ����
        _content.DestroyChildren();
        _roomLists.Clear();
    }

    // ����
    // https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html#a0a9ff2be14ffd6aebe603a83a94673cc
    // �����ͼ����� ��ϵ� ����� ���� �������� (�ɼǿ� ���� �к��Ҽ����ִ°� ����)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {_roomLists.Clear();
        foreach (RoomInfo info in roomList)
        {
            // ���������� ������Ʈ�ҋ�, ���� �����ϴ� ������ Ȯ���ʼ�
            // Realtime.RoomInfo.RemovedFromList
            // ����������Ʈ���� ������ ������ Ȯ��

            // ���������ʴ� ���� ����Ʈ�� �ִٸ�
            if (info.RemovedFromList)
            {
                // ���������ʴ� ���� �̸� Ȯ���Ͽ� �ε��� ã��
                int index = _roomLists.FindIndex( x=> x.CurrRoom.Name == info.Name);
                if (index != -1)
                {
                    // �ش� ������Ʈ ���� ��
                    Destroy(_roomLists[index].gameObject);
                    // ������Ʈ��Ͽ����� ����
                    _roomLists.RemoveAt(index);
                }
            }
            // ���� �����ϴ� ���̶��
            else
            {
                // ���� �߰��ȹ����� Ȯ�� (_roomLists�� ���� ������ ����Ʈ)
                // roomList�� ���漭���� ���� �ܾ�� �� ������
                // ���� �ε����� �̸����� ��ġ�����ʴ´ٸ� �߰��ؾ��� ���ο��
                // �ݴ��, ���� �̸��� ���ٸ� �������� �״�� ����Ǿ� ���ü��־� �Ѿ��
                int index = _roomLists.FindIndex(x=>x.CurrRoom.Name == info.Name);
                if (index == -1)
                {
                    // �����ջ����Ͽ� ������������Ʈ �ڽ����� �־ �����ֱ�
                    RoomSlot room = Instantiate(_gameRoomPrefab, _content);
                    if (room != null)
                    {
                        room.SetRoomInfo(info);
                        // ������Ʈ ���� ����Ʈ�� �߰�
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
