//TEN SKRYPT JEST NA KAMERZE
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouserRotator : MonoBehaviour
{
    public float sensitivity; //Jak mocno obraca� kamer�
    public Transform player; //Gracz

    private float xRotation = 0f; //ROTACJA WED�UG OSI X 
    private float yRotation = 0f; //ROTACJA WED�UG OSI Y

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Kursor jest na �rodku i si� nie rusza
    }

    void Update()
    {
        float X = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; //POZYCJA MYSZKI W OSI X W CZASIE
        float Y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; //POZYCJA MYSZKI W OSI Y W CZASIE

        xRotation -= Y; //Y JEST ODWROTNIE NI� POWINNO W TYM MIEJSCU TO ODWRACAM
        yRotation += X; //ALE TU JU� DZIA�A NORMALNIE

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //NIE OBRACAJ GRACZA DO G�RY NOGAMI

        player.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); //OBR�� GRACZA NA PODSTAWIE TEGO GDZIE JEST MYSZKA
    }

}
