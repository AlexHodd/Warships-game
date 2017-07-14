using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public float HealthbarLenght;
	public GameObject enemyFire;
	public bool Dead = false;
	private float DeadTimer;


	void Start () {
		CurrentHealth = MaxHealth;
		HealthbarLenght = Screen.width / 20;	
	}

	void OnGUI()
	{
		if (!Dead && gameObject.renderer.isVisible) 
		{
			Vector2 targetPos;
			targetPos = Camera.main.WorldToScreenPoint (transform.position);
			GUI.Box (new Rect (targetPos.x - 50f , Screen.height - targetPos.y - 100f, HealthbarLenght, 10), CurrentHealth + "/" + MaxHealth);

		
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Bullet(Clone)" && !Dead){
			ApplyDamage(10);
			isDead();
		}
		
		if ((col.gameObject.name == "Enemy(Clone)" || col.gameObject.name == "Player")&& !Dead) {
			ApplyDamage(20);;
			isDead();
		}
	}

	void ApplyDamage(int damage)
	{
		CurrentHealth -= damage;
		
		if (CurrentHealth < 0)
			CurrentHealth = 0;
		
		if (CurrentHealth > MaxHealth)
			CurrentHealth = MaxHealth;
		
		HealthbarLenght = (Screen.width / 20) * (CurrentHealth / (float)MaxHealth);		
	}
	
	void isDead()
	{
		if (CurrentHealth <= 0)
		{
			Transform t = ((GameObject)Instantiate (enemyFire, transform.position, transform.rotation)).transform;
			t.parent = transform;
			Dead = true;
		}
	}
	void Update(){
		if (Dead)
			DeadTimer += Time.deltaTime;
		if (DeadTimer > 8f) {
			collider.enabled = false;
		}
		if (DeadTimer > 12f)
			Destroy (gameObject);
	}
}