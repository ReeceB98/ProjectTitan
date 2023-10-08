using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Text scanText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = GameObject.Find("Oxygen UI");
        GameObject child = parent.transform.Find("ScanItemText").gameObject;
        scanText = child.GetComponentInChildren<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scanText.gameObject.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(DisableScanText());
        }
    }

    private IEnumerator DisableScanText()
    {
        yield return new WaitForSeconds(5.0f);
        scanText.gameObject.SetActive(false);
    }
}
