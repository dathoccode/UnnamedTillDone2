using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.Animator.SetTrigger("AttackTrigger");
        player.SwitchState(player.PlayerIdleState);
    }

    public override void ExitState(PlayerStateManager player)
    {
        ResetAttackFlag(player);
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    private void ResetAttackFlag(PlayerStateManager player)
    {
        player.isAttacking = false;
    }
}
