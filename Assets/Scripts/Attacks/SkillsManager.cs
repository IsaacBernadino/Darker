using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
	//Fire Rate
	[Header("Atributos de Ataque")]
	public float fireRate;
	float nextFire;
	public Transform attackPoint;
	public GameObject bullet;
	public static int ammunition = 15;
	public int maxAmmo;

	[Header("Habilidade #1 - Teletransporte")]
	public GameObject Indicator;
	float oldPosX;
	float oldPosY;

	public float timeToTeleport;
	float currentTimeForTeleport = 0;
	//Cooldown
	public Text cooldownText;
	public float cooldown;
	float currentCooldown = 0;
	bool _isCooldown = false;

	bool _teleport = true;
	bool _startCount;

	[Header("Habilidade #2 - Teletransporte")]
	public Light pointLight;
	public Image imgChangeColor;
	//Colors
	Color red = Color.red;
	Color green = Color.green;
	Color defult = Color.white;
	Color blue = Color.blue;
	Color black = Color.black;

	//Elementos na tela - UI
	[Header("Elementos de UI")]
	// Skill 1
	public Slider sliderTimePreview;
	public Slider sliderTime;
	public GameObject teleportTimeInfo;

	public Text ammunitionTxt;

	private void Start()
	{
		currentTimeForTeleport = 0;
		currentCooldown = 0;

		cooldown += timeToTeleport;

		teleportTimeInfo.SetActive(false);

		cooldownText.enabled = false;
	}

	private void Update()
	{
		//Atualiza os elementos na tela
		UIReflash();

		// Verifica o estado da munição
		AmmoCheck();

		// Logica para atirar balas
		Fire();

		//Habilidade numero 1
		SkillOne();	
		
		//Habilidade numero 2
		SwitchColors();

	}

	void UIReflash()
	{
		// Munição
		ammunitionTxt.text = ammunition.ToString();

		// slider skill 1
		sliderTimePreview.value = currentTimeForTeleport / timeToTeleport;
		// skill 1 cooldown
		sliderTime.value = (currentCooldown) / cooldown;
		cooldownText.text = Convert.ToInt32(currentCooldown).ToString();
	}

	void Fire ()
	{
		if (Input.GetMouseButton(0) && (Time.time > nextFire) && ammunition > 0)
		{
			nextFire = Time.time + fireRate;
			Instantiate(bullet, attackPoint.position, attackPoint.rotation);
			ammunition--;
		}
	}

	void SkillOne()
	{
		if(_isCooldown)
		{
			if (currentCooldown >= cooldown)
			{
				currentCooldown = 0;

				_isCooldown = false;
				cooldownText.enabled = false;
			}
			else
			{
				currentCooldown += Time.deltaTime;
			}
		}

		if (_startCount)
		{
			if (currentTimeForTeleport >= timeToTeleport)
			{
				currentTimeForTeleport = 0;
				Debug.Log("Back Again");

				this.transform.position = new Vector2(oldPosX, oldPosY);

				_teleport = true;
				_startCount = false;
				teleportTimeInfo.SetActive(false);
			}
			else
			{
				currentTimeForTeleport += Time.deltaTime;
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && _teleport && !_isCooldown)
		{
			_startCount = true;
			_isCooldown = true;

			teleportTimeInfo.SetActive(true);
			cooldownText.enabled = true;

			oldPosX = this.transform.position.x;
			oldPosY = this.transform.position.y;

			if (currentTimeForTeleport == 0)
			{
				Instantiate(Indicator, this.transform.position, this.transform.rotation);
			}
		}
	}

	//Skill two
	void SwitchColors ()
	{
		if(Input.GetKey(KeyCode.Alpha1))
		{
			pointLight.color = defult;
			imgChangeColor.color = defult;
		}else if(Input.GetKey(KeyCode.Alpha2))
		{
			pointLight.color = red;
			imgChangeColor.color = red;
		}
		else if(Input.GetKey(KeyCode.Alpha3))
		{
			pointLight.color = green;
			imgChangeColor.color = green;
		}else if(Input.GetKey(KeyCode.Alpha4))
		{
			pointLight.color = blue;
			imgChangeColor.color = blue;
		}
		else if(Input.GetKey(KeyCode.Alpha5))
		{
			pointLight.color = black;
			imgChangeColor.color = black;
		}
	}

	void AmmoCheck ()
	{
		if (ammunition >= maxAmmo) { ammunition = maxAmmo; }
	}

}
