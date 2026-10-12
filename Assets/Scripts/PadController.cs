using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PadController : MonoBehaviour
{
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
        CriePad();
    }

    void CriePad()
    {
        foreach (string letra in _letras)
        {
            GameObject letraInstance = Instantiate(LetrasPad, Pad.transform);
            letraInstance.GetComponentInChildren<TextMeshProUGUI>().text = letra;
            //letraInstance.GetComponent<Button>().onClick.AddListener(() => VerifiqueLetra(letraInstance, letra));
        }
    }
}