using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCharacter : MonoBehaviour
{
    public GameManager _gameManager;
   
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {            
            if (Input.GetAxis("Mouse X")>0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), 0.1f);                
            }

            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z), 0.15f);                
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cross" || other.gameObject.tag == "plus" || other.gameObject.tag == "minus" || other.gameObject.tag == "div")
        {
            int digit = int.Parse(other.gameObject.name);
            _gameManager.NinjaManagement(other.gameObject.tag,digit, other.gameObject.transform);

        }
        
    }

}
