using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [Header("Asteriod Prefab")]
    [SerializeField] private Asteriod asteriodprefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnDistance = -15f;
    [SerializeField] private int spawnAmount = 2;
    [SerializeField] private float trajectoryVariance = 2;



    void Start()
    {
        //repeating spawn, parameters are (function, the time or the delay, do it everytime passes)
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            //random
            //direction of spawner, normalized = 1
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;   
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            //random rotation
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteriod asteroid = Instantiate(asteriodprefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize); // random size
            asteroid.setTrajectory(rotation * -spawnDirection);
        }
    }
}
