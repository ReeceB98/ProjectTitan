using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem inputSystem;

    private static InputManager instance;

    public static InputManager Instance
    {
        get 
        { 
            return instance; 
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }

    public Vector2 GetMovement()
    {
        return inputSystem.Player.Move.ReadValue<Vector2>();
    }

}
