using UnityEngine;
using System.Collections.Generic;
public class DisparoBala : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform salida;
    public GameObject bala;
    public float tiempoDisparo = 0.5f;
    float proximoDisparo = 0f;

    public int tamanoPool = 20;
    private List<GameObject> poolBalas;
    void Start()
    {
        poolBalas = new List<GameObject>();
        for (int i = 0; i < tamanoPool; i++)
        {
            GameObject obj = Instantiate(bala);
            obj.SetActive(false);
            poolBalas.Add(obj);
        }
        
    }
    public void Disparar(){

        if(Time.time > proximoDisparo){ 
                GameObject balaDisponible = ObtenerBalaDisponible();
                if(balaDisponible != null){
                    balaDisponible.transform.position = salida.position;
                    balaDisponible.transform.rotation = salida.rotation;
                    balaDisponible.SetActive(true);
                    proximoDisparo = Time.time + tiempoDisparo;
                } 


        }

    }

    private GameObject ObtenerBalaDisponible(){
        for (int i = 0; i < poolBalas.Count; i++)
        {
            if(!poolBalas[i].activeInHierarchy){
                return poolBalas[i];
            }
        }

    GameObject obj = Instantiate(bala);
    obj.SetActive(false);
    poolBalas.Add(obj);
    return obj;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
