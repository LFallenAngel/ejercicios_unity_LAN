using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour {

    public int monedas = 0;
    public Text txtMonedas;


    void Start()
    {

        txtMonedas.text = monedas.ToString();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("magentico"))
        {
            monedas++;
            txtMonedas.text = monedas.ToString();
            Destroy(col.gameObject);
        }

    }


}
