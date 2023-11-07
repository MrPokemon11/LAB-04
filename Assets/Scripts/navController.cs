using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEditor.Animations;

public class navController : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private AnimatorController animController;
    private Animator animator;

    float defaultSpeed;
    public float climbSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animController = GetComponent<AnimatorController>();
        animator = GetComponent<Animator>();
        defaultSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Target.transform.position;

        if (agent.speed == climbSpeed)
        {
            animator.SetLayerWeight(4, 1);
        }
        else
        {
            animator.SetLayerWeight(4, 0);
        }

        if (Input.GetKey(KeyCode.K))
        {
            animator.SetLayerWeight(3, 1);
        } else
        {
            animator.SetLayerWeight(3, 0);
        }

    }

    /* void FixedUpdate()
    {
        int layerMask = 3;
        //layerMask = ~layerMask;
        RaycastHit hit;

        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 5, layerMask, QueryTriggerInteraction.Ignore))
        {
            animator.SetLayerWeight(3, 1);
        }
        else
        {
            animator.SetLayerWeight(3, 0);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ClimbObject")
        {
            agent.speed = climbSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ClimbObject")
        {
            agent.speed = defaultSpeed;
        }
    }
}
