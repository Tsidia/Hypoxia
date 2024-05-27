using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHolePhysics : MonoBehaviour
{
    public float pullForce; 
    public float pullIncreaseRate; 

    void FixedUpdate()
    {
        pullForce += pullIncreaseRate * Time.fixedDeltaTime; 

        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>(); 
        foreach (Rigidbody rb in allRigidbodies) 
        {
            Vector3 direction = (transform.position - rb.transform.position).normalized; 
            rb.AddForce(direction * pullForce); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.CompareTag("Player"))  
            {
                GameManager.Instance.OnPlayerDeath(); 
            }

            Destroy(other.gameObject); 
        }
    }
}
