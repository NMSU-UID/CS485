using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {

	public Transform particleTransform;

	public ParticleSystem particleSystem;

	public float lifeTime;

	public float moveSpeed;

	[Header("Collected Variables:")]
	public Color collectedColor;

	public float openSpeed;

	public bool collected;

	public float particleDecay;

	// Use this for initialization
	void Start () {
		StartCoroutine ("LifeTimerCoroutine");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ( Vector3.forward * moveSpeed * Time.deltaTime );

		if (collected) {
			particleSystem.startColor = collectedColor;

			/*float rate = particleSystem.emission.rate.constant;
			rate -= particleDecay;

			ParticleSystem.MinMaxCurve mmCurve = new ParticleSystem.MinMaxCurve (rate, rate);

			particleSystem.emission.rate = mmCurve;*/


			Vector3 newScale = particleTransform.localScale;
			newScale.x += openSpeed * Time.deltaTime;
			newScale.y += openSpeed * Time.deltaTime;

			particleTransform.localScale = newScale;
		}
	}

	public IEnumerator LifeTimerCoroutine()
	{
		yield return new WaitForSeconds (lifeTime);

		Destroy (this.gameObject);
	}
}
