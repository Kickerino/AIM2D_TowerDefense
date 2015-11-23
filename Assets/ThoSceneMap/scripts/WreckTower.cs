using UnityEngine;
using System.Collections;

public class WreckTower : MonoBehaviour {
    public GameObject bullet;
    private int ShootTimer = 100;
	
    void Update () {
        ShootTimer++;
        if (ShootTimer == 200) 
        {
            launchFireBall();
            ShootTimer = 0;
        }
	}
	
	
    void launchFireBall()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Instantiate(bullet, position, transform.rotation);
    }
}
