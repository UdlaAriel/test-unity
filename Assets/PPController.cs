using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PPController : MonoBehaviour
{
    public Transform player;
    public float marginToPlayer = 0.7f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            Vector2 destination = new Vector2(player.position.x, player.position.y) - marginToPlayer * direction.normalized;
            agent.SetDestination(destination);
        }
    }
}
