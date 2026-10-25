using System.Collections.Generic;
using System.Linq;
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

    public void CrieLinhasForca(string palavra)
    {
        for (int i = 0; i < palavra.Length; i++)
        {
            GameObject linha = Instantiate(Linha, Caixa.transform);

            ConfiguracaoLinha configLinha = new()
            {
                Linha = linha,
                Letra = palavra[i].ToString()
            };

            _configLinhas.Add(configLinha);
        }
    }

    public bool Revele(string letra)
    {
        List<ConfiguracaoLinha> configLinhasEncontradas = _configLinhas
            .Where(c => string.Compare(c.Letra, letra, System.StringComparison.OrdinalIgnoreCase) == 0).ToList();

        foreach (ConfiguracaoLinha configLinhaPreenchida in configLinhasEncontradas)
        {
            configLinhaPreenchida.PreenchaLetraLinha();
        }

        return configLinhasEncontradas.Any();
    }

    public bool TodasPreenchidas () => _configLinhas.All(confL => confL.LinhaPreenchida);

    public void ReveleLinhaAleatoria()
    {
        List<ConfiguracaoLinha> linhasNaoPreenchidas = _configLinhas.Where(configL => !configL.LinhaPreenchida).ToList();

        int linhaAleatoria = Random.Range(0, linhasNaoPreenchidas.Count);

        ConfiguracaoLinha linhaNaoPreenchidaAleatoria = linhasNaoPreenchidas[linhaAleatoria];

        linhaNaoPreenchidaAleatoria.PreenchaLetraLinha();
    }
}
