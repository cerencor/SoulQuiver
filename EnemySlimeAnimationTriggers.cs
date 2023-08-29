using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeAnimationTriggers : MonoBehaviour
{   
    private EnemySlime enemy => GetComponentInParent<EnemySlime>();
    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
}
