﻿#region usings

using System.Linq;
using UnityEngine;
using UnityEngine.AI;

#endregion

public class AI : MonoBehaviour {

    #region Variables and Properties

    public Animator animator;

    public NavMeshAgent nmAgent;
    public float distanceFromTarget;
    public int patrolTargetIndex = 0;

    public float fleeRange = 8;
    public float attackRange = 5;
    public float fireTimer = 10;
    public float reloadTime = 3;

    public int ammoCap = 5;
    public GameObject bullet;

    public Transform[] patrolTargets;
    public Transform[] fleeTargets;

    public GameObject player;
    public float speed = 0.1f;

    public Transform PatrolTarget { get; set; }
    public bool OnTarget {
        get {
            if (animator) return animator.GetBool("onTarget");
            animator = GetComponent<Animator>();
            return animator.GetBool("onTarget");
        }
        set {
            if (animator) animator.SetBool("onTarget", value);
            animator = GetComponent<Animator>();
            animator.SetBool("onTarget", value);
        }
    }

    #endregion

    void Awake() {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void GetNextPatrolTarget() {
        switch (patrolTargetIndex) {
            case 0:
                patrolTargetIndex = 1;
                break;
            case 1:
                patrolTargetIndex = 0;
                break;
        }
        PatrolTarget = patrolTargets[patrolTargetIndex];
        nmAgent.SetDestination(PatrolTarget.position);
        OnTarget = false;
    }

    public bool IsPlayerVisible() {
        RaycastHit hit;

        Vector3 vecToPlayer = (player.transform.position + Vector3.up) - transform.position;

        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        Debug.DrawRay(transform.position, vecToPlayer, Color.blue);

        bool inSight = !Physics.Raycast(
            transform.position,
            vecToPlayer.normalized, out hit,
            Vector3.Distance(transform.position, player.transform.position + Vector3.up*2), layerMask);
		//Debug.Log(hit.transform.name);
		//Debug.Log(inSight);
		
        if (hit.transform.tag == "Player") {
			//Debug.Log("hit player");
            return true;
        } 
		
		/* if (Physics.Raycast(
            transform.position,
            vecToPlayer.normalized, out hit,
            Vector3.Distance(transform.position, player.transform.position + Vector3.up*2), layerMask) == true)
			return true; */
			
        return false;
    }

    public void Chase() {
        nmAgent.SetDestination(player.transform.position);
    }

    public bool InAttackRange() {
		
        return Vector3.Distance(transform.position, player.transform.position) < attackRange;
    }

    public float GetFireTimer() {
        return fireTimer;
    }

    public void SetColor(Color color) {
        //transform.GetChild(0).GetComponent<Renderer>().materials[0].color = color;
    }

    public void Fire() {
        Instantiate(bullet, transform.position + transform.forward + (transform.up*3) , transform.rotation);
    }

    public void Reload() {
        animator.SetInteger("ammo", ammoCap);
    }

    public bool Fled() {
        return Vector3.Distance(player.transform.position, transform.position) > fleeRange;
    }

    public void Flee() {
        nmAgent.SetDestination(
            fleeTargets.Aggregate((i, j) =>
                Vector3.Distance(transform.position, i.position) > Vector3.Distance(transform.position, j.position)
                    ? i : j).position);
    }

    public void ClearNav() {
        nmAgent.ResetPath();
    }

    public void MoveToTarget() {
        nmAgent.SetDestination(PatrolTarget.position);

    }

}