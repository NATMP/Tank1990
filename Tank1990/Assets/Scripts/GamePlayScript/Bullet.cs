using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    Coroutine deactive_routine;
    float Speed = 10f;
    private Animator enemyAnim;

    // Start is called before the first frame update

    private void OnEnable()
    {
        deactive_routine = StartCoroutine(Deactive2(2f));
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
        if (collision.gameObject.tag == "Enemy")
        {
            //enemyAnim = FindObjectOfType<EnemyController>().GetComponent<Animator>();
            //enemyAnim.SetBool("IsDead", true);
            FindObjectOfType<AudioManager>().Play("EnemyExplode");
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().score += 100;
            FindObjectOfType<EnemyManager>().countCreep--;
            int a = --FindObjectOfType<EnemyManager>().enemyRemain;
            if (a == 0)
            {
                FindObjectOfType<WinMenu>().SetActive();
                FindObjectOfType<WinMenu>().Pause();
                FindObjectOfType<Player_Movement>().enabled = false;
            }
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "Bound")
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
