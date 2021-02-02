using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChainController : MonoBehaviour
{
    public float inverseSpeed = 0.5f;
    public float minDist = 1;
    public List<GameObject> objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objects.Count == 0) return;
        objects[0].transform.position = this.transform.position;

        for (int i = 1; i < objects.Count; i++)
        {
            var c = objects[i];
            var l = objects[i - 1];
            var dist = Vector3.Distance(c.transform.position, l.transform.position);
            var v = (dist - minDist) / inverseSpeed;

            if (dist - v < minDist)
            {
                v = dist - minDist;
            }

            c.transform.position = Lerp(c.transform.position, l.transform.position, v);
        }
    }

    public Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a).normalized * t;
    }
}
