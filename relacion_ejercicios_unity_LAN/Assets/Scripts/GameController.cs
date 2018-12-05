using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public Animator animInterface;
    public bool pausa = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausa = !pausa; //cuando pulsas esc pausa se vuelve true, o viceversa
            animInterface.SetBool("activar", pausa);
        }

        if (pausa)
        {
            Time.timeScale = 0f; //o a 0.5f para que vaya muy lento
        }
        else
        {
            Time.timeScale = 1f;
        }
       

        

    }

    public void PulsoPlay()
    {
        Time.timeScale = 1f;
        animInterface.SetBool("activar", !pausa);
        SceneManager.LoadScene("Escena1");

    }
}
