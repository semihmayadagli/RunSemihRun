using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Semih;

public class GameManager : MonoBehaviour
{        
    public GameObject limitLine;
    public static int totalCharCount = 1;

    public List<GameObject> Char_Pool;
    public List<GameObject> CharCreationEffect;
    public List<GameObject> CharDemolishEffect;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    public void NinjaManagement(string data, int mathDigit, Transform _position) 
    {
        switch (data)
        {
            case "cross":
                GeneralScript.Cross(mathDigit, Char_Pool, _position, CharCreationEffect);
                break;

            case "plus":
                GeneralScript.Plus(mathDigit, Char_Pool, _position, CharCreationEffect);
                break;

            case "minus":
                GeneralScript.Minus(mathDigit, Char_Pool, CharDemolishEffect);                               
                break;

            case "div":
                GeneralScript.Div(mathDigit, Char_Pool, CharDemolishEffect);                
                break;
        }

    }
    public void CreateCharDemolishEffect(Vector3 _position) 
    {
        foreach (var item in CharDemolishEffect)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = _position;
                item.GetComponent<ParticleSystem>().Play();
                totalCharCount--;
                break;
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
