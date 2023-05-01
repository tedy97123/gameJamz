using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Manager : MonoBehaviour
{

    public GameObject[] pizzaSpawnPoints;
    public GameObject player;
    public GameObject deliveryPrefab;

    public static int score = 0;
    public static int time = 90;
    public static int pizza = 3;

    public bool timerIsRunning = true;
    public static float timeRemaining = 90;

    public static int startingDeliveries = 2;

    private List<int> occupiedSpawnPoints = new List<int>();

    void Start()
    {
        int x = 0;

        do
        {
            int spawnPoint = Random.Range(0, pizzaSpawnPoints.Length);

            if (!occupiedSpawnPoints.Contains(spawnPoint))
            {
                x += 1;
                occupiedSpawnPoints.Add(spawnPoint);
            }
        } while (x < startingDeliveries);


        foreach (int i in occupiedSpawnPoints){
            Vector2 pos = pizzaSpawnPoints[i].transform.position;
            pos.y -= 0.05f;
            Instantiate(deliveryPrefab, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void SpawnDelivery(GameObject delivery) 
    {
        int minPoint = getMinPoint();
        int spawnPoint = getSpawnPoint();

        occupiedSpawnPoints.RemoveAll(item => item == minPoint);
        occupiedSpawnPoints.Add(spawnPoint);

        Vector2 pos = pizzaSpawnPoints[spawnPoint].transform.position;
        pos.y -= 0.05f;
        delivery.transform.position = pos;
    }

    private int getSpawnPoint()
    {
        int spawnPoint = 0;

        do
        {
            spawnPoint = Random.Range(0, pizzaSpawnPoints.Length);
        } while (occupiedSpawnPoints.Contains(spawnPoint));

        return spawnPoint;
    }

    private int getMinPoint() 
    {

        float min = Mathf.Infinity;
        int minPoint = 0;
        for (int i = 0; i < pizzaSpawnPoints.Length; i++)
        {
            float distance = (player.transform.position - pizzaSpawnPoints[i].transform.position).sqrMagnitude;

            if (distance < min)
            {
                min = distance;
                minPoint = i;
            }

        }

        return minPoint;
    }
}