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
    private int maxMonedas = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // moneda = GameObject.Find("magnetico").GetComponent<Transform>();
        
    }

    void Update()
    {
        movimiento();
        //seguirRaton();
        //seguirPulsarRaton();
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
        if (Input.GetKey(KeyCode.Space))
        {
            if (maxMonedas==1 ) {

                lanzaMonedas(transform);
            }
            
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
        if (col.gameObject.tag == "magnetico" && maxMonedas == 0)
        {
            atraerMonedas(col.transform);
            maxMonedas = 1;
        }


    }
   
    void atraerMonedas(Transform trMoneda)
    {

        trMoneda.parent = transform;

        trMoneda.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
       // trMoneda.GetComponent<Rigidbody2D>().mass = 0;
       
    }

    void lanzaMonedas(Transform trMoneda)
    {
        trMoneda.transform.DetachChildren();
        trMoneda.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0)*fuerza);
        
        
    }
}

