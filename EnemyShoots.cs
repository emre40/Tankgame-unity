using UnityEngine;
using System.Collections;

public class EnemyShoots : MonoBehaviour {
	private float reloadTime;
	public  float timeToReload;
	public GameObject bulletPrefab;
	public float ShootingRange;
	private Transform turret;
	private Transform nozzle;
	// Use this for initialization
	void Start () {
		reloadTime = 0;

		Transform[] tranforms = this.gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in tranforms) 
		{
			print("ik vond "+ t.gameObject.name);
			if(t.gameObject.name == "turret")
			{
				turret = t;
			}
			if(t.gameObject.name == "nozzle")
			{
				print("nozzle gevonden");
				nozzle = t;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		reloadTime += Time.deltaTime;
		if (reloadTime >= timeToReload) 
		{
			CheckForPlayer();

		}
	}
	private void CheckForPlayer()
	{
		Ray myRay = new Ray ();
		myRay.origin = turret.position;
		myRay.direction = turret.forward;

		RaycastHit hitInfo;


		if (Physics.Raycast (myRay, out hitInfo, ShootingRange)) 
		{

			//print(hitInfo.collider.gameObject.name);
			string hitObjectName = hitInfo.collider.gameObject.name;

			if(hitObjectName == "Tank")
			{
			
				Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
			}
		}
	
	}
}
