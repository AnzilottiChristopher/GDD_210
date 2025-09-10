using System;
using System.Numerics;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public float moveSpeed = 6f;
    public bool dir = true;


    public float bulletSpeed = 8f;
    public float minDelay = 1f;
    public float maxDelay = 3f;
    public float timer;
    public GameObject bulletPrefab;

    void Start()
    {
        ResetTimer();
    }


    // Update is called once per frame
    void Update()
    {
        CheckDir();
        SpawnerMovement();

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Shoot();
            ResetTimer();
        }

    }

    private void SpawnerMovement()
    {
        if (dir)
        {
            transform.Translate(UnityEngine.Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (!dir)
        {
            transform.Translate(UnityEngine.Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    private void CheckDir()
    {
        if (transform.position.z >= 7 || transform.position.z <= -7)
        {
            dir = !dir;
        }
    }

    private void ResetTimer()
    {
        timer = UnityEngine.Random.Range(minDelay, maxDelay);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, UnityEngine.Quaternion.identity);
        BulletMovement bm = bullet.AddComponent<BulletMovement>();
        bm.speed = bulletSpeed;


        if (transform.position.x < 0)
        {
            bm.direction = UnityEngine.Vector3.right;
        }
        else
        {
            bm.direction = UnityEngine.Vector3.left;
        }
    }
}
