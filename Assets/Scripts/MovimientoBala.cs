using UnityEngine;


public class MovimientoBala : MonoBehaviour
{
    public float velocidad = 10f;

    public LayerMask collisionMask;



    // alled once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = velocidad * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);

        CheckCollisions(moveDistance);
        
    }

    private void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance))
        {
            OnHitObject(hit);
        }
    }

    private void OnHitObject(RaycastHit hit)
    {
        gameObject.SetActive(false);
        
        if (hit.collider.gameObject.layer == 8)
        {
            MovimientoEnemigo enemigo = hit.collider.GetComponent<MovimientoEnemigo>();
            if (enemigo != null)
            {
                enemigo.TakeHit(1);
            }
        }
        
    }
    

    void OnBecomeInvisible()
    {
       gameObject.SetActive(false);
    }
}
