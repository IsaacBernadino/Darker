using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayerMoviments
{
	public class PlayerArchitecture : MonoBehaviour
	{

		public SkillsManager skills;
		Rigidbody2D rb;

		// Player Prefs
		public List<GameObject> itens = new List<GameObject>();

		public float maxSpeed;
		float move;
		bool _facingRight;

		float midSpeed; //Velocidade reduzida em 1.2
		float slowSpeed; //Velocidade reduzida em 2
		float verySlowSpeed; //Velocidade reduzida em 2.5
		float oldMaxSpeed; //Velocidade original antes das reduções

		[Header("Saúde e Estamina")]
		public float totalStamina = 300f;
		[HideInInspector]
		public float currentStamina;

		bool _decrenceStamina = true;
		public string stat = "";

		float perCent;

		[Header("Saúde e Estamina - UI")]
		public Slider sliderStamina;
		public Text percentTxt;

		[Header("Variaveis de Pulo")]
		public float maxJumpForce;
		public float radius = 0.45f;
		public LayerMask whatIsGround;
		public Transform groundCheck;
		private bool _isJumping;
		private bool _onTheFloor;

		[Header("UI")]
		public Text currentMaxSpeed;
		public Text textInfos;

		bool _isStatActivate;
		public GameObject panelStats;

		//temp
		public int attack;


		void Start()
		{
			rb = GetComponent<Rigidbody2D>();

			currentStamina = totalStamina;

			//Valores de velocidade
			oldMaxSpeed = maxSpeed;
			midSpeed = oldMaxSpeed / 1.2f;
			slowSpeed = oldMaxSpeed / 2f;
			verySlowSpeed = oldMaxSpeed / 2.2f;

			//
			_isStatActivate = false;
		}

		private void Update()
		{

			//Desativar itens pegos
			foreach (GameObject item in itens) {
				item.SetActive(false);
			}
			
			_onTheFloor = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

			if (Input.GetKeyDown(KeyCode.Space) && _onTheFloor)
			{
				_isJumping = true;
			}

			// STAMINA
			Stamina();
			StaminaEffects();

			// Update UI
			UI();

			// PANEL
			if (!_isStatActivate && Input.GetKeyDown(KeyCode.Tab))
			{
				_isStatActivate = true;
				panelStats.SetActive(true);
			} else if(_isStatActivate && Input.GetKeyUp(KeyCode.Tab))
			{
				panelStats.SetActive(false);
				_isStatActivate = false;
			}
		}

		void UI()
		{
			//Slider Stamina
			sliderStamina.value = (currentStamina) / totalStamina;
			perCent = sliderStamina.value * 100;
			percentTxt.text = Convert.ToInt32(perCent).ToString() + "%";

			//
			currentMaxSpeed.text = "Velocidade atual: " + Convert.ToInt32(maxSpeed).ToString();
			textInfos.text = stat;
		}

		void FixedUpdate()
		{
			move = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(move * maxSpeed * Time.deltaTime, rb.velocity.y);

			if (_isJumping) { Jump(); _isJumping = false; }

			if ((move < 0) && !_facingRight)
			{
				Flip();
			}
			else if ((move > 0) && _facingRight)
			{
				Flip();
			}
		}

		void Stamina () {

			if(_decrenceStamina)
			{
				if(currentStamina <= 0)
				{
					Die();
				} else
				{
					currentStamina -= Time.deltaTime;
				}
			}

			if(currentStamina > totalStamina)
			{
				currentStamina = totalStamina;
			}

		}

		void StaminaEffects()
		{
			if (perCent <= 100f && perCent >= 80f)
			{
				stat = "Otimo, todos os atributos estão em alta!";
				textInfos.color = Color.green;
				maxSpeed = oldMaxSpeed;
			}
			else if (perCent <= 80f && perCent >= 60f)
			{
				stat = "Bom, a velocidade ao caminhar reduziu em 1.2x.";
				textInfos.color = Color.white;
				maxSpeed = midSpeed;
			}
			else if (perCent <= 60f && perCent >= 40f)
			{
				stat = "Atenção, a velocidade ao caminhar reduziu em 2x";
				textInfos.color = Color.yellow;
				maxSpeed = slowSpeed;
			}
			else if (perCent <= 40f)
			{
				stat = "Ruim, a velocidade ao caminhar reduziu drasticamente em 2.2x";
				textInfos.color = Color.red;
				maxSpeed = verySlowSpeed;
			}
		}

		void Die ()
		{
			//TODO 
			//OBS * Não se morre no jogo, Pensar nisso

			Debug.Log("Morreu!?");

		}

		void Flip()
		{
			_facingRight = !_facingRight;

			if (_facingRight)
			{
				transform.eulerAngles = new Vector2(0, 180f);
			}
			else if (!_facingRight)
			{
				transform.eulerAngles = new Vector2(0, 0);
			}
		}

	public void Jump()
		{
			rb.AddForce(new Vector2(0, maxJumpForce));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("AppleSeed"))
		{
			currentStamina += (totalStamina / 2f);
			itens.Add(collision.gameObject);

			//ItensPickUp.Add(collision.gameObject);
			//foreach (GameObject Itens in ItensPickUp) {
			//	Debug.Log(Itens + " Adicionado e desativado");
			//

			//Destroy(collision.gameObject);
		}

		if(collision.gameObject.CompareTag("Ammo +15"))
		{
			SkillsManager.ammunition += 15;
			itens.Add(collision.gameObject);
		}

		if(collision.gameObject.CompareTag("Battery"))
		{
			LightManagement.currentIntencity += ((LightManagement.currentIntencity / LightManagement.intencity)) * LightManagement.multiplier ;
			itens.Add(collision.gameObject);
		}

		if(collision.gameObject.CompareTag("SaveStation")) {
			Save();
			Destroy(collision.gameObject);
		}
		/*
		if (collision.gameObject.CompareTag("BG Music"))
		{
			manager.PlayMusic();
			Destroy(collision.gameObject);
		}
		*/
	}

		/// <summary>
		/// Value determina a quantidade que o efeito passará, applyWhere é a variavel que controla aonde o efeito é aplicado.
		/// applyToOther - Quando verdadeiro, sinaliza que um efeito afeta outro.
		/// other - Mostra qual o efeito afetado.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="applyWhere"></param>
		/// <param name="applyToOther"></param>
		/// <param name="other"></param>
		public void ApplyCardEffect(float value, string applyWhere, float otherValue, string other, bool applyToOther)
		{
			Debug.Log(value + " | " + applyWhere + " | " + otherValue + " | " + other + " | " + applyToOther);

			if (applyWhere == "stamina")
			{
				totalStamina += value;
			}
			else if (applyWhere == "stamina%")
			{
				totalStamina += totalStamina * (otherValue / 100);
			}
			else if (applyWhere == "cooldown%")
			{
				skills.cooldown += skills.cooldown * (value / 100);
			}
			else if (applyWhere == "maxSpeed%")
			{
				oldMaxSpeed += oldMaxSpeed * (value / 100);
			}
			else if (applyWhere == "cooldown")
			{
				skills.cooldown += value;
			}
			else if (applyWhere == "maxSpeed")
			{
				oldMaxSpeed += value;
			}
			else if (applyWhere == "attack")
			{
				attack += System.Convert.ToInt32(value);
			}
			else if (applyWhere == "all")
			{
				attack += System.Convert.ToInt32(attack * (value / 100));
				oldMaxSpeed += oldMaxSpeed * (value / 100);
				//cooldownTime += cooldownTime * (value / 100);
				totalStamina += totalStamina * (value / 100);
			}

			if (applyToOther)
			{
				switch (other)
				{
					case "stamina":
						totalStamina += otherValue;
						break;
					case "stamina%":
						totalStamina += totalStamina * (otherValue / 100);
						break;
					case "cooldown%":
						skills.cooldown += skills.cooldown * (otherValue / 100);
						break;
					case "cooldown":
						skills.cooldown += otherValue;
						break;
					case "maxSpeed":
						oldMaxSpeed += otherValue;
						break;
					case "maxSpeed%":
						oldMaxSpeed += oldMaxSpeed * (otherValue / 100);
						break;
					case "attack":
						attack += System.Convert.ToInt32(otherValue);
						break;
					case "all":
						attack += System.Convert.ToInt32(attack * (otherValue / 100));
						oldMaxSpeed += oldMaxSpeed * (otherValue / 100);
						skills.cooldown += skills.cooldown * (otherValue / 100);
						totalStamina += totalStamina * (otherValue / 100);
						break;
				}
			}
			else
			{
				Debug.Log("Não afeta outros..");
			}

		}

		// SAVE SYSTEM
		public void Save (){
			SaveSystem.SavePlayer (this);
		}

		public void GetLoad (){
			PlayerData data = SaveSystem.LoadPlayer ();

			currentStamina = data.currentStamina;

			Vector3 position;
			position.x = data.position[0];
			position.y = data.position[1];
			position.z = data.position[2];
			transform.position = position;
		}
		//End of save system


		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(groundCheck.position, radius);
		}
	}
}