using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float Speed = 10;
    [SerializeField] GameObject bulletPrefabs;
    List<GameObject> bullet_pool = new List<GameObject>();
    Coroutine ranVerDir,ranHorDir;
    int[] number = { -1, 1 };
    float direction;
    private void OnEnable()
    {
        ranVerDir = StartCoroutine(RandomVerDir());
        ranHorDir = StartCoroutine(RandomHorDir());
        StartCoroutine(Fire());
    }

    private void OnDisable()
    {
        StopCoroutine(RandomVerDir());
        StopCoroutine(RandomHorDir());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.up * Speed * Time.deltaTime;
    }

    IEnumerator RandomVerDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.8f);
            direction = 90 - (number[Random.Range(0, number.Length)] * 90);
            this.transform.rotation = Quaternion.Euler(0, 0, direction);
        }
    }
    IEnumerator RandomHorDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.8f);
            direction = number[Random.Range(0, number.Length)] * -90;
            this.transform.rotation = Quaternion.Euler(0, 0, direction);
        }
    }
    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            bool check = true;
            foreach (GameObject g in bullet_pool)
            {
                if (g.activeSelf)
                    continue;
                g.transform.rotation = Quaternion.Euler(0, 0, direction);
                g.transform.position = this.transform.position;

                g.SetActive(true);
                check = false;
                break;
            }
            if (check == true)
            {
                GameObject b = Instantiate(bulletPrefabs, this.transform.position, Quaternion.identity);
                b.transform.rotation = Quaternion.Euler(0, 0, direction);
                bullet_pool.Add(b);
            }
        }
    }
}
