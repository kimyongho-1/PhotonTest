using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;

public class PlayerSlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nickNameText;

    // �������Կ� ����� ��������
    Photon.Realtime.Player _player;
    public Player Player { get { return _player; }set { _player = value; } }

    public void SetPlayerInfo(Photon.Realtime.Player player)
    {
        Player = player;
        _nickNameText.text = player.NickName;
        
    }
}
