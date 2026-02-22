using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        switch (player.moveInput.x)
        {
            case > 0:
                player.SpriteRenderer.flipX = false;
                break;
            case < 0:
                player.SpriteRenderer.flipX = true;
                break;
        }

        switch (player.moveInput) 
        {
            case Vector2 v when v.magnitude > 0:
                player.Animator.SetBool("IsMoving", true);
                break;
            default:
                player.Animator.SetBool("IsMoving", false);
                break;
        }

    }

    public override void ExitState(PlayerStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
    }
}
