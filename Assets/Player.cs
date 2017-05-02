using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int hitPoints = 1000;

    void TakeDamage(int damage)
    {
        hitPoints -= damage;
    }
}
