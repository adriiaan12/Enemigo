using UnityEngine;

public class MovimientoEnemigo : LivingEntity
{
   

    UnityEngine.AI.NavMeshAgent pathFinder;



    Transform target;
    JugadorController jugador;

    float mycollisionRadius;
    float targetCollisionRadius;

    float distanciaAtaque = 1.5f;

   
    protected override void Start()
    {
        base.Start();
        mycollisionRadius = GetComponent<CapsuleCollider>().radius;
        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;

    }

    void Awake()
    {
        
        pathFinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        

    }
    void Update()
    {
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Vector3 targetPosition = target.position - dirToTarget * (mycollisionRadius + targetCollisionRadius + distanciaAtaque);
        pathFinder.SetDestination(targetPosition);
    }

    public override void TakeHit(float damage)
    {
        base.TakeHit(damage);

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
