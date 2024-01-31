using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    public float mass = 1f;
    public float friction = 0.95f;
    public float maxSpeed = 10f;
    public float rightClickImpulse = 20f; // Fuerza de impulso al hacer clic derecho

    public GameObject cueStick;  // Asigna el GameObject del palo desde el Inspector

    private Vector2 velocity;
    private float rotationSpeed = 100f;  // Velocidad de rotación del palo

    private float radius;

    private void Start()
    {
        // Busca el GameObject del cueStick en los hijos de la bola blanca
        cueStick = transform.Find("CueStick").gameObject;

        if (cueStick == null)
        {
            Debug.LogError("No se encontró el GameObject del CueStick. Asegúrate de que esté correctamente configurado en la jerarquía.");
        }

        AskRadius();
    }

    void Update()
    {
        // Maneja la entrada del usuario o cualquier lógica de movimiento aquí
        HandleInput();

        // Actualiza la posición de la bola
        UpdatePosition();

        // Rota el palo alrededor de la bola
        RotateCueStick();
    }

    void HandleInput()
    {
        // Ejemplo: Utiliza las teclas de flecha para mover la bola y rotar el palo
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcula la nueva velocidad basada en la entrada del usuario
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;
        velocity += inputVector * Time.deltaTime * 10f;

        // Aplica la fricción para simular la desaceleración
        velocity *= friction;

        // Asegúrate de que la velocidad no exceda la velocidad máxima
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);

        // Impulso adicional al hacer clic derecho
        if (Input.GetMouseButtonDown(1))  // Botón derecho del ratón
        {
            ApplyRightClickImpulse();
        }
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

    void RotateCueStick()
    {
        // Obtiene la posición del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calcula la dirección desde la bola blanca hasta la posición del ratón
        Vector3 directionToMouse = mousePosition - transform.position;

        // Calcula el ángulo en radianes y conviértelo a grados
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // Rota el palo hacia el ángulo calculado
        cueStick.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }

    void ApplyRightClickImpulse()
    {
        // Aplica un impulso adicional al hacer clic derecho
        velocity += (Vector2)cueStick.transform.up * rightClickImpulse;
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

    public void AskRadius()
    {
        radius = GetComponent<CircleCollider2D>().radius;
    }
}
