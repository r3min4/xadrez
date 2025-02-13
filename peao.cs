public class Peao : Peca {
    public Peao(Cor cor, int linha, int coluna) : base(cor, linha, coluna) { }

    public override bool MovimentoValido(int novaLinha, int novaColuna) {
        
        return true; 
    }
}