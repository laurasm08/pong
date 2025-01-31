using UnityEngine;
using TMPro; //Importamos esta libreria para los textos

public class ControladorJuego : MonoBehaviour
{
    //Textos de los marcadores
    [SerializeField] private TMP_Text marcadorPala1;
    [SerializeField] private TMP_Text marcadorPala2;
    //Componentes transform de las palas y la bola => para reiniciar posicion
    [SerializeField] private Transform pala1Transform;
    [SerializeField] private Transform pala2Transform;
    [SerializeField] private Transform bolaTransform;
    //Variable que almacena el valor de las puntuaciones
    private int golesPala1, golesPala2;

    //Usamos el patron Singleton para tener una unica instancia
    private static ControladorJuego instance;
    public static ControladorJuego Instance
    {
        get 
        { 
            if (instance == null)
            {
                instance = Object.FindFirstObjectByType<ControladorJuego>();
            }
            
            return instance; 
        }
    }

    //Actualizammos los marcadores
    public void GolPala1() 
    {
        golesPala1++;
        marcadorPala1.text = golesPala1.ToString();   
    }

    public void GolPala2()
    {
        golesPala2++;
        marcadorPala2.text = golesPala2.ToString();
    }

    //Cuando se anota un punto reiniciamos las posiciones de las palas y la bola
    public void Reiniciar()
    {
        pala1Transform.position = new Vector2(pala1Transform.position.x, 0);
        pala2Transform.position = new Vector2(pala2Transform.position.x, 0);
        bolaTransform.position = new Vector2(0, 0);
    }
    
}
