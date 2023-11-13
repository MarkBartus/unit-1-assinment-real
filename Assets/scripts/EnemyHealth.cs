using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image HealthBar1;
    public float HealthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HealthAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        HealthBar1.fillAmount = HealthAmount / 100f;
    }
}

