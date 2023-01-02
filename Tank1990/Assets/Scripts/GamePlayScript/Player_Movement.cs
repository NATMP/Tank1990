using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed=5f;
    private Animator anim;
    [SerializeField] GameObject bulletPrefabs;
    private float direction;
    private bool canFire = true;
    List<GameObject> bullet_pool = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }
    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(h != 0)
        {
            direction = h * -90;
            transform.position += new Vector3(h*speed*Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, direction);
            anim.SetBool("IsMoving", true);
        }
        else if (v != 0)
        {
            direction = 90 - 90 * v;
            transform.position +=new Vector3(0, v * speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, direction);
            anim.SetBool("IsMoving", true);
        }
        else if (h == 0 && v == 0)
        {
            anim.SetBool("IsMoving", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sand")
        {
            speed /= 2;
        }
        else
        {
            speed = 5f;
        }
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFire == true)
        {
            FindObjectOfType<AudioManager>().Play("FireSound");
            foreach (GameObject g in bullet_pool)
            {
                if (g.activeSelf)
                    continue;
                g.transform.rotation = Quaternion.Euler(0, 0,direction);
                g.transform.position = this.transform.position;

                g.SetActive(true);
                canFire = false;
                StartCoroutine(DelayFire());
                return;
            }
            GameObject b = Instantiate(bulletPrefabs, this.transform.position, Quaternion.identity);
            b.transform.rotation = Quaternion.Euler(0, 0, direction);
            canFire = false;
            StartCoroutine(DelayFire());
            bullet_pool.Add(b);
        }
    }
    private IEnumerator DelayFire()
    {
        yield return new WaitForSeconds(0.5f);
        canFire = true;
    }
}
