using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnImpact : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) //Jak dotkniesz czegoœ
    {   
        if (collision.gameObject.tag == "Asteroid") //i to coœ ma tag Asteroida
        {
            GameManager.Instance.OnPlayerDeath(); //to przegra³eœ
        }
    }
}
