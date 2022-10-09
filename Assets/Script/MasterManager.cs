using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField] GameSetting _gameSetting;
    public static GameSetting GameSettings 
    { get { return Instance._gameSetting; } }
    
}
