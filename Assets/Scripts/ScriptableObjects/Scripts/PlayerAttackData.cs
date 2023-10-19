using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class AttackInfoData
{
    [field: SerializeField] public string AttackName { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
}


[Serializable]
public class PlayerAttackData
{
    [field: SerializeField] public AttackInfoData AttackInfoData { get; private set; }

}