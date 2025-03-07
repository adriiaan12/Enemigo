using UnityEngine;


public class MovimientoBala : MonoBehaviour
{
    public float velocidad = 10f;

    public LayerMask collisionMask;

    public delegate void OnDeath();

    public static event OnDeath OnDeathAnother;




    
    void Start()
    {
        
    }

    
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

        if(OnDeathAnother != null)
        {
            OnDeathAnother();
        }
        
    }
    

    void OnBecomeInvisible()
    {
       gameObject.SetActive(false);
    }
}
