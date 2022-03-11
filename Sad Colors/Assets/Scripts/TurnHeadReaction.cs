using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHeadReaction : MonoBehaviour
{
    Coroutine turnHead;
    Coroutine returnHead;
    
    Quaternion prevRotation;
    Vector3 prevDirection;
    bool isTriggered;
    GameObject player;
    float rotationSpeed = 1.8f;



    private void Awake() 
    {
        prevDirection = transform.forward;
        prevRotation = Quaternion.LookRotation(prevDirection);
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
            player = other.gameObject;
            Vector3 toDirection = player.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(toDirection);

            transform.rotation = Quaternion.Euler(0,Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime).eulerAngles.y,0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player")
        {
            isTriggered = false;
            if (turnHead != null)
            {
                StopCoroutine(turnHead);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            isTriggered = false;
            returnHead = StartCoroutine(switchRoutine());
            
        }
    }

    
    IEnumerator switchRoutine()
    {
        turnHead = StartCoroutine(turnNPC_head(prevRotation,prevDirection));
        yield return new WaitForSeconds(3);
        yield return null;
    }

    IEnumerator turnNPC_head(Quaternion rotationTo, Vector3 directionTo)
    {
        while(!isTriggered)
        {
            transform.rotation = Quaternion.Euler(0,Quaternion.Lerp(transform.rotation, rotationTo, rotationSpeed * Time.deltaTime).eulerAngles.y,0);
            
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}
