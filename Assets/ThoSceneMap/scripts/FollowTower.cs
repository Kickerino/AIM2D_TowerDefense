using UnityEngine;
using System.Collections;

public class FollowTower : MonoBehaviour {
     
         public Transform target;
         public float speed = 3f;
         public float fireRate;
         public float fireBallHeight;
         public GameObject bullet;
         public float range;
         float distance;
         private float _lastShotTime = float.MinValue;
     
         void Start () {
         }
     
         void Update(){
             
             transform.LookAt(target.position);
             transform.Rotate(new Vector3(0,-90,0),Space.Self);
             
             distance = Vector2.Distance(transform.position,target.position);
         
         if(distance < range)
         {
             if (distance < range && Time.time > _lastShotTime + (3f / fireRate))
             {
                 _lastShotTime = Time.time;
                 launchFireBall();
             }
         }    
     }
         void launchFireBall()
         {
             Vector2 position = new Vector2(transform.position.x, transform.position.y);
             Instantiate(bullet, position, transform.rotation);
         }
             
             }
     
     
