using UnityEngine;

public class Pala : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float velocidad = 2f; //Pongo SerializeField para que desde unity salga el movimiento como parámetro y modificarlo desde ahí.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Creamos un if para que cada pala se mueva independiente, según que tecla estemos pulsando.
        float movimiento;
        if (this.name == "Pala1")
        {
            movimiento = Input.GetAxisRaw("VerticalPala1"); //Recogemos el movimiento de las teclas arriba y abajo.
            
        }
        else {
            movimiento = Input.GetAxisRaw("VerticalPala2");

        }
        /*Movemos la pala.
         * Transform representa la posoción, rotación y escla del objeto, cada objeto va a tener un componente transform para manipular la ubicación y el aspecto del objeto.
         * Position representa la posición del objeto.
         * Time.deltaTime hace que todas las cosas del juego se muevan a la misma velocidad.
         */

        //Movemos la pala en base al movimiento de las teclas de los ejes (x, y, z) para establecer límites y que las palas no se salgan. 
        float posY = transform.position.y + (movimiento * velocidad * Time.deltaTime);
        if((posY < 3.5f) && (posY > -3.5f))
        {
            transform.position = new Vector3(transform.position.x, posY, 0);
        }
        
    }
        
        

        
    
}
