using System.Collections;
using UnityEngine;

public class AudioGuidanceSystem : MonoBehaviour
{
    public Transform objective;
    public Transform gate;
    public Transform player;
    public AudioSource guidanceAudioSource;
    public float maxInterval; // Maximum time between sounds
    public float minInterval; // Minimum time between sounds
    public float maxDistance; // Distance at which maxInterval is used

    private float nextPlayTime = 0f;
    private bool isGuidanceEnabled = true;

    void Start()
    {
        StartCoroutine(FindAndAssignObjective());
        StartCoroutine(FindAndAssignGate());
    }

    IEnumerator FindAndAssignObjective()
    {
        Transform foundObjective = null;

        // Wait until the objective is spawned and found
        while (foundObjective == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Objective");
            if (obj != null)
                foundObjective = obj.transform;

            yield return null; // Wait for the next frame
        }

        objective = foundObjective;
    }

    IEnumerator FindAndAssignGate()
    {
        Transform foundObjective = null;

        // Wait until the objective is spawned and found
        while (foundObjective == null)
        {
            GameObject obj = GameObject.Find("WarpGate(Clone)");
            if (obj != null)
                foundObjective = obj.transform;

            yield return null; // Wait for the next frame
        }

        gate = foundObjective;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGuidanceEnabled = !isGuidanceEnabled;
        }

        if (isGuidanceEnabled && Time.time >= nextPlayTime)
        {
            float distance = Vector3.Distance(player.position, objective.position);
            if (GameManager.Instance.isItemCollected)
                distance = Vector3.Distance(player.position, gate.position);
            Debug.Log("Distance between player and objective: " + distance);
            float interval = Mathf.Lerp(minInterval, maxInterval, distance / maxDistance) * 2;
            Debug.Log("Time until next sound play: " + interval);
            nextPlayTime = Time.time + interval;

            guidanceAudioSource.Play();
            GameManager.Instance.UpdateDistance(distance);
        }
    }
}
