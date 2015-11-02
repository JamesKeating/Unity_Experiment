using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	float speed = 10;
	
	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	}

	public void MoveProjectile(){
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	public void OnTriggerEnter(Collider obj){
		if (obj.gameObject.name == "Enemy") {
			Destroy(obj.gameObject);
		}
		Destroy(this.gameObject);
	}


	void Update () {
		MoveProjectile ();
	}
}