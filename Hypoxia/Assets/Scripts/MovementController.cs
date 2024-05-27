using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;

    private Vector3 velocity = Vector3.zero; //Prêkoœæ to pusty wektor

    void Update()
    {
        Vector3 inputDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection += Vector3.right;
        }

        Vector3 worldDirection = transform.TransformDirection(inputDirection); //WeŸ poprawkê na orientacjê gracza by ruch by³ relatywny do niej 
        Vector3 desiredVelocity = worldDirection.normalized * maxSpeed; //Wektor pokazuj¹cy w kierunku w którym gracz chce iœæ i d³ugoœci max speed

        velocity = Vector3.MoveTowards(velocity, desiredVelocity, (desiredVelocity == Vector3.zero ? deceleration : acceleration) * Time.deltaTime); //Powoli transformuj wektor obecnej prêdkoœci do wektora prêdkoœci jak¹ chce gracz a jeœli takiego nie ma to walnij chamulec
        transform.Translate(velocity * Time.deltaTime, Space.World); //Dodaj ten wektor si³y do gracza
    }
}
