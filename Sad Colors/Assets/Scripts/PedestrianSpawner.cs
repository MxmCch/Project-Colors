using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public GameObject pedestrianPrefab;
    public int pedestriansToSpawn;

    private void Start() 
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int count = 0;
        while (count < pedestriansToSpawn)
        {
            GameObject obj = Instantiate(pedestrianPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount-1));
            obj.GetComponent<WaypointNavigator>()._CurrentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;
            //StartCoroutine(ColliderDelay(obj));
            yield return new WaitForEndOfFrame();
            count++;
        }
    }
    
    private IEnumerator ColliderDelay(GameObject gameObject)
    {
        CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        capsuleCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        capsuleCollider.enabled = true;
    }
}
