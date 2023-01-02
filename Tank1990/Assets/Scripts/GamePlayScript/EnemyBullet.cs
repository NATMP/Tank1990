using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Coroutine deactive_routine;
    float Speed = 10f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        deactive_routine = StartCoroutine(Deactive2(1.5f));
    }
    private void OnDisable()
    {
        StopCoroutine(deactive_routine);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.up * Speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            FindObjectOfType<LoseMenu>().SetActive();
            FindObjectOfType<LoseMenu>().Pause();
            FindObjectOfType<EnemyController>().enabled = false;
            FindObjectOfType<Player_Movement>().enabled = false;
        }
        if (collision.gameObject.tag == "Bound")
        {
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator Deactive2(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
