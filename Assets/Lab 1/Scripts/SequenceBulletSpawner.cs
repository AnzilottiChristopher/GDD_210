using UnityEngine;

public class SequenceBulletSpawner : MonoBehaviour
{

    public SequenceBullets firstBullet;
    public float randomMinDelay = 1f;
    public float randomMaxDelay = 3f;
    private float timer;
    private bool readyToShoot = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetTimer();
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && readyToShoot)
        {
            readyToShoot = false;
            if (firstBullet != null)
            {
                firstBullet.Shoot();
            }

            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        timer = Random.Range(randomMinDelay, randomMaxDelay);
    }
    public void Shoot()
    {
        readyToShoot = true;
    }
}
