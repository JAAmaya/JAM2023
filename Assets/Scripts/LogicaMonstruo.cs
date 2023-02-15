using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class LogicaMonstruo : MonoBehaviour
{
    public GameObject ruta;
    public bool forzarAndar = false;
    public float VelocidadAndar;
    public float VelocidadCorrer;
    public float DistanciaMinima;

    GameObject jugador;
    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;
    Vector3[] puntosRuta;
    bool siguiendo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoRepath = false;
        jugador = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.speed = VelocidadCorrer;
        siguiendo = false;
        Debug.Log(ruta.transform.childCount);
        puntosRuta = new Vector3[ruta.transform.childCount];
        for (int i = 0; i < ruta.transform.childCount; i++)
        {
            puntosRuta[i] = ruta.transform.GetChild(i).position;
        }
        //agent.SetDestination(jugador.transform.position);
    }

    private void Update()
    {
        //Si veo al jugador, ir por el
        //Si lo dejo de ver, ir al ultimo punto
        //Si no lo veo, patrullar
        //Intentar trazar ruta al siguiente punto
        //Si la ruta es invalida, renovar punto
        //Debug.Log(agent.pathStatus);
        NavMeshHit hit;
        if (!agent.Raycast(jugador.transform.position, out hit))//Si entra por aqui es q no hay obstaculo en el raycast
        {
            //Debug.LogWarning("AYUDA ME ESTA VIENDO");
            agent.destination = jugador.transform.position;
            if(!siguiendo)
            {
                agent.speed = VelocidadCorrer;
                FindObjectOfType<AudioManager>().Play("MonstruoTeVe");
            }
            siguiendo = true;
        }
        else
        {
            if(siguiendo && agent.remainingDistance < DistanciaMinima)
            {
                agent.speed = VelocidadAndar;
                siguiendo = false;
            }
            if (agent.pathStatus != NavMeshPathStatus.PathComplete || agent.remainingDistance < DistanciaMinima)
            {
                SiguienteDestino();
            }
        }


        agent.speed = forzarAndar ? VelocidadAndar : VelocidadCorrer;
        var VelX = agent.velocity.magnitude / VelocidadCorrer;
        anim.SetFloat("VelX", VelX);
    }

    void SiguienteDestino()
    {
        var siguienteDestino = puntosRuta[Random.Range(0, puntosRuta.Length - 1)];
        NavMeshPath path = new NavMeshPath();
        //agent.CalculatePath(siguienteDestino, path);
        //if (path.status == NavMeshPathStatus.PathPartial)
        //    SiguienteDestino();
        agent.SetDestination(siguienteDestino);
    }
}
