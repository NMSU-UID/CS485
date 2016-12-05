using UnityEngine;
using System.Collections;
using System;

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
        PlayerSettings playerSettings = GameObject.FindGameObjectWithTag( "PlayerSettings" ).GetComponent<PlayerSettings>();

        UnityEngine.Random.InitState( Convert.ToInt32( playerSettings.levelSeed ) );
	}
	
	// Update is called once per frame
	void Update() {
		timer -= Time.deltaTime;

		if( timer <= 0f && ringCounter < rings ) {

			ringCounter++;

			Instantiate( ringPrefab, transform.position + new Vector3( UnityEngine.Random.Range( positionMinX, positionMaxX), UnityEngine.Random.Range( positionMinY, positionMaxY) ), Quaternion.Euler( 0, 180, 0 ) );

			timer = spawnTime;
		}
	}
}
