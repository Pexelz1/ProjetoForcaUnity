using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PadController : MonoBehaviour
{
    public event Action<string> LetraClicada;

    [SerializeField]
    public GameObject Pad;

    [SerializeField]
    GameObject LetrasPad;

    private readonly List<string> _letras = new()
    {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
        "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
        "W", "X", "Y", "Z"
    };

    void Start()
    {
    }

    public void CriePad()
    {
        foreach (string letra in _letras)
        {
            GameObject letraInstance = Instantiate(LetrasPad, Pad.transform);
            letraInstance.GetComponentInChildren<TextMeshProUGUI>().text = letra;
            letraInstance.GetComponent<Button>().onClick.AddListener(() => AoClicarLetra(letraInstance, letra));
        }
    }

    public void AjusteBotaoLetraSelecionada(GameObject letraInstance)
    {
        letraInstance.GetComponent<Button>().enabled = false;
        letraInstance.GetComponent<Image>().color = new Color32(116, 116, 116, 255);
    }

    private void AoClicarLetra(GameObject letraInstance, string letra)
    {
        AjusteBotaoLetraSelecionada(letraInstance);
        LetraClicada?.Invoke(letra);
    }
}