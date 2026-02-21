using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    [SerializeField] private float moveSpeed = 5f;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void Update()
    {
        transform.parent.Translate(moveInput * moveSpeed * Time.deltaTime);
        Debug.Log($"Move Input: {moveInput}");

    }
}
