using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // 目的地となるGameObjectをセットします。
    public GameObject target;
    private NavMeshAgent myAgent;

    void Start()
    {
        // Nav Mesh Agent を取得します。
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        // targetに向かって移動します。
        if(myAgent.pathStatus != NavMeshPathStatus.PathInvalid){
            myAgent.SetDestination(target.transform.position);
        }
    }
}