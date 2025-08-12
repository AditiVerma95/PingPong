// PaddleInput.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputManager : MonoBehaviour
{
    public float verticalInput { get; private set; }
    public NewInputSystem inputSystem;
    public static UserInputManager Instance;

    void Awake()
    {
        inputSystem = new NewInputSystem();
        Instance = this;
    }

    void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Game.pointerPosition.performed += ctx => verticalInput = ctx.ReadValue<Vector2>().y;
        inputSystem.Game.pointerPosition.canceled += ctx => verticalInput = 0f;
    }

    void OnDisable()
    {
        inputSystem.Disable();
    }
}