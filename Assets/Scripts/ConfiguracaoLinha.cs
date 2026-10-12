using TMPro;
using UnityEngine;

public class ConfiguracaoLinha
{
    public GameObject Linha { get; set; }
    
    public string Letra { get; set; }

    public bool LinhaPreenchida = false;

    public void PreenchaLetraLinha()
    {
        Linha.GetComponentInChildren<TextMeshProUGUI>().text = Letra;
        LinhaPreenchida = true;
    }
}