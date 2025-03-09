using UnityEngine;
using static JugadorController;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]



public class JugadorController : LivingEntity
{

    DisparoBala disparoBala;
    public  Camera camera;
    CharacterController characterController;

    Rigidbody rb;

    Vector3 moveInput,moveVelocity;

    public float velocidad = 5f;

    Vector3 lastHitpoint,lookAt;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){


        characterController.Move(moveVelocity * Time.deltaTime);
        moveVelocity = moveInput * velocidad;

    }


    protected override void Start()
    {   
        base.Start();
        disparoBala = GetComponent<DisparoBala>();

         OnDeath += OnJugadorMuerte;
    }
       void OnJugadorMuerte()
    {
        // Cargar la escena de "Perder"
        SceneManager.LoadScene("HasPerdido");
    }

    // Update is called once per frame
    void Update()
    {   
        

        moveInput = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {

            Debug.DrawLine(ray.origin,lookAt,Color.red);
            lastHitpoint = hit.point;
            rb.transform.LookAt(new Vector3(hit.point.x,rb.transform.position.y,hit.point.z),Vector3.up);

        }else{
           rb.transform.LookAt(new Vector3(lastHitpoint.x,rb.transform.position.y,lastHitpoint.z),Vector3.up);
        }

        if(Input.GetMouseButtonDown(0)){
            disparoBala.Disparar();
        }




    }
}