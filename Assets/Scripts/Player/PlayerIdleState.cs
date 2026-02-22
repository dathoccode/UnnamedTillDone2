using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.Animator.SetBool("IsIdle", true);
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.Animator.SetBool("IsIdle", false);
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }
}
