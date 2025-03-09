using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ordas : MonoBehaviour
{
    public ValoresEnemigos[] olaEnemigos;

    private ValoresEnemigos olaActual;
    float tiempoEspera = 0f;
    int numeroOlaActual = 0;
    int enemigosPorCrear = 0;
    int enemigosVivos = 0;

    void Start()
    {
        NextOla();
    }

    void Update()
    {
        if (enemigosPorCrear > 0 && Time.time > tiempoEspera)
        {
            enemigosPorCrear--;
            tiempoEspera = Time.time + olaActual.tiempoEnemigos;

            // Instanciar enemigo
            GameObject enemigoGO = Instantiate(olaActual.tipoEnemigo, Vector3.zero, Quaternion.identity);
            enemigoGO.SetActive(true);


            // Contar enemigo vivo
            enemigosVivos++;

            // Obtener componente y suscribirse al evento de muerte
            LivingEntity enemigo = enemigoGO.GetComponent<LivingEntity>();
            if (enemigo != null)
            {
                enemigo.OnDeath += EnemigoMuerto;
            }
        }
    }

    void EnemigoMuerto()
    {
        enemigosVivos--;

        if (enemigosVivos <= 0 && enemigosPorCrear <= 0)
        {
            // Todos los enemigos han muerto, siguiente ola
            NextOla();
        }
    }

    void NextOla()
    {
        if (numeroOlaActual >= olaEnemigos.Length)
        {
            Debug.Log("¡Todas las olas completadas!");
            SceneManager.LoadScene("Ganar");
            return;
        }

        Debug.Log("Iniciando ola " + (numeroOlaActual + 1));
        olaActual = olaEnemigos[numeroOlaActual];
        enemigosPorCrear = olaActual.numEnemigos;
        enemigosVivos = 0;
        numeroOlaActual++;
    }
}
