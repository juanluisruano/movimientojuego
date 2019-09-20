using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movimiento Coche Principal clase Movimiento.
public class Movimiento : MonoBehaviour {

	Rigidbody2D rb;

	[SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;

	// Inicializar
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update, una vez por frame crea el movimiento 
	void FixedUpdate () {

		steeringAmount = - Input.GetAxis ("Horizontal");
		speed = Input.GetAxis ("Vertical") * accelerationPower;
		direction = Mathf.Sign(Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

		rb.AddRelativeForce (Vector2.up * speed);

		rb.AddRelativeForce ( - Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
			
	}


}