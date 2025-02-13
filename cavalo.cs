public class Cavalo : Peca {
    public Cavalo(Cor cor, int linha, int coluna) : base(cor, linha, coluna) { }

    public override bool MovimentoValido(int novaLinha, int novaColuna) {
        int deltaLinha = Math.Abs(Linha - novaLinha);
        int deltaColuna = Math.Abs(Coluna - novaColuna);
        return (deltaLinha == 2 && deltaColuna == 1) || (deltaLinha == 1 && deltaColuna == 2);
    }
}
