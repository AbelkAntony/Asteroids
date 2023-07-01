using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpwaner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public ParticleSystem explosion;
    public float spwanRate = 2f;
    public int spwanAmount = 1;
    public float spwanDistance = 15f;
    public float trajectoryVariance = 15f;
    private void Start()
    {
        InvokeRepeating(nameof(Spwan),this.spwanRate, this.spwanRate);
    }

    private void Spwan()
    {
        for(int i=0; i<spwanAmount; i++)
        {
            Vector3 spwanDirection = Random.insideUnitCircle.normalized * spwanDistance;
            Vector3 spwanPoint = this.transform.position + spwanDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(asteroidPrefab, spwanPoint, rotation);
            asteroid.size = Random.Range(asteroid.GetMinSize(), asteroid.GetMaxSize());
            asteroid.SetTrajectory(rotation * -spwanDirection);
        }
    }
}
