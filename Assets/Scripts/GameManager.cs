using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    gameBegin,waitTouch
}
[System.Serializable]
public struct Level
{
    public int maxCar;
    public GameObject levelObject;
    public GameObject[] cars;
    [HideInInspector]public GameObject finish;
}

public class GameManager : MonoBehaviour
{
    public Level[] levels;

    public int currentLevel = 0;
    public int currentCar = 0;
    
    public GameStates isGame;

    [HideInInspector]public GameObject currentLevelObj;
    public Transform levelParent;

    public static GameManager instance { get; private set; }

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
    } //singleton

    private void Start()
    {
        isGame = GameStates.waitTouch;
        LoadLevel();
        
    }

    public void LoadLevel()
    {
        if (currentLevelObj == null)
        {
            currentLevelObj = Instantiate(levels[currentLevel].levelObject, Vector2.zero, Quaternion.identity, levelParent);
            Spawner.instance.SetCurrentLevel();
        }

        else
        {
            currentLevelObj.SetActive(false);
            currentLevelObj = Instantiate(levels[currentLevel].levelObject, Vector2.zero, Quaternion.identity, levelParent);
            Spawner.instance.SpawnCar();
            Spawner.instance.SpawnFinish();
        }
        
    }

    public void nextLevel()
    {
        currentLevel++;
        currentCar = 0;
        LoadLevel();
    }
    public void nextCar()
    {
        currentCar++;
        isGame = GameStates.waitTouch;
        if (currentCar < levels[currentLevel].maxCar)
            Spawner.instance.SetCurrentLevel();
        else                               
            nextLevel();// next Level UI

    }

    public void ResetLevel()
    {
        LoadLevel();
        currentCar = 0;
    }
}
