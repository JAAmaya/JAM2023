using UnityEngine;
using UnityEngine.AI;

public class LogicaMonstruo : MonoBehaviour
{
    public float VelocidadCorrer = 1f;
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
    }

    private void Update()
    {
        agent.destination = destino.position;
        var VelX = agent.velocity.x/VelocidadCorrer;
        var VelY = agent.velocity.z/VelocidadCorrer;

        anim.SetFloat("VelX", VelX);
        anim.SetFloat("VelY", VelY);
    }
}
