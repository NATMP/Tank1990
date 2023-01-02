using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wall : MonoBehaviour
{
	public Tilemap wallTile;
	private Vector3 hitPosition=Vector3.zero;
    // Start is called before the first frame update
    void Start()
	{
		wallTile = GetComponent<Tilemap>();
	}

	// Update is called once per frame
	void Update()
	{
	   
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet") && this.tag=="Wall")
		{
			FindObjectOfType<AudioManager>().Play("WallExplode");
			hitPosition = Vector3.zero;
			collision.gameObject.SetActive(false);
			foreach(ContactPoint2D hit in collision.contacts)
			{
				hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
				hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
				wallTile.SetTile(wallTile.WorldToCell(hitPosition), null);
			}
		}
		if (collision.gameObject.CompareTag("EnemyBullet") && this.tag == "Wall")
		{
			FindObjectOfType<AudioManager>().Play("WallExplode");
			hitPosition = Vector3.zero;
			collision.gameObject.SetActive(false);
			foreach (ContactPoint2D hit in collision.contacts)
			{
				hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
				hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
				wallTile.SetTile(wallTile.WorldToCell(hitPosition), null);
			}
		}
	}
}
