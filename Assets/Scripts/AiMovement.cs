using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AiMovement : MonoBehaviour
{
    [SerializeField] private bool ShouldPathfind;

    NavMeshAgent agent;
    public float agentSpeedWalk = 3.5f;
    public Transform[] goals;

    public bool chasing;
    private int index = 0;

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        if (ShouldPathfind)
        {
            anim.SetBool("walk", true);

            agent = GetComponent<NavMeshAgent>();
            agent.destination = goals[index].position;
        }
    
    }
    private Transform chaseTarget;
    public void StartChasing(Transform t)
    {
        agent.isStopped = true;
        anim.SetTrigger("Alert");
        Debug.Log("starting chase");
        // anim.SetBool("walk", false);
        StopAllCoroutines();
        StartCoroutine(alertTiming());
        chasing = true;
        chaseTarget = t;
    }

    public float alertAnimDuration = 1;
    private IEnumerator alertTiming()
    {
        anim.SetBool("walk", false);
        anim.SetBool("run", true);
        yield return new WaitForSeconds(alertAnimDuration);
        agent.isStopped = false;
    }
    public void TargetLost()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestPoint = null;
        foreach (Transform t in goals)
        {
            float newDist = Vector3.Distance(t.position, transform.position);
            if (newDist < closestDistance)
            {
                closestDistance = newDist;
                closestPoint = t;
            }
        }
        index = Array.IndexOf(goals, closestPoint);
        chasing = false;
        agent.destination = goals[index].position;
        anim.SetBool("walk", true);
        anim.SetBool("run", false);
        Debug.Log("Target Lost");
    }
    // Update is called once per frame
    void Update()
    {
        if (ShouldPathfind)
        {

            if (!chasing)
            {
                if (Vector3.Distance(transform.position, agent.destination) < 0.2f)
                {
                    if (index == goals.Length - 1)
                    {
                        //Debug.Log("Reversing Array");
                        Array.Reverse(goals);
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    int fuck;
                    if (index == 0) fuck = 0;
                    else fuck = index - 1;

                    StartCoroutine(setNewPos(goals[fuck].GetComponent<AIPos>().MoveDelay));

                }

                agent.speed = agentSpeedWalk;
            }
            else
            {
                agent.speed = 14;
                agent.destination = chaseTarget.position;
            }
        }
    }
    private IEnumerator setNewPos(float delay)
    {
        agent.isStopped = true;
        anim.SetBool("walk", false);
        agent.destination = goals[index].position;
        //Set idle
        yield return new WaitForSeconds(delay);
        agent.isStopped = false;
        anim.SetBool("walk", true);
        //Set run
    }
}
