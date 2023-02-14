using UnityEngine;
using UnityEngine.AI;

public class LogicaMonstruo : MonoBehaviour
{
    public bool forzarAndar = false;
    public float VelocidadAndar;
    public float VelocidadCorrer;
    Transform destino;
    NavMeshAgent agent;
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destino = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent.speed = VelocidadCorrer;
    }

    private void Update()
    {
        agent.destination = destino.position;
        agent.speed = forzarAndar ? VelocidadAndar : VelocidadCorrer;
        var VelX = agent.velocity.magnitude / VelocidadCorrer;
        //var VelY = agent.velocity.z / VelocidadCorrer;

        anim.SetFloat("VelX", VelX);
        //anim.SetFloat("VelY", VelY);
    }
}
