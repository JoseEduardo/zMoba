using UnityEngine;
using System.Collections;

public class statusPlayer : MonoBehaviour {
	public float speedProject;
	public int hpCurr;
	public int hpMax;
	public int hpMaxByLevel;
	public int mpCurr;
	public int mpMax;
	public int mpMaxByLevel;
	public float dmgAttack;
	public float dmgAttackByLevel;
	public float dmgMagic;
	public float dmgMagicByLevel;
	public int defMagic;
	public int defMagicByLevel;
	public int defArm;
	public int defArmByLevel;
	public float attackSpeed;
	public float attackSpeedByLevel;
	public float moveSpeed;
	public float moveSpeedByLevel;
	public float level;
	public float experience;
	public Transform target;

	public bool stun = false;
	public float stunTime = 0;

	public bool slow = false;
	public float slowTime = 0;
	private float slowSpeedCurr = 0;

	public bool silence = false;
	public float silenceTime = 0;

	public bool burn = false;
	public float burnTime = 0;
	public Transform burdEffect;
	public int burnForce = 0;

	public bool poison = false;
	public float poisonTime = 0;
	public Transform poisonEffect;
	public int poisonForce = 0;

	// Update is called once per frame
	void Update () {
		//UP LEVEL
		if(experience >= 1000){
			level += 1;

			hpMax += hpMaxByLevel;
			mpMax += mpMaxByLevel;

			dmgAttack += dmgAttackByLevel;
			dmgMagic  += dmgMagicByLevel;
			defMagic  += defMagicByLevel;
			defArm    += defArmByLevel;
			attackSpeed  += attackSpeedByLevel;
			moveSpeed    += moveSpeedByLevel;
			experience = 0;
		}
	}

	public void inflictDamagePlayer(int damage, string tpDamage){
		if(tpDamage == "ATTK"){
			damage -= defArm;
		}else if(tpDamage == "MAGIC"){
			damage -= defMagic;
		}

		hpCurr -= damage;
		if(hpCurr <= 0){
			killPlayer();
		}
	}

	public void killPlayer(){
		hpCurr = hpMax;
		mpCurr += mpMax;

		//SHADER BLACK AND WHITE

		//TIME TO RESPAWN
	}

	//STUN
	public void doStunPlayer(float time){
		stun = true;
		stunTime = time;
	}

	public void cleanStunPlayer(){
		stun = false;
		stunTime = 0;
	}

	//SLOW
	public void doSlowPlayer(float time, float force){
		slow = true;
		slowTime = time;

		slowSpeedCurr = moveSpeed;
		moveSpeed -= force; 
	}

	public void cleanSlowPlayer(){
		slow = false;
		slowTime = 0;

		moveSpeed = slowSpeedCurr;
	}

	//BURN
	public void doBurnPlayer(float time, int force){
		burn = true;
		burnTime = time;

		burnForce = force;
	}

	void burnPlayer(){
		// controle de tempo
		//instancia o efeito
		inflictDamagePlayer(burnForce, "BURN");
	}

	public void cleanBurnPlayer(){
		burn = false;
		burnTime = 0;
	}

	//POISON
	public void doPoisonPlayer(float time, int force){
		poison = true;
		poisonTime = time;

		poisonForce = force;
	}

	void poisonPlayer(){
		// controle de tempo
		//instancia o efeito
		inflictDamagePlayer(poisonForce, "POISON");
	}

	public void cleanPoisonPlayer(){
		poison = false;
		poisonTime = 0;
	}

	//SILENCE
	public void doSilencePlayer(float time){
		silence = true;
		silenceTime = time;
	}

	public void cleanSilencePlayer(){
		silence = false;
		silenceTime = 0;
	}

	public void cleanAllCondition(){
		cleanPoisonPlayer();
		cleanSilencePlayer();
		cleanBurnPlayer();
		cleanSlowPlayer();
		cleanStunPlayer();
	}

}
