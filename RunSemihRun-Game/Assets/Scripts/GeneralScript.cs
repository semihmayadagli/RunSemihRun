using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Semih
{
    public class GeneralScript : MonoBehaviour
    {
        public static void Cross(int digit, List<GameObject> Char_Pool, Transform _position, List<GameObject> CharCreativeEffect) 
        {
            int loopCount = (GameManager.totalCharCount * digit) - GameManager.totalCharCount;
            int count = 0;
            foreach (var item in Char_Pool)
            {
                if (count < loopCount)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in CharCreativeEffect)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = _position.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        item.transform.position = _position.position;
                        item.SetActive(true);
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }
            }
            GameManager.totalCharCount *= loopCount;

        }

        public static void Plus(int digit, List<GameObject> Char_Pool, Transform _position, List<GameObject> CharCreativeEffect) 
        {
            int count = 0;
            foreach (var item in Char_Pool)
            {
                if (count < digit)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in CharCreativeEffect)
                        {
                            if (!item2.activeInHierarchy)
                            {                                
                                item2.SetActive(true);
                                item2.transform.position = _position.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        item.transform.position = _position.position;
                        item.SetActive(true);
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }
            }
            GameManager.totalCharCount += digit;
        }

        public static void Minus(int digit, List<GameObject> Char_Pool, List<GameObject> CharDemolishEffect) 
        {
            if (GameManager.totalCharCount < digit)
            {
                foreach (var item in Char_Pool)
                {
                    foreach (var item2 in CharDemolishEffect)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 smokePos = new Vector3(item.transform.position.x, 0.25f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = smokePos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.totalCharCount = 1;

            }
            else
            {
                int count = 0;
                foreach (var item in Char_Pool)
                {

                    if (count != digit)
                    {
                        foreach (var item2 in CharDemolishEffect)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                Vector3 smokePos = new Vector3(item.transform.position.x, 0.25f, item.transform.position.z);
                                item2.SetActive(true);
                                item2.transform.position = smokePos;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            count++;
                        }
                        else
                        {
                            count = 0;
                            break;
                        }
                    }
                }
                GameManager.totalCharCount -= digit;
                
            }

        }

        public static void Div(int digit, List<GameObject> Char_Pool, List<GameObject> CharDemolishEffect) 
        {
            if (GameManager.totalCharCount <= digit)
            {
                foreach (var item in Char_Pool)
                {
                    foreach (var item2 in CharDemolishEffect)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 smokePos = new Vector3(item.transform.position.x, 0.25f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = smokePos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.totalCharCount = 1;

            }
            else
            {
                int loopCount = GameManager.totalCharCount / digit;
                int count = 0;
                foreach (var item in Char_Pool)
                {
                    if (count != loopCount)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in CharDemolishEffect)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 smokePos = new Vector3(item.transform.position.x, 0.25f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = smokePos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            count++;
                        }
                        else
                        {
                            count = 0;
                            break;
                        }
                    }
                }
                if (GameManager.totalCharCount % digit != 0)
                {
                    int countChar = GameManager.totalCharCount / digit;

                    for (int i = 1; i < GameManager.totalCharCount % digit; i++)
                    {
                        countChar++;
                    }
                    GameManager.totalCharCount = countChar;
                }
                else
                {
                    GameManager.totalCharCount /= digit;                    
                }
            }

        }
        
    }

}
