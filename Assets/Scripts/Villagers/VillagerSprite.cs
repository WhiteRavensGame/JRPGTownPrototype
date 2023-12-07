using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Villager Sprite", menuName = "Villager/Sprite")]
public class VillagerSprite : ScriptableObject
{
    [SerializeField] private Sprite _leftIdle;
    [SerializeField] private Sprite _rightIdle;
    [SerializeField] private Sprite _leftWalk;
    [SerializeField] private Sprite _rightWalk;
}
