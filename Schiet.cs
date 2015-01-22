using UnityEngine;
using System.Collections;

public class Schiet : MonoBehaviour {
	public GameObject bulletPrefab;
    private GameObject turret;
    private GameObject nozzle;
	// Use this for initialization
	void Start () {
        Transform[] tranforms = GetComponentsInChildren<Transform>();
        foreach(Transform t in tranforms)
        {

			//print("ik vond "+ t.gameObject.name);
            if (t.gameObject.name == "turret")
            {
                turret = t.gameObject;
            }
            if(t.gameObject.name == "nozzle")
            {
                nozzle = t.gameObject;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Quaternion rotation = Quaternion.Euler(Vector3.up * turret.transform.rotation.eulerAngles.y);

            Instantiate(bulletPrefab, nozzle.transform.position, rotation);
        }
	
	}
}
