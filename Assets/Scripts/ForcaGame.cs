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
    PadController PadController;

    [SerializeField]
    LinhasController LinhasController;

    private Palavra _palavra;
    private string _palavraTexto;
    

    void Start()
    {
        _palavra = BancoPalavras.SorteiePorDificuldade(Configuracoes.Dificuldade);
        Categoria.text = _palavra.Categoria.Nome.ToUpper();
        _palavraTexto = _palavra.TextoMaiusculo;

        PadController.LetraClicada += VerifiqueLetra;

        LinhasController.CrieLinhasForca(_palavraTexto);
        PadController.CriePad();
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

    public void VerifiqueLetra(string letra)
    {
        bool letraEncontrada = LinhasController.Revele(letra);

        if (!letraEncontrada)
        {
            VerifiqueDerrota();
            return;
        }

        VerifiqueVitoria();
    }

    public void VerifiqueVitoria()
    {
        if (LinhasController.TodasPreenchidas())
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
        LinhasController.ReveleLinhaAleatoria();
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