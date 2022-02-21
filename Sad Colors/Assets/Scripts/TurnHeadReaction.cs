using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHeadReaction : MonoBehaviour
{
    public Coroutine turnHead;
    bool isTriggered;
    GameObject player;
    float rotationSpeed = 1.5f;

    private void OnTriggerEnter(Collider other) 
    {
        isTriggered = true;
        player = other.gameObject;
        //turnHead = StartCoroutine(turnNPC_head(other));
    }

    private void OnTriggerExit(Collider other) 
    {
        isTriggered = false;
        //StopCoroutine(turnHead);
    }

    private void FixedUpdate() 
    {
        if (isTriggered)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0,Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime).eulerAngles.y,0);
        }

    }

    IEnumerator turnNPC_head(Quaternion startpos,Quaternion endpos)
    {
        float t = 0.0f;
        while (t <= 1.0) {
            t += Time.deltaTime/2;
            Quaternion rotationReturn = Quaternion.Lerp(startpos, endpos, Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
    }
}
