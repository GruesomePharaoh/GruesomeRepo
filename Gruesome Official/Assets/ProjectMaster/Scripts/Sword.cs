﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour,  IWeapon {
	private Animator animator;
	public List<BaseStat> Stats { get; set; }

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	public void PerformAttack()
	{
		animator.SetTrigger ("Base_Attack");
	}

	public void PerformSpecialAttack()
	{
		animator.SetTrigger ("Special_Attack");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy")
		{
			//col.GetComponent<IEnemy>().TakeDamage (Stats[0].GetCalculatedStatValue());
			Destroy(col.gameObject);
		}
	}

}
