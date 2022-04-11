using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public Slider healthUI;
	public int health = 100;
	public float flickerDuration = 0.1f;
	public float flickerTime = 0f;
	private SpriteRenderer spriteRenderer;
	public bool isImmune = false;
	public float immunityDuaration = 1.5f;
	public float immunityTime = 0f;
	public GameObject deathEffect;

	void Update()
	{
		healthUI.value = health;

		if (this.isImmune == true)
		{
			SpriteFlicker();
			immunityTime = immunityTime + Time.deltaTime;
			if (immunityTime >= immunityDuaration)
			{
				this.isImmune = false;
				this.spriteRenderer.enabled = true;
			}
		}

	}

	void SpriteFlicker()
	{
		if (this.flickerTime < this.flickerDuration)
		{
			this.flickerTime = this.flickerTime + Time.deltaTime;
		}
		else if (this.flickerTime >= this.flickerDuration)
		{
			spriteRenderer.enabled = !(spriteRenderer.enabled);
			this.flickerTime = 0;
		}

	}

	public void TakeDamage(int damage)
	{
		healthUI.value = health;

		health -= damage;

		StartCoroutine(DamageAnimation());

		if (health == 0)
		{
			Die();
		}
	}

	void Die()
	{
		(new nav()).gotogameover();
		Debug.Log("gameover");
		Destroy(this.gameObject);
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}
