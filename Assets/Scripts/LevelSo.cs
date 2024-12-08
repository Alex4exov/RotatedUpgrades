using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level")]
public class LevelSo : ScriptableObject
{
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    [SerializeField] private int damage;
    [SerializeField] private int upgradeCost;

    public int Strength => strength;
    public int Agility => agility;
    public int Damage => damage;
    public int UpgradeCost => upgradeCost;
}
