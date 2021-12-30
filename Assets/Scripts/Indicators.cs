using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int armor;
    
    private void Update()
    {
        if(hp <= 0 && armor <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            if (armor <= 0)
                hp -= 1;
            armor -= 1;
        }
    }
}
