using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharMovement : MonoBehaviour
{
	Rigidbody2D rb;
	float dirX;

	[SerializeField]
	float moveSpeed = 5f, jumpForce = 600f, bulletSpeed = 100f;

	[SerializeField] private LayerMask m_WhatIsGround;
	[SerializeField] private Transform m_GroundCheck;

	private PlayerMana_Manager PMM;

	bool facingRight = true;
	Vector3 localScale;

	private bool m_Grounded;
	const float k_GroundedRadius = .2f;

	public Transform barrel;
	public Rigidbody2D bullet;
	public Animator animator;

	public int manaToTake;

	public UnityEvent OnLandEvent;

	void Awake()
	{
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	void Start()
	{
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();

		PMM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana_Manager>();
	}

	void Update()
	{
		dirX = Input.GetAxis("Horizontal");

		animator.SetFloat("Speed", Mathf.Abs(dirX));

		if (Input.GetButtonDown("Jump"))
		{
			Jump();
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Fire1") && PMM.playerCurrentMana > 0)
		{
			Fire();
			animator.SetTrigger("Fire");
		}

		if (Input.GetButtonDown("Fire2"))
		{
			HandAttack();
			animator.SetTrigger("Attack");
		}
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void LateUpdate()
	{
		CheckWhereToFace();
	}

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else
			if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight)
			&& (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
	}

	void Jump()
	{
		if (rb.velocity.y == 0)
			rb.AddForce(Vector2.up * jumpForce);
	}

	void Fire()
	{
		PMM.TakeMana(manaToTake);
		var firedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
		firedBullet.AddForce(barrel.up * bulletSpeed);
	}

	void HandAttack()
    {

    }

	void NoAttack()
    {
		animator.ResetTrigger("Attack");
		animator.ResetTrigger("Fire");
    }
}