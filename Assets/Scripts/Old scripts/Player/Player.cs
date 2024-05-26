using UnityEngine;

[RequireComponent (typeof(Inventory))]
public class Player : Character
{
    private Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _inventory.GetMoney(coin.PickUp());
        }

        if (collision.TryGetComponent<HealingRune>(out HealingRune aidKit))
        {
            TakeHeal(aidKit.PickUp());
        }
    }

    protected override void GetComponents()
    {
        base.GetComponents();
        _inventory = GetComponent<Inventory>();
    }

    private void TakeHeal(int amountOfHealth)
    {
        CurrentHealth = Mathf.Abs(amountOfHealth);
        ChangeHealth(amountOfHealth);
    }
}
