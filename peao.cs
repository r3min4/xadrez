public class Peao : Peca {
    public Peao(Cor cor, int linha, int coluna) : base(cor, linha, coluna) { }

    public override bool MovimentoValido(int novaLinha, int novaColuna) {
        int deltaLinha = novaLinha - Linha;
        int deltaColuna = Math.Abs(novaColuna - Coluna);

        if (Cor == Cor.Branco) {
             
            if (Linha == 6 && deltaLinha == -2 && deltaColuna == 0 && Tabuleiro.Pecas[novaLinha, novaColuna] == null) {
                return true;
            }
       
            if (deltaLinha == -1 && deltaColuna == 0 && Tabuleiro.Pecas[novaLinha, novaColuna] == null) {
                return true;
            }
           
            if (deltaLinha == -1 && deltaColuna == 1 && Tabuleiro.Pecas[novaLinha, novaColuna] != null && Tabuleiro.Pecas[novaLinha, novaColuna].Cor != Cor) {
                return true;
            }
        } else {
           
            if (Linha == 1 && deltaLinha == 2 && deltaColuna == 0 && Tabuleiro.Pecas[novaLinha, novaColuna] == null) {
                return true;
            }
            
            if (deltaLinha == 1 && deltaColuna == 0 && Tabuleiro.Pecas[novaLinha, novaColuna] == null) {
                return true;
            }
            
            if (deltaLinha == 1 && deltaColuna == 1 && Tabuleiro.Pecas[novaLinha, novaColuna] != null && Tabuleiro.Pecas[novaLinha, novaColuna].Cor != Cor) {
                return true;
            }
        }
        return false;
    }
}