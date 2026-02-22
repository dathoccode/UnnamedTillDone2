using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    [Header("Component")]
    public Animator Animator { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public PlayerInputActions PlayerInputActions { get; private set; }
    public Vector2 moveInput;

    // States
    public PlayerBaseState currentState;
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }

    private void Awake()
    {
        LoadComponent();
        
        PlayerInputActions.Player.Move.performed += OnMovePerformed;
        PlayerInputActions.Player.Move.canceled += OnMoveCanceled;
    }

    private void LoadComponent()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerIdleState = new PlayerIdleState();
        PlayerMoveState = new PlayerMoveState();
        Animator = GetComponentInChildren<Animator>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        currentState = PlayerIdleState;
        currentState.EnterState(this);
    }

    void Update()
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
}
