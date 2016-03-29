using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class autoAttack : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
    public Boundary boundary;
    public float tilt;
	public bool ranged = true;
	private float nextFire;
	private Transform player;

	void Start () {
		player = this.transform.parent;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire){
            //nextFire = Time.time + player.attackSpeed;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
	}

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        //GetComponent<Rigidbody>().velocity = movement * player.speedProject;
		GetComponent<Rigidbody>().velocity = movement * 1;

        GetComponent<Rigidbody>().position = new Vector3 
        (
            Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
            0.0f, 
            Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}
