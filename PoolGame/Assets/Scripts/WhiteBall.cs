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
        // Actualiza la posición de la bola
        UpdatePosition();
    }

    void UpdatePosition()
    {
        // Mueve la bola según la velocidad
        transform.Translate(velocity * Time.deltaTime, Space.World);

        // Limita la posición dentro de la mesa (ajusta según el tamaño de la mesa)
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -5f, 5f),
            Mathf.Clamp(transform.position.y, -2.5f, 2.5f),
            transform.position.z
        );
    }

    public void CheckHoles(GameObject hole, float holeRadius)
    {
        // Obtén las posiciones de los círculos
        Vector2 posCircle1 = hole.transform.position;
        Vector2 posCircle2 = transform.position;

        // Calcula la distancia entre los centros de los círculos
        float distancia = Vector2.Distance(posCircle1, posCircle2);

        // Calcula la suma de los radios
        float sumaRadios = holeRadius + radius;

        // Verifica la colisión comparando la distancia con la suma de los radios
        if (distancia < sumaRadios)
        {
            // Hay colisión
            Debug.Log("¡Colisión!");
        }
    }

    public void HitBall(Vector2 direction)
    {
        velocity =- direction * 10f; // Ajusta la velocidad según tus necesidades
    }

    public void AskRadius()
    {
        radius = GetComponent<CircleCollider2D>().radius;
    }
}
