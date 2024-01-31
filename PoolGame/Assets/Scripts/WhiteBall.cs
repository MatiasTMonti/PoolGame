using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    private Vector2 velocity;

    private float radius;

    private void Start()
    {
        AskRadius();
    }

    void Update()
    {
        // Actualiza la posici�n de la bola
        UpdatePosition();
    }

    void UpdatePosition()
    {
        // Mueve la bola seg�n la velocidad
        transform.Translate(velocity * Time.deltaTime, Space.World);

        // Limita la posici�n dentro de la mesa (ajusta seg�n el tama�o de la mesa)
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -5f, 5f),
            Mathf.Clamp(transform.position.y, -2.5f, 2.5f),
            transform.position.z
        );
    }

    public void CheckHoles(GameObject hole, float holeRadius)
    {
        // Obt�n las posiciones de los c�rculos
        Vector2 posCircle1 = hole.transform.position;
        Vector2 posCircle2 = transform.position;

        // Calcula la distancia entre los centros de los c�rculos
        float distancia = Vector2.Distance(posCircle1, posCircle2);

        // Calcula la suma de los radios
        float sumaRadios = holeRadius + radius;

        // Verifica la colisi�n comparando la distancia con la suma de los radios
        if (distancia < sumaRadios)
        {
            // Hay colisi�n
            Debug.Log("�Colisi�n!");
        }
    }

    public void HitBall(Vector2 direction)
    {
        velocity =- direction * 10f; // Ajusta la velocidad seg�n tus necesidades
    }

    public void AskRadius()
    {
        radius = GetComponent<CircleCollider2D>().radius;
    }
}
