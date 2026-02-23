using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private float moveSpeed = 5f;
    public override void EnterState(PlayerStateManager player)
    {

        player.Animator.SetBool("IsMoving", true);

    }

    public override void ExitState(PlayerStateManager player)
    {
        player.Animator.SetBool("IsMoving", false);
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.Animator.SetFloat("XInput", player.moveInput.x);
        player.Animator.SetFloat("YInput", player.moveInput.y);
        player.transform.parent.Translate(player.moveInput * moveSpeed * Time.deltaTime);
        if (player.isAttacking)
        {
            player.SwitchState(player.PlayerAttackState);
        }
        else if (player.moveInput == Vector2.zero)
        {
            player.SwitchState(player.PlayerIdleState);
        }
    }
}
