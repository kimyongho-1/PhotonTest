using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSetting : ScriptableObject
{
    [SerializeField] string _gameVersion = "0.0.0";
    public string GameVersion { get { return _gameVersion; } set { _gameVersion = value; } }
    [SerializeField] string _nickName = "";
    public string NickName 
    {
        get
        { return this._nickName + Random.Range(0,111).ToString(); }
        set
        { _nickName = value; }
    }
}
