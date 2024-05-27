using UnityEngine;

public class WarpGate : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject fluxGameObject;
    public float proximityDistance = 200f;
    public float timeToRepair = 10f;
    private float repairProgress = 0f;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= proximityDistance && GameManager.Instance.isItemCollected)
        {
            repairProgress += Time.deltaTime;
            UIManager.Instance.AppendText("Warp Gate repair progress: " + (repairProgress / timeToRepair));

            if (repairProgress >= timeToRepair)
            {
                CompleteRepair();
            }
        }
        else
        {
            repairProgress = 0f;
        }
    }

    private void CompleteRepair()
    {
        // Handle repair completion (e.g., update game state, trigger animations, etc.)
        UIManager.Instance.AppendText("Warp Gate on standby");
        fluxGameObject.SetActive(true);
        GameManager.Instance.isGateRepaired = true;
        this.enabled = false;
    }
}
