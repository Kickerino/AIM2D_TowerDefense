using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    Transform target;
    public float speed = 3f;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
    }

    void Update()
    {
       


        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }

}