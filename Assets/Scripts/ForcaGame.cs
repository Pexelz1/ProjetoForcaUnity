using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class ForcaGame : MonoBehaviour
{
    [SerializeField]
    GameObject Boneco;

    [SerializeField]
    TextMeshProUGUI Categoria;

    [SerializeField]
    BancoDePalavras BancoPalavras;

    [SerializeField]
    EnforcadoController EnforcadoController;

    [SerializeField]
    Modal Modal;

    [SerializeField]
    GameObject Dica;

    [SerializeField]
    GameObject PadController;

    [SerializeField]
    GameObject LinhasController;

    private Palavra _palavra;
    private string _palavraTexto;
    

    void Start()
    {
        _palavra = BancoPalavras.SorteiePorDificuldade(Configuracoes.Dificuldade);
        Categoria.text = _palavra.Categoria.Nome.ToUpper();
        _palavraTexto = _palavra.TextoMaiusculo;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Modal.ConjuntoModal.activeInHierarchy)
            {
                Modal.FecharModal();
            } else
            {
                Modal.AbrirModal(EstadoJogo.PAUSA);
            }   
        }
    }

    public void VerifiqueLetra(GameObject letraInstance, string letra)
    {
        List<ConfiguracaoLinha> configLinhasEncontradas = _configLinhas
            .Where(c => string.Compare(c.Letra, letra, System.StringComparison.OrdinalIgnoreCase) == 0).ToList();

        foreach (ConfiguracaoLinha configLinhaPreenchida in configLinhasEncontradas)
        {
            configLinhaPreenchida.PreenchaLetraLinha();
        }

        letraInstance.GetComponent<Button>().enabled = false;
        letraInstance.GetComponent<Image>().color = new Color32(116, 116, 116, 255);

        if (configLinhasEncontradas.Count() == 0)
        {
            VerifiqueDerrota();
            return;
        }

        VerifiqueVitoria();
    }

    public void VerifiqueVitoria()
    {
        if (_configLinhas.All(confL => confL.LinhaPreenchida))
        {
            OculteCampos();
            Modal.AbrirModal(EstadoJogo.VITORIA);
        }
    }

    public void VerifiqueDerrota()
    {
        bool restamVidas = EnforcadoController.DescontarVida();

        if (!restamVidas)
        {
            OculteCampos();
            Modal.AbrirModal(EstadoJogo.GAMEOVER);
        }
    }

    public void FornecaDica()
    {
        List<ConfiguracaoLinha> linhasNaoPreenchidas = _configLinhas.Where(configL => !configL.LinhaPreenchida).ToList();

        int linhaAleatoria = Random.Range(0, linhasNaoPreenchidas.Count);

        ConfiguracaoLinha linhaNaoPreenchidaAleatoria = linhasNaoPreenchidas[linhaAleatoria];

        linhaNaoPreenchidaAleatoria.PreenchaLetraLinha();

        VerifiqueVitoria();

        Dica.GetComponent<Button>().interactable = false;
    }

    private void OculteCampos()
    {
        PadController.GetComponent<PadController>().Pad.SetActive(false);
        LinhasController.GetComponent<LinhasController>().Caixa.SetActive(false);
        Boneco.SetActive(false);
        Dica.SetActive(false);
    }
}