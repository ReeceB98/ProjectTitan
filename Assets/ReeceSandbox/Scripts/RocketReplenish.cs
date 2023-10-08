using UnityEngine;

public class RocketReplenish : MonoBehaviour
{
    private Oxygen oxygen;              // Oxygen class
    private AudioSource airRelease;     // Air release SFX

    // Start is called before the first frame update
    private void Awake()
    {
        oxygen = FindAnyObjectByType<Oxygen>();     // Get Oxygen script
        airRelease = GetComponent<AudioSource>();   // Get audio source
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            airRelease.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oxygen.ReplenishOxygen(100);
        }
    }
}
