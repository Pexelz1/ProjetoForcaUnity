using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject BotoesIniciais;

    [SerializeField]
    GameObject BotoesDificuldade;
    
    //Criar modal que pergunta se deseja realmente sair, é boa prática.
    public void SaiaParaAreaTrabalho()
    {
        Application.Quit();
    }

    public void AbraSelecaoDificuldade()
    {
        BotoesIniciais.SetActive(false);
        BotoesDificuldade.SetActive(true);
    }

    public void EscolhaDificuldade(int dificuldade)
    {
        Configuracoes.Dificuldade = (Dificuldade)dificuldade;
        InicieJogo();
    }

    public void InicieJogo()
    {
        SceneManager.LoadScene("Forca");
    }
}
