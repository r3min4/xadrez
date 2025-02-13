public enum Cor{Preto, Branco}

public abstract class Peca {
    public Cor Cor {get; set;}
    public int Linha {get;set;}
    public int Coluna {get;set;}

    public Peca(Cor cor, int linha, int coluna){
        Cor = cor ;
        Linha = linha;
        Coluna = coluna;
    }

    public abstract bool MovimentoValido(int novaLinha, int novaColuna);
}