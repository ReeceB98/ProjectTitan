using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private GameObject heldObject;
    [SerializeField] private Rigidbody heldObjectRigidbody;
    [SerializeField] private LayerMask pickupMask;

    private InputSystem inputSystem;

    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Player.Interact.performed += GetInteraction;
        inputSystem.Player.Interact.canceled += GetInteraction;
    }

    private void OnDisable()
    {
        inputSystem.Disable();
        inputSystem.Player.Interact.performed -= GetInteraction;
        inputSystem.Player.Interact.canceled -= GetInteraction;
    }

    private void Update()
    {
        /*if (inputSystem.Player.Interact.triggered)
        {
            //Debug.Log("Input is pressed!");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
                Debug.Log("Object hit: " + hit.transform.name);
                heldObjectRigidbody = heldObject.GetComponent<Rigidbody>();
                heldObjectRigidbody.useGravity = false;
                heldObject.GetComponent<BoxCollider>().isTrigger = true;
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = holdPosition;
            }

            Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.green, 5.0f);
        }
        else if (inputSystem.Player.Interact.)
        {
            heldObjectRigidbody.useGravity = true;
            heldObject.transform.parent = null;
            heldObject = null;
        }*/
    }

    private void GetInteraction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("Input is pressed!");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10.0f, pickupMask))
            {
                Debug.Log("Object hit: " + hit.transform.name);
                heldObjectRigidbody = heldObject.GetComponent<Rigidbody>();
                heldObjectRigidbody.useGravity = false;
                heldObject.GetComponent<BoxCollider>().isTrigger = true;
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.parent = holdPosition;
            }

            Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.green, 5.0f);
        }
        else if (context.canceled)
        {
            heldObjectRigidbody.useGravity = true;
            heldObject.transform.parent = null;
            //heldObject = null;
            heldObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
