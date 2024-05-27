using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab; //Asteroidy czym s¹
    public int asteroidCount; //Ile ich ma byæ
    public float spawnRadius; //Na jak du¿ym obszarze je spawnowaæ
    void Start()
    {
        for (int i = 0; i < asteroidCount; i++) //Tyle razy ile jest asteroid
        {
            Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + transform.position; //Wybierz randomowy punkt w obszarze ograniczonym przez spawnposition
            Instantiate(asteroidPrefab, spawnPosition, Random.rotation); //I spawnij tam asteroidê
        }
    }

}
