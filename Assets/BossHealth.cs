using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
	public int health = 500;
	public Slider slider;
	public GameObject deathEffect;

	public bool isInvulnerable = false;

	void Start()
	{
		slider.maxValue = health;
	}

	// Update is called once per frame
	void Update()
	{
		slider.value = health;
	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
