using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {
    public static event System.Action OnPause;
    public static event System.Action OnJump;
    public static event System.Action OnInteraction;
    public static event System.Action<bool> OnMouseClick;
    public static event System.Action<Vector2> OnMove;
    public static event System.Action<Vector2> OnStop;

    private PlayerInputSystem controls;

    private void Awake() {
        controls = new PlayerInputSystem();
    }

    private void OnEnable() {
        controls.Enable();
        controls.Player.Pause.performed += context => OnPause?.Invoke();
        controls.Player.Jump.performed += context => OnJump?.Invoke();
        controls.Player.Interaction.performed += context => OnInteraction?.Invoke();
        controls.Player.MouseClick.performed += context => OnMouseClick?.Invoke(true);
        controls.Player.MouseClick.canceled += context => OnMouseClick?.Invoke(false);
        controls.Player.Move.performed += context => OnMove?.Invoke(context.ReadValue<Vector2>());
        controls.Player.Move.canceled += context => OnStop?.Invoke(Vector2.zero);
    }

    private void OnDisable() {
        controls.Disable();
        controls.Player.Pause.performed -= context => OnPause?.Invoke();
        controls.Player.Jump.performed -= context => OnJump?.Invoke();
        controls.Player.Interaction.performed -= context => OnInteraction?.Invoke();
        controls.Player.MouseClick.performed -= context => OnMouseClick?.Invoke(true);
        controls.Player.MouseClick.canceled -= context => OnMouseClick?.Invoke(false);
        controls.Player.Move.performed -= context => OnMove?.Invoke(context.ReadValue<Vector2>());
        controls.Player.Move.canceled -= context => OnStop?.Invoke(Vector2.zero);
    }
}
