public class Rainha : Peca {
    public Rainha(Cor cor, int linha, int coluna) : base(cor, linha, coluna) { }

    public override bool MovimentoValido(int novaLinha, int novaColuna) {
        return (Linha == novaLinha || Coluna == novaColuna || Math.Abs(Linha - novaLinha) == Math.Abs(Coluna - novaColuna));
    }
}