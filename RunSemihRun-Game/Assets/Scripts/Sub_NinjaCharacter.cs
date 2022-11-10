using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sub_NinjaCharacter : MonoBehaviour
{
    GameObject limitLine;
    NavMeshAgent _nMAgent;
    


    void Start()
    {
        _nMAgent = GetComponent<NavMeshAgent>();
        limitLine = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().limitLine;
        
    }

    private void LateUpdate()
    {
        _nMAgent.SetDestination(limitLine.transform.position);
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("BoxObstacles"))
        {
            Vector3 smokePos = new Vector3(transform.position.x, 0.25f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CreateCharDemolishEffect(smokePos);            
            gameObject.SetActive(false);    
        }

        if (other.CompareTag("Saw"))
        {
            Vector3 smokePos = new Vector3(transform.position.x, 0.25f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CreateCharDemolishEffect(smokePos);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Hammer"))
        {
            Vector3 smokePos = new Vector3(transform.position.x, 0.25f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().CreateCharDemolishEffect(smokePos);
            gameObject.SetActive(false);
        }
    }

}
