using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

	[SerializeField] GameObject prefabEnemy;
	public int countCreep = 0;
	public int enemyRemain = 10;
	List<GameObject> enemyPool = new List<GameObject>();
	[SerializeField] Transform[] spawnPoints;
	int spawnIndex;
    // Start is called before the first frame update
    void Start()
	{
		StartCoroutine(spawCreep());
	}

	// Update is called once per frame
	IEnumerator spawCreep()
	{
		while (true)
		{
			yield return new WaitForSeconds(3);
			spawnIndex = Random.Range(0, spawnPoints.Length);
			Vector2 spawnPos = spawnPoints[spawnIndex].position;
			bool Found = false;
			foreach (GameObject g in enemyPool)
			{
				if (g.activeSelf)
					continue;
				g.transform.position = spawnPos;
				if (countCreep > 2 || countCreep>=enemyRemain)
					continue;
				countCreep++;
				g.SetActive(true);
				Found = true;
				break;
			}
			if(Found)
			   continue;
			if (countCreep > 2 || countCreep>=enemyRemain)
				continue;
			enemyPool.Add(Instantiate(prefabEnemy, spawnPos, Quaternion.identity));
			countCreep++;
		}
	}
}
