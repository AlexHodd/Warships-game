using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public GameObject Fire, playerSmoke;
	public bool Dead = false;
	public float HealthbarLenght;
	private float counter, startTime;

	void Start()
	{
		CurrentHealth = MaxHealth;
		HealthbarLenght = Screen.width / 3;
		//startTime = Time.time;
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Bullet(Clone)" && !Dead)
		{
			ApplyDamage(10);
			isDead();
		}
		
		if ((col.gameObject.name == "Enemy(Clone)") && !Dead) 
		{
			ApplyDamage(20);
			isDead();
		}
	}

	void OnGUI()
	{
		if (!Dead) 
		{
			GUI.color = Color.green;
			GUI.Box (new Rect (((Screen.width / 3) + (MaxHealth/CurrentHealth)/Screen.width/3), (Screen.height - 30f), HealthbarLenght, 20), CurrentHealth + "/" + MaxHealth);
		}
	}


	void ApplyDamage(int damage)
	{
		//healthBarUI.GetComponent<Image> ().fillAmount -= (float)damage/100f;
		CurrentHealth -= damage;

		if (CurrentHealth < 0)
			CurrentHealth = 0;

		if (CurrentHealth > MaxHealth)
			CurrentHealth = MaxHealth;

		HealthbarLenght = (Screen.width / 3) * (CurrentHealth / (float)MaxHealth);
	}
	void isDead()
	{
		if (CurrentHealth <= 0) 
		{
			Quaternion newRot = transform.rotation;
			newRot.y -= 90f;
			Transform t = ((GameObject)Instantiate (Fire, transform.position, newRot)).transform;
			t.parent = transform;
			playerSmoke.SetActive(false);
			Dead = true;
		}
	}

	void Update(){
		if (Dead)
			counter += Time.deltaTime;
		if (counter > 3f)
			gameObject.audio.mute = true;
		//if ((Time.time - startTime) > 0.15f)
			//rigidbody.useGravity = true;
	}
}
