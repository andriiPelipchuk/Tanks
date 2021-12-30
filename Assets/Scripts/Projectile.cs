using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float shotDistance;
    private Vector3 startPosition;
    private int damage;
    private int speed = 5;

    private void OnEnable()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > shotDistance) 
        {
            Destroy(gameObject);
        }
        transform.position = transform.position + -transform.right * speed * Time.deltaTime;
    }
    public void DataTransfer(float distance, int transferDamage)
    {
        shotDistance = distance;
        damage = transferDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
