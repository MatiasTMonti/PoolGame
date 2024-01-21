using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTable : MonoBehaviour
{
    public float tableWidth = 10f;
    public float tableHeight = 5f;
    public float holeRadius = 0.5f;

    public Sprite squareSprite;  // Asigna el sprite cuadrado desde el Inspector
    public Sprite circleSprite;  // Asigna el sprite de círculo desde el Inspector


    void Start()
    {
        CreateTableBackground();
        CreateTableBorders();
        CreateTableHoles();
    }

    void CreateTableBackground()
    {
        GameObject background = new GameObject("Background");
        background.transform.parent = transform;

        SpriteRenderer backgroundSprite = background.AddComponent<SpriteRenderer>();
        backgroundSprite.sprite = squareSprite;
        backgroundSprite.color = Color.green;

        // Escala del fondo
        backgroundSprite.transform.localScale = new Vector3(tableWidth, tableHeight, 1f);
        background.transform.position = new Vector3(0f, 0f, 0f);
    }

    void CreateBorder(string name, Vector2 position, Vector2 size)
    {
        GameObject border = new GameObject(name);
        border.transform.parent = transform;

        SpriteRenderer borderSprite = border.AddComponent<SpriteRenderer>();
        borderSprite.sprite = squareSprite;
        borderSprite.color = Color.red;

        // Escala de los bordes
        borderSprite.transform.localScale = new Vector3(size.x, size.y, 1f);
        border.transform.position = position;
    }

    void CreateTableBorders()
    {
        CreateBorder("TopBorder", new Vector2(0f, tableHeight / 2f), new Vector2(tableWidth, 0.1f));
        CreateBorder("BottomBorder", new Vector2(0f, -tableHeight / 2f), new Vector2(tableWidth, 0.1f));
        CreateBorder("LeftBorder", new Vector2(-tableWidth / 2f, 0f), new Vector2(0.1f, tableHeight));
        CreateBorder("RightBorder", new Vector2(tableWidth / 2f, 0f), new Vector2(0.1f, tableHeight));
    }

    void CreateHole(string name, Vector2 position)
    {
        GameObject hole = new GameObject(name);
        hole.transform.parent = transform;

        CircleCollider2D holeCollider = hole.AddComponent<CircleCollider2D>();
        holeCollider.radius = holeRadius;

        SpriteRenderer holeSprite = hole.AddComponent<SpriteRenderer>();
        holeSprite.sprite = circleSprite;

        holeSprite.color = Color.grey;

        // Escala del hoyo
        holeSprite.transform.localScale = new Vector3(holeRadius * 2f, holeRadius * 2f, 1f);

        hole.transform.position = position;
    }

    void CreateTableHoles()
    {
        CreateHole("HoleTopLeft", new Vector2(-tableWidth / 2f, tableHeight / 2f));
        CreateHole("HoleTopRight", new Vector2(tableWidth / 2f, tableHeight / 2f));
        CreateHole("HoleBottomLeft", new Vector2(-tableWidth / 2f, -tableHeight / 2f));
        CreateHole("HoleBottomRight", new Vector2(tableWidth / 2f, -tableHeight / 2f));
        CreateHole("HoleMiddleTop", new Vector2(0f, tableHeight / 2f));
        CreateHole("HoleMiddleBottom", new Vector2(0f, -tableHeight / 2f));
    }
}
