using UnityEngine;
using System.Collections;
using UnityEditor;



public enum ControlScheme{ JOYSTICK, MOUSE };

public class PlayerController : MonoBehaviour {
    
    public ControlScheme currentScheme;

	[Header( "Joystick" )]
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
            break;

        case ControlScheme.MOUSE:
            _input = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 5f ) ) - transform.position;

            if( _input.magnitude > 1f )
                _input.Normalize();
            break;
        default:
            break;
        }

        transform.Translate( _input * speed * Time.deltaTime );
	}
}
