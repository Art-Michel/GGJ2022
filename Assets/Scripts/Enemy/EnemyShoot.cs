using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class EnemyShoot : MonoBehaviour
{Vector3 desiredPos;
    Vector3 myPos;    float t;

    [SerializeField] GameObject player;
    [SerializeField]Pool myPool;
    Vector3 rand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t+=Time.deltaTime; 
        if (t>=1) 
        {
            t=0;
            rand= Random.insideUnitCircle*2;
            desiredPos=new Vector3(transform.position.x+rand.x,transform.position.y,transform.position.z+rand.y);
            Debug.Log(desiredPos);
            //desiredPos=Camera.main.WorldToScreenPoint(desiredPos);
        }
        Debug.Log(transform.TransformDirection(new Vector3(rand.x,0,rand.y)));
        transform.position=Vector3.Lerp(transform.position,desiredPos,t);
        
        
    }
    [Button]
    public void Shoot()
    {
        //bullet.SetActive(true);
        GameObject newBullet= myPool.Get();
        newBullet.SetActive(true);
        newBullet.transform.position=transform.position;
        newBullet.transform.LookAt(player.transform);
        newBullet.GetComponent<EnemyBullet>().SetTarget(player.transform.position,transform.position,myPool);
    }
}
