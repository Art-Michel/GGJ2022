using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 desiredPos;
    Vector3 myPos;
    bool isTank;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        t=0;transform.position+=Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        t+=Time.deltaTime; if (t>=1) {t=0;desiredPos=transform.position+Random.insideUnitSphere*2;}
        transform.position=Vector3.Lerp(transform.position,desiredPos,t);
        
    }
}
