using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerformJump : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.OnPlayerEscaped();
        }
    }
}
