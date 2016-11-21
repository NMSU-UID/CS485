using UnityEngine;
using System.Collections;

public class GrassLooper : MonoBehaviour {

	public Material grassMaterial;

	private float loopSpeed = 1;

	// Use this for initialization
	void Start () {
		grassMaterial.SetTextureOffset ("_MainTex", Vector2.zero); 
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 newOffset = grassMaterial.GetTextureOffset("_MainTex");

		newOffset.y += loopSpeed * Time.deltaTime;

		grassMaterial.SetTextureOffset ("_MainTex", newOffset); 
	}
}
