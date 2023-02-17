using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private Tank _model;
    public void Inin(string name, Sprite icon)
    {
        _icon.sprite = icon;
        _name.text = name;
    }
}
