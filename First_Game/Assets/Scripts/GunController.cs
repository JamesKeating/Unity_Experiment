using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
	
	public Transform weaponPosiition;
	public Gun startingGun;
	Gun equippedGun;
	float nextShotTime;
	
	void Start() {
		if (startingGun != null) {
			EquipGun(startingGun);
		}
	}
	
	public void EquipGun(Gun gunToEquip) {
		if (equippedGun != null) {
			Destroy(equippedGun.gameObject);
		}
		equippedGun = Instantiate (gunToEquip, weaponPosiition.position,weaponPosiition.rotation) as Gun;
		equippedGun.transform.parent = weaponPosiition;
	}
	
	public void Shoot() {

		if (equippedGun != null && Time.time > nextShotTime) {

			nextShotTime = Time.time + equippedGun.msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (equippedGun.projectile, equippedGun.muzzle.position, equippedGun.muzzle.rotation) as Projectile;
			newProjectile.SetSpeed(equippedGun.projectileSpeed);
		}
	}

	void Update(){
		if (Input.GetMouseButton (0))
			Shoot ();
	}

}