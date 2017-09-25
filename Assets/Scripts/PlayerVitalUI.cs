using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerVitalUI : MonoBehaviour {

    public Slider HealthSlider;
    public int MaxHealth;
    public int HealthFallRate;

    public Slider StaminaSlider;
    public int MaxStamina;
    private int StaminaFallRate;
    public int StaminaFallMult;
    private int StaminaRegainRate;
    public int StaminaRegainMult;
    

    public Slider HungerSlider;
    public int MaxHunger;
    public int HungerFallRate;

    private CharacterController CharControler;
    private FirstPersonController PlayerControler;

    private void Start()
    {
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = MaxHealth;

        StaminaSlider.maxValue = MaxStamina;
        StaminaSlider.value = MaxStamina;
        StaminaFallRate = 1;
        StaminaRegainRate = 1;

        HungerSlider.maxValue = MaxHunger;
        HungerSlider.value = MaxHunger;

        PlayerControler = GetComponent<FirstPersonController>();
        CharControler = GetComponent<CharacterController>();


    }

    private void Update()
    {
        //Health 
        if (HungerSlider.value <= 0)
        {
            HealthSlider.value -= Time.deltaTime / HealthFallRate;
        }

        if (HealthSlider.value <= 0)
        {
            Death();
        }

        //Hunger
        if (HungerSlider.value >= 0)
        {
            HungerSlider.value -= Time.deltaTime / HungerFallRate;
        }
        else if (HungerSlider.value < 0)
        {
            HungerSlider.value = 0;
        }
        else if (HungerSlider.value > MaxHunger)
        {
            HungerSlider.value = MaxHunger;
        }

        //Stamina
        if (CharControler.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            StaminaSlider.value -= Time.deltaTime / StaminaFallRate * StaminaFallMult;
        }
        else
        {
            StaminaSlider.value += Time.deltaTime / StaminaRegainRate * StaminaRegainMult;
        }
        if (StaminaSlider.value >= MaxStamina)
        {
            StaminaSlider.value = MaxStamina;
        }
        else if (StaminaSlider.value <= 0)
        {
            StaminaSlider.value = 0;
            PlayerControler.m_RunSpeed = PlayerControler.m_WalkSpeed;
        }
        else if (StaminaSlider.value >= 0)
        {
            PlayerControler.m_RunSpeed = PlayerControler.m_RunSpeedNorm;
        }
    }

    void Death()
    {

    }



}
