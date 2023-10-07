using UnityEngine;

public class RocketReplenish : MonoBehaviour
{
    private Oxygen oxygen;
    private AudioSource airRelease;

    // Start is called before the first frame update
    private void Awake()
    {
        oxygen = FindAnyObjectByType<Oxygen>();
        airRelease = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        
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
            //airRelease.Play();
        }
    }
}
