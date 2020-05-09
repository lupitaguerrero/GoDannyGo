using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Target;
    //public GameObject explosion;
    //private float speed;

    public float playerDistance;
    public float awareAI = 10f;
    public float AIMoveSpeed;
    public float damping = 3f;

    public Transform[] navPoint;
    public UnityEngine.AI.NavMeshAgent agent;
    public int destPoint = 0;
    public Transform goal;

    // Start is called before the first frame update
    void Start()
    {
        AIMoveSpeed = 5f;

        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;

        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.LookAt(Target);
        transform.position += transform.forward * AIMoveSpeed * Time.deltaTime;
        */

        playerDistance = Vector3.Distance(Target.position, transform.position);

        if(playerDistance < awareAI)
        {
            LookAtPlayer();
            Debug.Log("Seen");
        }
        if(playerDistance < awareAI)
        {
            if(playerDistance > 1f)
            {
                Chase();
            }
            else
            {
                GotoNextPoint();
            }
        }

        {
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

    }

    void LookAtPlayer()
    {
        transform.LookAt(Target);
    }

    void GotoNextPoint()
    {
        if (navPoint.Length == 0)
            return;
        agent.destination = navPoint[destPoint].position;
        destPoint = (destPoint + 1) % navPoint.Length;
    }

    void Chase()
    {
        transform.Translate(Vector3.forward * AIMoveSpeed * Time.deltaTime);
    }

    /*
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(this);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    */
}
