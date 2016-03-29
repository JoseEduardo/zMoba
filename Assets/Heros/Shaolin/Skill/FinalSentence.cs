using UnityEngine;
using System.Collections;

//SKILL FOR Q
public class FinalSentence : MonoBehaviour {
    public float cooldown = 105;
	private float nextFire;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextFire){
            nextFire = Time.time + cooldown;

            //fazer a skill
        }
	}

}
