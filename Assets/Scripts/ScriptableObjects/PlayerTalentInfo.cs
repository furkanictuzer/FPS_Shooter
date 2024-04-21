using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info/PlayerLevelInfo/SpeedTalent", fileName = "NewSpeedTalent")]
public class SpeedTalentInfo : ScriptableObject
{
    public float walkSpeed = 8, sprintSpeed = 12;
}

[CreateAssetMenu(menuName = "Info/PlayerLevelInfo/MaxJumpTalent", fileName = "NewMaxJumpTalent")]
public class MaxJumpTalentInfo : ScriptableObject
{
    public float maxJumpHeight = 3;
}

[CreateAssetMenu(menuName = "Info/PlayerLevelInfo/MaxHealthTalent", fileName = "NewMaxHealthTalent")]
public class MaxHealthTalentInfo : ScriptableObject
{
    public int maxHealth = 100;
}

//Gun talents

[CreateAssetMenu(menuName = "Info/PlayerLevelInfo/DamageAmountTalent", fileName = "NewDamageAmountTalent")]
public class DamageAmountTalentInfo : ScriptableObject
{
    public int damageAmount = 10;
}

[CreateAssetMenu(menuName = "Info/PlayerLevelInfo/AmmoCapacityTalent", fileName = "NewAmmoCapacityTalent")]
public class AmmoCapacityTalentInfo : ScriptableObject
{
    public int ammoCapacity = 10;
}

[CreateAssetMenu(menuName = "Info/PlayerLevelInfo/PierceShotTalent", fileName = "NewPierceShotTalent")]
public class PierceShotTalentInfo : ScriptableObject
{
    public int pierceShot = 1;
}