using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Joystick joystick;


    [Header("Enemies settings")]
    [SerializeField] private float delaySpawn;
    [SerializeField] private int maxEnemies;
    private int countEnemies = 0;

    [SerializeField] private GameObject enemyPrefab;


    private List<SpawnPoint> spawnpoints;

    public static GameManager Instance;


    public Joystick GetJoystick { get { return joystick; } }

    public Transform GetCar { get; private set; }

    private void Awake()
    {
        Instance = this;

        spawnpoints = new List<SpawnPoint>();
    }

    public void StartGame(GameObject m_car)
    {
        StartCoroutine(SpawnEnemies());

        GetCar = m_car.transform;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(delaySpawn);

            if (maxEnemies > countEnemies)
            {
                //SpawnPoint m_spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
                Vector3 spawnPosition = new Vector3(Random.Range(-1, 1), 0.02f, Random.Range(-1, 1));

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                countEnemies++;
            }
        }
    }

    public void KillEnemy()
    {
        countEnemies--;
    }

    public void AddSpawnPoint(SpawnPoint m_object)
    {
        spawnpoints.Add(m_object);
    }
}
