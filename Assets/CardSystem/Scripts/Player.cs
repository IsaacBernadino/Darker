using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float stamina = 100;
    public int attack = 50;
    public float maxSpeed = 50;

    public float cooldownTime;
    float currentCooldown;
    bool _isCooldown;

    public Text cdText;

    private void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentCooldown = cooldownTime;
            _isCooldown = true;
        }


        if (_isCooldown)
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = cooldownTime;
                _isCooldown = false;
            }
            else
            {
                cdText.text = System.Convert.ToInt32(currentCooldown).ToString();
                currentCooldown -= Time.deltaTime;
            }
        }
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
    public void ApplyCardEffect (float value, string applyWhere, float otherValue, string other, bool applyToOther)
    {
        Debug.Log(value + " | " + applyWhere + " | " + otherValue + " | " + other + " | " + applyToOther);

        if(applyWhere == "stamina")
        {
            stamina += value;
        }else if (applyWhere == "stamina%")
        {
            stamina += stamina * (otherValue / 100);
        }
        else if (applyWhere == "cooldown%")
        {
            cooldownTime += cooldownTime * (value / 100);
        }
        else if (applyWhere == "maxSpeed%")
        {
            maxSpeed += maxSpeed * (value / 100);
        }
        else if (applyWhere == "cooldown")
        {
            cooldownTime += value;
        }
        else if (applyWhere == "maxSpeed")
        {
            maxSpeed += value;
        }
        else if (applyWhere == "attack")
        {
            attack += System.Convert.ToInt32(value);
        }
        else if (applyWhere == "all")
        {
            attack += System.Convert.ToInt32(attack * (value / 100));
            maxSpeed += maxSpeed * (value / 100);
            //cooldownTime += cooldownTime * (value / 100);
            stamina += stamina * (value / 100);
        }

        if (applyToOther)
        {
            switch (other)
            {
                case "stamina":
                    stamina += otherValue;
                    break;
                case "stamina%":
                    stamina += stamina * (otherValue / 100);
                    break;
                case "cooldown%":
                    cooldownTime += cooldownTime * (otherValue / 100);
                    break;
                case "cooldown":
                    cooldownTime += otherValue;
                    break;
                case "maxSpeed":
                    maxSpeed += otherValue;
                    break;
                case "maxSpeed%":
                    maxSpeed += maxSpeed * (otherValue / 100);
                    break;
                case "attack":
                    attack += System.Convert.ToInt32(otherValue);
                    break;
                case "all":
                    attack += System.Convert.ToInt32(attack * (otherValue / 100));
                    maxSpeed += maxSpeed * (otherValue / 100);
                    cooldownTime += cooldownTime * (otherValue / 100);
                    stamina += stamina * (otherValue / 100);
                    break;
            }
        }
        else
        {
            Debug.Log("Não afeta outros..");
        }

    }

}
