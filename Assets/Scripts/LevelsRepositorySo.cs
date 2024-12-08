using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsRepository", menuName = "ScriptableObjects/LevelsRepository")]
public class LevelsRepositorySo : ScriptableObject
{
    [SerializeField] private List<LevelSo> levelsStats;

    public List<LevelSo> LevelsStats => levelsStats;
}
