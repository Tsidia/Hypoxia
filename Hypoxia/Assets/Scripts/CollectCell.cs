using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCell : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            GameManager.Instance.OnItemCollected();

            gameObject.SetActive(false);
        }
    }
}
