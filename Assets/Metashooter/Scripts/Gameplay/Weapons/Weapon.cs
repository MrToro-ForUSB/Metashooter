using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    // ———————— fields ————————

    public bool canShoot = true;
    public float shootRecoveryTime = 0.5f;
    [SerializeField] GameObject shot;
    [SerializeField] Transform muzzleTransform;

    public XRBaseController Controller { get; private set; }
    public UnityEvent OnShoot { get; private set; } = new();

    // ———————— unity methods ————————

    void Start()
    {
        Controller = transform.parent.GetComponent<XRBaseController>();
    }

    void Update()
    {
        if (Controller.activateInteractionState.activatedThisFrame)
        {
            TryShoot();    
        }
    }

    // ———————— weapon methods ————————
    void TryShoot()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        OnShoot?.Invoke();

        Instantiate(shot, muzzleTransform.position, Controller.transform.rotation);
        
        yield return new WaitForSeconds(shootRecoveryTime);
        
        canShoot = true;

    }
}
