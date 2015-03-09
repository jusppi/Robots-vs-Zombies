using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError("No firepoint");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetKeyDown ("x")) {
				Shoot ();
			}
		} else {
			if(Input.GetKey("x") && Time.time > timeToFire){
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}

	void Shoot(){
		Vector3 firePointPosition = new Vector3 (firePoint.position.x, firePoint.position.y, firePoint.position.z);
		Vector3 fireDirectionPosition = new Vector3 (firePoint.position.x*GameData.playerDirection*2000, firePoint.position.y, firePoint.position.z);
		//RaycastHit hit = Physics.Raycast (firePointPosition, fireDirectionPosition - firePointPosition, 1, whatToHit);
		//Debug.Log ("shoooot");
		RaycastHit hit;
		if (Physics.Raycast(firePointPosition, (fireDirectionPosition - firePointPosition)*2000, out hit))
		{
			Collider target = hit.collider; // What did I hit?
			float distance = hit.distance; // How far out?
			Vector3 location = hit.point; // Where did I make impact?
			GameObject targetGameObject = hit.collider.gameObject; // What's the GameObject?
			Debug.DrawRay(firePointPosition, hit.point, Color.red);
			Debug.Log ("You hit "+target);
		}
	}
}
