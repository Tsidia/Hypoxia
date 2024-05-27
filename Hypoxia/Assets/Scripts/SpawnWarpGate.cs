using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWarpGate : MonoBehaviour
{
    public GameObject warpGatePrefab; //co to warp gate
    public Transform blackHole; //co to czarna dziura
    public float safeDistanceFromBlackHole = 100f; //Minimalny dystans od czarnej dziury
    public float maxSpawnDistance = 100f; //Maksymalny dystans od gracza

    void Start()
    {
        Vector3 spawnPosition; //gdzie postawiæ bramê

        do //Jak while ale zrób przyjmniej raz zanim sprawdzisz warunek
        {
            spawnPosition = Random.insideUnitSphere * maxSpawnDistance; //Wybierz randomowy punkt blisko gracza
        }
        while (Vector3.Distance(spawnPosition, blackHole.position) < safeDistanceFromBlackHole); //Rób to dopóki nie znajdziesz takiego co jest daleko od czarnej dziury

        Instantiate(warpGatePrefab, spawnPosition, Quaternion.identity); //postaw tam bramê 
    }
}
