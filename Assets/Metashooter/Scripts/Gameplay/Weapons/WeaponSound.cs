using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    private Weapon _weapon;
    private AudioSource _audioFX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _weapon = GetComponent<Weapon>();
        _audioFX = GetComponent<AudioSource>();
        _weapon.OnShoot.AddListener(PlaySound);
    }

    void PlaySound()
    {
        _audioFX.Play();
    }
}
