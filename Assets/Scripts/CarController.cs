using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum carType
{
    blueCar,
    redCar
}

public class CarController : CarMechanics
{
    bool isCarActive = true;
    public carType car;
    private void FixedUpdate()
    {
        if(GameManager.instance.isGame == GameStates.waitTouch && Input.GetMouseButton(0))
        {
            GameManager.instance.isGame = GameStates.gameBegin;
        }


        else if (GameManager.instance.isGame == GameStates.gameBegin && isCarActive)
        { 
            Movement();
            if (ButtonEvents.instance.isLeft)
                Left();
            else if (ButtonEvents.instance.isRight)
                Right();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("wall") || collision.transform.CompareTag("Player"))
        {
            GameManager.instance.ResetLevel();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Finish") && isCarActive)
        {
            Debug.Log("triggered by finish");
            StopCar();
            GameManager.instance.levels[GameManager.instance.currentLevel].finish.SetActive(false);
            isCarActive = false;
            GameManager.instance.nextCar();
        }
    }

}
