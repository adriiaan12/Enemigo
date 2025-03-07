using UnityEngine;

public class Ordas : MonoBehaviour
{
    
    public ValoresEnemigos[] olaEnemigos;

    private ValoresEnemigos olaActual;
    float tiempoEspera = 0f;

    int numeroOlaActual = 0;

    int enemigosporCrear = 0;

    int enemigosparaMatar = 0;

    void Start()
    {
        NextOla();

        MovimientoBala.OnDeathAnother += MuereOtro;
    }

    
    void Update()
    {
        if(enemigosporCrear > 0 && Time.time > tiempoEspera)
        {
            this.enemigosporCrear--;
            tiempoEspera = Time.time + olaActual.tiempoEnemigos;
            GameObject enemigoparaCrear = Instantiate(olaActual.tipoEnemigo,Vector3.zero,Quaternion.identity);

        }
    }

    void MuereOtro()
    {
        enemigosparaMatar--;
        if(enemigosparaMatar == 0)
        {
            NextOla();
        }
    }

    void NextOla()
{
    if (numeroOlaActual < olaEnemigos.Length)
    {
        olaActual = olaEnemigos[numeroOlaActual];
        enemigosporCrear = olaActual.numEnemigos;
        enemigosparaMatar = olaActual.numEnemigos;
        numeroOlaActual++; // Mueve esta línea al final para evitar errores de índice
    }
    else
    {
        Debug.Log("No hay más olas disponibles.");
    }
}

}
