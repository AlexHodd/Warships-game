using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public float SpawnRate;
	public int MaxEnemies;
	public GameObject enemy;
	private float counter;
	

	void Update () {
		if (counter > SpawnRate && GameObject.FindGameObjectsWithTag("Enemy").Length < MaxEnemies) {
			Instantiate(enemy, transform.position, transform.rotation);
			counter = 0;
		}
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length >= MaxEnemies)
			gameObject.SetActive (false);

		counter += Time.deltaTime;
	
	}
}
