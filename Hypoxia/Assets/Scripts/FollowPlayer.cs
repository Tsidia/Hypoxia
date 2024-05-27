//TEN SKRYPT JEST NA KAMERZE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //Gracz
    public Vector3 offset; //Jak daleko kamera ma byæ od gracza

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void LateUpdate() //Po tym jak ju¿ wszystko inne obliczysz
    {
        Vector3 transformedOffset = player.rotation * offset; //WeŸ pod uwagê rotacje przy liczeniu oddalenia
        transform.position = player.position + transformedOffset; //IdŸ tam gdzie jest gracz i oddal siê o offset
        transform.LookAt(player); //Patrz na gracza

    }
}
