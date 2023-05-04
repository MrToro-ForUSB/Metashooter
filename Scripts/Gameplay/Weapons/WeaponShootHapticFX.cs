using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Weapon))]
public class WeaponShootHapticFX : MonoBehaviour
{
    Weapon weapon;

    [TitleGroup("Impulse values")] 
    [SerializeField] float amplitude = 1;
    [SerializeField] private float duration = 1;
    
    void Start()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnShoot.AddListener(SendImpulse);
    }

    void SendImpulse()
    {
        weapon.Controller.SendHapticImpulse(amplitude, duration);
    }

}
