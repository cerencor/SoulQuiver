using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>(); //player is equal to component in player
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
}
