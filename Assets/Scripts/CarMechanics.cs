using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarMechanics : MonoBehaviour
{
    private GameObject car;
    private Rigidbody rbCar;
    
    [SerializeField] protected float carSpeed;
    [SerializeField] protected float rotationSpeed;


    public float Speed { get; protected set; }
    public float RotationSpeed { get; protected set; }
    protected void Awake()
    {
        Speed = carSpeed;
        RotationSpeed = rotationSpeed;
        car = this.gameObject;
        rbCar = car.GetComponent<Rigidbody>();
    }


    public void StopCar()
    {
        rbCar.velocity = Vector2.zero;
    }

    public void Movement()
    {
        if (rbCar.velocity.magnitude < 3)
            rbCar.AddForce(transform.forward * Speed);
    }
    public void Left()
    {
        transform.Rotate(Vector3.down * RotationSpeed);
    }
    public void Right()
    {
        transform.Rotate(Vector3.up * RotationSpeed);
    }




}
