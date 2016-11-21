using UnityEngine;
using System.Collections;

public class RingSpawner : MonoBehaviour {

	public GameObject ringPrefab;

	public int rings;

	public int ringCounter;

	public float spawnTime;

	public float timer;

	public float positionMinX;
	public float positionMaxX;

	public float positionMinY;
	public float positionMaxY;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		timer -= Time.deltaTime;

		if( timer <= 0f && ringCounter < rings ) {

			ringCounter++;

			Instantiate( ringPrefab, transform.position + new Vector3( Random.Range( positionMinX, positionMaxX), Random.Range( positionMinY, positionMaxY) ), Quaternion.Euler( 0, 180, 0 ) );

			timer = spawnTime;
		}
	}
}
