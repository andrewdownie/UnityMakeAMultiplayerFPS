using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;


    void Awake()
    {
        SetDefaults();
    }

    public void TakeDamage(int _amount)
    {
        currentHealth -= _amount;

        if(currentHealth > 0)
        {
            Debug.Log(transform.name + " now has " + currentHealth + " health");
        }
        else
        {
            Debug.Log(transform.name + " now has " + currentHealth + " health, and should be dead");
        }
        
    }
    

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}
