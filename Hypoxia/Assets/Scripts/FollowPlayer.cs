//TEN SKRYPT JEST NA KAMERZE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; //Gracz
    public Vector3 offset; //Jak daleko kamera ma by� od gracza

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void LateUpdate() //Po tym jak ju� wszystko inne obliczysz
    {
        Vector3 transformedOffset = player.rotation * offset; //We� pod uwag� rotacje przy liczeniu oddalenia
        transform.position = player.position + transformedOffset; //Id� tam gdzie jest gracz i oddal si� o offset
        transform.LookAt(player); //Patrz na gracza

    }
}
