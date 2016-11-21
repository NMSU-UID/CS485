using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ControlScheme{ JOYSTICK, MOUSE };

public class PlayerController : MonoBehaviour {
    
	public Text scoreText;

	public int score;

	public Rigidbody myRig;

    public ControlScheme currentScheme;

	public Vector2 currentRotation;

	private float rotationSpeed = 120f;

	[Header( "Joystick" )]
	public int inversion;

	public float deadZone;
	public float maxThreshold;

    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 _input = new Vector3();

        switch (currentScheme) {
		case ControlScheme.JOYSTICK:
			_input.x = Input.GetAxisRaw("Horizontal");
			_input.y = Input.GetAxisRaw("Vertical");

			if (Mathf.Abs (_input.x) <= deadZone)
				_input.x = 0f;
			else if (Mathf.Abs (_input.x) >= maxThreshold)
				_input.x = (_input.x > 0 ? 1f : -1f);
			
			if (Mathf.Abs (_input.y) <= deadZone)
				_input.y = 0f;
			else if (Mathf.Abs (_input.y) >= maxThreshold)
				_input.y = (_input.y > 0 ? 1f : -1f);

			_input.y *= inversion;
            break;

        case ControlScheme.MOUSE:
            _input = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 5f ) ) - transform.position;

            if( _input.magnitude > 1f )
                _input.Normalize();
            break;
        default:
            break;
        }

		myRig.MovePosition( transform.position + _input * speed * Time.deltaTime );

		/*if ( !(Mathf.Abs(currentRotation.x - (-_input.y * 25f)) < rotationSpeed/2f * Time.deltaTime) )
		if (currentRotation.x < -_input.y * 25f )
			currentRotation.x += rotationSpeed * Time.deltaTime;
		else if (currentRotation.x > -_input.y * 25f)
			currentRotation.x -= rotationSpeed * Time.deltaTime;



		if ( !(Mathf.Abs(currentRotation.y - _input.x * 30f) < rotationSpeed/2f * Time.deltaTime) )
		if (currentRotation.y < _input.x * 30f)
			currentRotation.y += rotationSpeed * Time.deltaTime;
		else if (currentRotation.y > _input.x * 30f)
			currentRotation.y -= rotationSpeed * Time.deltaTime;*/

		transform.localRotation = Quaternion.Euler( new Vector3( -_input.y * 15, _input.x  * 25, 0f ) ); 
	}

	void OnTriggerEnter( Collider col ) {
		if (col.tag == "Ring") {
			Ring ring = col.GetComponent<Ring>();

			ring.collected = true;

			score++;

			scoreText.text = "Score: " + score.ToString ();;
		}
	}
}
