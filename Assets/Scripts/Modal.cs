using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modal : MonoBehaviour
{
    [SerializeField]
    public GameObject ConjuntoModal;

    [SerializeField]
    GameObject BotaoReiniciar;

    [SerializeField]
    GameObject BotaoSair; 

    [SerializeField]
    TextMeshProUGUI Estado;

    private bool _podeFecharModal;

    public void AbrirModal(EstadoJogo estado)
    {
        EstadoModal estadoModal = ObtenhaEstadoModal(estado);

        ConjuntoModal.SetActive(true);
        _podeFecharModal = estadoModal.PodeFechar;

        if (!_podeFecharModal)
        {
            BotaoReiniciar.GetComponentInChildren<TextMeshProUGUI>().text = "JOGAR NOVAMENTE";
        }

        Estado.text = estadoModal.Titulo;
    }

    public void FecharModal()
    {
        if (_podeFecharModal)
        {
            ConjuntoModal.SetActive(false);
        }
    }

    public EstadoModal ObtenhaEstadoModal(EstadoJogo estado)
    {
        return estado switch
        {
            EstadoJogo.PAUSA => new EstadoModal() { Titulo = "PAUSA", PodeFechar = true },
            EstadoJogo.GAMEOVER => new EstadoModal() { Titulo = "GAME OVER", PodeFechar = false },
            EstadoJogo.VITORIA => new EstadoModal() { Titulo = "VOCÊ GANHOU", PodeFechar = false },
            _ => throw new ArgumentOutOfRangeException(nameof(estado))
        };
    }


    public void SairMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Forca");
    }
}

public class EstadoModal
{
    public string Titulo;
    public bool PodeFechar;
}