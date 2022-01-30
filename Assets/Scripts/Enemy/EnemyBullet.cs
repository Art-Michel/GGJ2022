using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 target;
    float t;
    Vector3 origPos;
    Pool origin;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable() {
        t=0;
        origPos=transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        t=Mathf.Min( t+Time.deltaTime,1.5f);
        transform.position=Vector3.LerpUnclamped(origPos,target,t);
        if (t==1.5f)
        {
            origin.Back(gameObject);
            gameObject.SetActive(false);
        }
    }
    public void SetTarget(Vector3 newTarget, Vector3 newOrig,Pool myPool)
    {
        origPos=newOrig;
        target=newTarget;
        origin=myPool;
    }

}
