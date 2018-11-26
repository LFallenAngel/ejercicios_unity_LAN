﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Transform moneda;
    Rigidbody2D rbMoneda;
    public Transform imanMonedas;

    public int fuerza = 10;
    public float moveSpeed = 10f;
    public int fuerzaMoneda = 10;
    public List<GameObject> arrayMonedas = new List<GameObject>();


    int fuerzaSalto = 30;


    private Vector2 mousePosition;
    private Vector2 posicionMovimiento;
    private int maxMonedas = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // moneda = GameObject.Find("magnetico").GetComponent<Transform>();

    }


    void Update()
    {
        Movimiento();
        //SeguirRaton();
        //SeguirPulsarRaton();
    }
    void SeguirRaton()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 posicion = new Vector2(mousePosition.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, posicion, moveSpeed * Time.deltaTime);
        // time.deltaTime sirve para detectar los segundos por frame * por la velocidad
    }
    void Movimiento()
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
            LanzaMonedas();

        }
    }
    void SeguirPulsarRaton()
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
        if (col.gameObject.tag == "magnetico" && arrayMonedas.Count < maxMonedas)
        {
            rbMoneda = col.gameObject.GetComponent<Rigidbody2D>();

            rbMoneda.simulated = false;

            arrayMonedas.Add(col.gameObject);
            //Debug.Log("Tengo " + arrayMonedas.Count);

            AtraerMonedas(col.transform);
        }


    }

    void AtraerMonedas(Transform trMoneda)
    {
        trMoneda.position = imanMonedas.position;

        trMoneda.parent = transform;

        //trMoneda.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // trMoneda.GetComponent<Rigidbody2D>().mass = 0;

    }

    void LanzaMonedas()
    {
        GameObject ultimaMoneda;

        rbMoneda.simulated = true;

        ultimaMoneda = arrayMonedas[arrayMonedas.Count - 1];

        ultimaMoneda.transform.parent = null;
        rbMoneda.velocity = Vector2.right * fuerzaMoneda;

        arrayMonedas.Remove(ultimaMoneda);



    }
}

