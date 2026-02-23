using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    [Header("Component")]
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;
    public PlayerInputActions PlayerInputActions;

    [Header("Input")]
    public Vector2 moveInput;
    public bool isAttacking;

    // States
    public PlayerBaseState currentState;
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }
    public PlayerAttackState PlayerAttackState { get; private set; }

    private void Awake()
    {
        LoadComponent();
        
        PlayerInputActions.Player.Move.performed += OnMovePerformed;
        PlayerInputActions.Player.Move.canceled += OnMoveCanceled;
        PlayerInputActions.Player.Attack.performed += OnAttack;
        
    }

    private void OnEnable()
    {
        PlayerInputActions.Enable();
    }

    private void OnDisable()
    {
        PlayerInputActions.Disable();
    }

    private void LoadComponent()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerIdleState = new PlayerIdleState();
        PlayerMoveState = new PlayerMoveState();
        PlayerAttackState = new PlayerAttackState();
    }

    void Start()
    {
        currentState = PlayerIdleState;
        currentState.EnterState(this);
    }

    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        isAttacking = true;
    }
}
