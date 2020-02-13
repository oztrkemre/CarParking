using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject finishSprite;
    List<GameObject> carPoints = new List<GameObject>();
    List<GameObject> finishPoints = new List<GameObject>();




    Level currentLevel;

    public static Spawner instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            SpawnFinish();
    }

    List<int> lastCars = new List<int>();
    List<int> lastFinish = new List<int>();

    public int randomSpawnPoint(List<GameObject> list, bool isCar)
    {
        var randomPoint = Random.Range(0, list.Count);
        if (isCar)
            lastCars.Add(randomPoint);
        else
            lastFinish.Add(randomPoint);

        return randomPoint;
    }


    public void SpawnCar()
    {
        var random = randomSpawnPoint(carPoints, true);
        
        var carTemp =
            Instantiate(cars[Random.Range(0, cars.Length)],
            carPoints[random].transform.position,
            Quaternion.identity,
            GameManager.instance.currentLevelObj.transform);

        GameManager.instance.levels[GameManager.instance.currentLevel].cars[GameManager.instance.currentCar] = carTemp;
    }

    public void SpawnFinish()
    {
        var random = randomSpawnPoint(finishPoints, false);

        GameManager.instance.levels[GameManager.instance.currentLevel].finish =
            Instantiate(finishSprite, finishPoints[random].transform.position, Quaternion.Euler(90, 0, 0), GameManager.instance.currentLevelObj.transform);
    }


    public void SetCurrentLevel()
    {
        if (GameManager.instance.currentCar == 0)
        {
            foreach (GameObject carSpawn in GameObject.FindGameObjectsWithTag("carPoint"))
            {
                carPoints.Add(carSpawn);
            }
            foreach (GameObject finishSpawn in GameObject.FindGameObjectsWithTag("finishPoint"))
            {
                finishPoints.Add(finishSpawn);
            }
        }
        SpawnCar();
        SpawnFinish();
    }

}
