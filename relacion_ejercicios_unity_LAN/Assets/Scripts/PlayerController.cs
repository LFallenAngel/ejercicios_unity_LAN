using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Transform moneda;

    public int fuerza = 10;
    public float moveSpeed = 10f;

    int fuerzaSalto = 30;
    
   
    private Vector2 mousePosition;
    private Vector2 posicionMovimiento;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // moneda = GameObject.Find("magnetico").GetComponent<Transform>();
        
    }

    void Update()
    {
        movimiento();
        //seguirRaton();
        seguirPulsarRaton();
    }
    void seguirRaton()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 posicion = new Vector2(mousePosition.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, posicion, moveSpeed * Time.deltaTime);
        // time.deltaTime sirve para detectar los segundos por frame * por la velocidad
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
    void seguirPulsarRaton()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionMovimiento = mousePosition;
        }

        Vector2 posicion = new Vector2(mousePosition.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, posicion, moveSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "magnetico")
        {
            atraerMonedas(col.transform);
        }


    }
   
    void atraerMonedas(Transform trMoneda)
    {

        trMoneda.parent = transform;
       
       
    }
}

