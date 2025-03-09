using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class ContadorScript : MonoBehaviour
{


    public Button boton;
    public int contador = 5;

    public TextMeshProUGUI texto;
    //crear sprites
    public Sprite[] sprites;
    public Image imagen;
    void Start()
    {
        boton.onClick.AddListener(Contar);

        if (boton == null)
        {
            Debug.LogError("El botón no está asignado en el Inspector.");
            return;
        }

        if (texto == null)
        {
            Debug.LogError("El texto no está asignado en el Inspector.");
            return;
        }
    }


    void Update()
    {

    }

    void Contar()
    {
        StartCoroutine(ContarCoroutine());
    }

    private IEnumerator ContarCoroutine()
    {
        while (true)
        {
            if (contador > 0)
            {
                texto.gameObject.SetActive(true);
                texto.text = contador.ToString();
                yield return new WaitForSeconds(1);
                contador--;
            }
            else
            {
                SceneManager.LoadScene("Perdiste");
                yield break;
            }
        }
    }
}
