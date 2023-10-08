using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Text scanText;
    private InputSystem inputSystem;
    private InputAction interactAction;

    // Start is called before the first frame update
    private void Awake()
    {
        GameObject parent = GameObject.Find("Oxygen UI");
        GameObject child = parent.transform.Find("ScanItemText").gameObject;
        scanText = child.GetComponentInChildren<Text>();
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        interactAction = new InputAction("Interact", InputActionType.Button, "<Keyboard>/e");
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (interactAction.triggered)
            //{
                scanText.gameObject.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(DisableScanText());
            //}
        }
    }

    private IEnumerator DisableScanText()
    {
        yield return new WaitForSeconds(5.0f);
        scanText.gameObject.SetActive(false);
    }
}
