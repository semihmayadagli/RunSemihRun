using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Animator _Animator;
    public float waitingTime;
    public BoxCollider _Wind;

    public void AnimatorCondition(string condition) 
    {
        if (condition == "true")
        {
            _Animator.SetBool("Activate", true);
            _Wind.enabled = true;
        }
        else
        {
            _Animator.SetBool("Activate", false);            
            StartCoroutine(AnimationStart());
            _Wind.enabled = false;
        }
    
    }

    IEnumerator AnimationStart() 
    {
        yield return new WaitForSeconds(waitingTime);
        AnimatorCondition("true");    
    }
   
}
