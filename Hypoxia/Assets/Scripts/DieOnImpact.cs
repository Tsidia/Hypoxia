using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnImpact : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) //Jak dotkniesz czego�
    {   
        if (collision.gameObject.tag == "Asteroid") //i to co� ma tag Asteroida
        {
            GameManager.Instance.OnPlayerDeath(); //to przegra�e�
        }
    }
}
