using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _imgBar;

    private void Awake()
    {
        _imgBar = GetComponent<Image>();
        GetComponentInParent<Character>().OnHpChanged += ChangeHealthBar;
    }

    private void ChangeHealthBar(int hpAmount, int maxHp)
    {
        _imgBar.fillAmount = 1f * hpAmount / maxHp;
    }
}
