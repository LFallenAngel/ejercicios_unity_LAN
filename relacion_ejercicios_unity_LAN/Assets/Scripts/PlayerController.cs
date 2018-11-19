using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public int fuerza = 10;
    int fuerzaSalto = 30;
    private Vector2 mousePosition;
    public float moveSpeed = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePosition = transform.position;
    }

    void Update()
    {
        movimiento();
        seguirRaton();
    }
    void seguirRaton()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 posicion = new Vector2(mousePosition.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, posicion, moveSpeed * Time.deltaTime);
    }
    void movimiento()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * fuerza);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * fuerza);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * fuerzaSalto);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * fuerza);
        }
    }

}
