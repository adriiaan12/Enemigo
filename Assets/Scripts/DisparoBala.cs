using UnityEngine;
using System.Collections.Generic;

public class DisparoBala : MonoBehaviour
{

    public Transform salida;

    public GameObject bala;

    public float tienmpoEnDisparos = 0.5f;

    private float proximoDisparo = 0f;

    public int tamanopool = 20;

    private List<GameObject> poolBalas;


    void Start()
    {
        poolBalas = new List<GameObject>();
        for (int i = 0; i < tamanopool; i++)
        {
            GameObject nuevaBala = Instantiate(bala);
            nuevaBala.SetActive(false);
            poolBalas.Add(nuevaBala);
        }
        
    }

    public void Disparar()
    {

        if (Time.time > proximoDisparo)
        {
            GameObject balaDisponible = ObtenerBalaInactiva();
            for (int i = 0; i < poolBalas.Count; i++)
            {
                if (balaDisponible != null)
                {
                    balaDisponible.transform.position = salida.position;
                    balaDisponible.transform.rotation = salida.rotation;
                    balaDisponible.SetActive(true);
                    proximoDisparo = Time.time + tienmpoEnDisparos;
                    
                }
            }
        }
    }

    private GameObject ObtenerBalaInactiva()
    {
        for (int i = 0; i < poolBalas.Count; i++)
        {
            if (!poolBalas[i].activeInHierarchy)
            {
                return poolBalas[i];
            }
        }
        
        GameObject nuevaBala = Instantiate(bala);
        nuevaBala.SetActive(false);
        poolBalas.Add(nuevaBala);
        return nuevaBala;
    }

    
    void Update()
    {
        
    }
}
