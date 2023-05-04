using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public enum ProjectileType
{
    Blaster,
    Shotgun
}

public class ProjectileShrink : MonoBehaviour
{
    [SerializeField] float shrinkSpeed = 3;
    
    public void PlaySparks(ProjectileType currentProjectile)
    {
        string PATH = "";
        
        switch (currentProjectile)
        {
            case ProjectileType.Blaster:
                PATH = "Prefabs/VFX_BlasterCollision";
                break;
            
            case ProjectileType.Shotgun:
                PATH = "Prefabs/VFX_ShotgunCollision";
                break;
        }
        
        GameObject sparksPrefab = Resources.Load<GameObject>(PATH);
        GameObject sparks = Instantiate(sparksPrefab, transform.position, Quaternion.identity);
        Destroy(sparks, 3);
    }
    
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * shrinkSpeed);
        
        if(transform.localScale.magnitude < 0.05f)
        {
            Destroy(gameObject);
        }
    }
}
