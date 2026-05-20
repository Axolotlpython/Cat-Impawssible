using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yarnshoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public UnityEngine.Transform _bulletSpawnPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation );
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_bulletSpawnPoint.right * 1000);
        }
    }
}
