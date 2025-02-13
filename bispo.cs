public class Bispo : Peca{
    public Bispo(Cor cor, int linha, int coluna) : base(cor , linha , coluna){}

    public override bool MovimentoValido(int novaLinha, int novaColuna){
        return Math.Abs(Linha - novaLinha) == Math.Abs(Coluna - novaColuna);
    }
}