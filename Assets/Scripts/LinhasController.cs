using System.Collections.Generic;
using UnityEngine;

public class LinhasController : MonoBehaviour
{
    [SerializeField]
    public GameObject Caixa;

    [SerializeField]
    GameObject Linha;

    private readonly List<ConfiguracaoLinha> _configLinhas = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void CrieLinhasForca()
    {
        for (int i = 0; i < _palavraTexto.Length; i++)
        {
            GameObject linha = Instantiate(Linha, Caixa.transform);

            ConfiguracaoLinha configLinha = new()
            {
                Linha = linha,
                Letra = _palavraTexto[i].ToString()
            };

            _configLinhas.Add(configLinha);
        }
    }
}
