using System;
using Unity.Mathematics;
using UnityEngine;


public class Bola : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float velocidadInicial = 4f;
    [SerializeField] private float valorDeMultiplicacion = 1.1f;

    private Rigidbody2D bolaRb; //Ponemos el Rigidbody2D porque queremos aplicar las fuerzas de la fisica del movimiento a la bola.
    void Start()
    {
        bolaRb = GetComponent<Rigidbody2D>(); //Capturamos el movimiento de la bola con el Rigidbody2D.
        Lanzar();
    }

    //Metodo que se encargara de lanzar la bola
    private void Lanzar()
    {
        float velocidadX = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1; //Creamos un rango con Range de numeros aleatorios entre 0 y 1. Si el numero es 0 lo cambia a 1 y si es 1 lo cambia a -1 para la posicion de los ejes en X de (1,-1)
        float velocidadY = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        //Asignamos a la velocidad de la bola un Vector2 y la mmultiplicamos por la velociad inicial.
        bolaRb.linearVelocity = new Vector2(velocidadX, velocidadY) * velocidadInicial; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verificamos si la bola colisiona contra un objeto con la etiqueta "Pala" y aumentamos la velocidad
        if (collision.gameObject.CompareTag("Pala"))
        {
            bolaRb.linearVelocity *= valorDeMultiplicacion;
        }
    }

    //Detectamos si se alcanzo alguna de las 2 zonas de gol
    private void OnTriggerEnter2D(Collider2D collision)
    {;
        if (collision.gameObject.CompareTag("GolPala1"))
        {
            ControladorJuego.Instance.GolPala2();
        }
        else
        {
            ControladorJuego.Instance.GolPala1();
        }
        //Reiniciamos los elementos del juego y lanzamos la bola
        ControladorJuego.Instance.Reiniciar();
        Lanzar();
    }



}
