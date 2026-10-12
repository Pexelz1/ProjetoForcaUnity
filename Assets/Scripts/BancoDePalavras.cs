using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Forca/Banco de Palavras")]
public class BancoDePalavras : ScriptableObject
{
    public List<Palavra> Palavras;

    public Palavra SorteiePorDificuldade(Dificuldade dificuldade)
    {
        List<Palavra> palavraJogadaPorDificuldade = PalavrasJogadas.ListaPalavrasJogadas
            .Where(pj => pj.Dificuldade == dificuldade).ToList();

        List<Palavra> palavrasPorDificuldade = Palavras.Where(p => p.Dificuldade == dificuldade
                                                && !string.IsNullOrEmpty(p.Texto)).ToList();

        if (palavraJogadaPorDificuldade.Count == palavrasPorDificuldade.Count)
        {
            PalavrasJogadas.ListaPalavrasJogadas.RemoveAll(pj => pj.Dificuldade == dificuldade);
            palavraJogadaPorDificuldade.RemoveAll(pj => pj.Dificuldade == dificuldade);
        }

        palavrasPorDificuldade.RemoveAll(p => palavraJogadaPorDificuldade.Any(pj => pj.TextoMaiusculo == p.TextoMaiusculo));

        int numeroRandom = Random.Range(0, palavrasPorDificuldade.Count());
        Palavra palavraAleatoria = palavrasPorDificuldade[numeroRandom];
        PalavrasJogadas.ListaPalavrasJogadas.Add(palavraAleatoria);

        return palavraAleatoria;
    }
}