using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnItemPicked(player);
            gameObject.SetActive(false);
        }
    }

    protected abstract void OnItemPicked(Player player);
}
