using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iman : MonoBehaviour {


    Rigidbody2D rbMoneda;
    Transform trMoneda;


    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("magnetico"))
        {
            rbMoneda = col.gameObject.GetComponent<Rigidbody2D>();

            rbMoneda.simulated = false;

            AtraeMonedas(col);
        }

        
    }

    void AtraeMonedas(Collision2D col)
    {


   
        trMoneda = col.gameObject.GetComponent<Transform>();

        trMoneda.parent = transform;
   


    }
}
