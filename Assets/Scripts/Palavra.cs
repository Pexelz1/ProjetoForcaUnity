using System;

[Serializable]
public class Palavra
{
    public string Texto;

    public string TextoMaiusculo => Texto.ToUpper();

    public Categoria Categoria;

    public Dificuldade Dificuldade;
}