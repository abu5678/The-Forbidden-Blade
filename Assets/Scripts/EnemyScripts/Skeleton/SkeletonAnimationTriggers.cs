using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationTriggers : MonoBehaviour
{
    private EnemySkeleton enemy => GetComponentInParent<EnemySkeleton>();

    public void animationTrigger()
    {
        enemy.animationFinishTrigger();
    }
}
