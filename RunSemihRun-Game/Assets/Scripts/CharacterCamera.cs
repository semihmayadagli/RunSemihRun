using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;

    void Start()
    {
        targetOffset = transform.position - target.position;
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position+targetOffset, 0.125f);

    }
}
