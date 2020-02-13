using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public bool isLeft,isRight;

    public static ButtonEvents instance { get; private set; }

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

    public void LeftDown()
    {
        isLeft = true;
    }
    public void LeftUp()
    {
        isLeft = false;
    }
    public void RightDown()
    {
        isRight = true;
    }
    public void RightUp()
    {
        isRight = false;
    }

}
