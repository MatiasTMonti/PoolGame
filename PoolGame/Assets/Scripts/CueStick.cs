using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float cueLength = 2f;

    private WhiteBall whiteBall;

    private void Start()
    {
        whiteBall = FindObjectOfType<WhiteBall>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - whiteBall.transform.position).normalized;

        transform.right = direction;

        Vector2 cueEndPosition = (Vector2)whiteBall.transform.position + direction * cueLength;
        transform.position = cueEndPosition;

        if (Input.GetMouseButtonUp(0))
        {
            whiteBall.HitBall(direction);
        }
    }
}
