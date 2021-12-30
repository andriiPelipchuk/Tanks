using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] int damage;
    [SerializeField] float shotDistance;

    private bool recharge = true;

    private Transform gun;

    private void Start()
    {
        gun = gameObject.transform.GetChild(0);
    }
    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (recharge)
        {
            var specificInstance = Instantiate(projectile, gun.position, transform.rotation);
            var projectileTransfer = specificInstance.GetComponent<Projectile>();
            projectileTransfer.DataTransfer(shotDistance, damage);
            recharge = false;
            StartCoroutine(Recharge());
            
        }
    }

    private IEnumerator Recharge()
    {
        yield return new WaitForSeconds(1f);
        recharge = true;
    }
}
