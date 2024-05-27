using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float maxSpeed = 5.0f;
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;

    private Vector3 velocity = Vector3.zero; //Pr�ko�� to pusty wektor

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

        Vector3 worldDirection = transform.TransformDirection(inputDirection); //We� poprawk� na orientacj� gracza by ruch by� relatywny do niej 
        Vector3 desiredVelocity = worldDirection.normalized * maxSpeed; //Wektor pokazuj�cy w kierunku w kt�rym gracz chce i�� i d�ugo�ci max speed

        velocity = Vector3.MoveTowards(velocity, desiredVelocity, (desiredVelocity == Vector3.zero ? deceleration : acceleration) * Time.deltaTime); //Powoli transformuj wektor obecnej pr�dko�ci do wektora pr�dko�ci jak� chce gracz a je�li takiego nie ma to walnij chamulec
        transform.Translate(velocity * Time.deltaTime, Space.World); //Dodaj ten wektor si�y do gracza
    }
}
