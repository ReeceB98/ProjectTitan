using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    private InputSystem inputSystem;

    [SerializeField] private LayerMask pickupMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform pickupTarget;
    [Space]
    private Rigidbody currentObject;

    private void Awake()
    {
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

    // Update is called once per frame
    private void Update()
    {
        
    }
}
