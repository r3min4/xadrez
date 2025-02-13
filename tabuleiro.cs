public class Tabuleiro {
    public Peca[,] Pecas { get; set; }

    public Tabuleiro() {
        Pecas = new Peca[8, 8];
        InicializarPecas();
    }

    private void InicializarPecas() {
     
        Pecas[0, 0] = new Torre(Cor.Branco, 0, 0);
           Pecas[0, 7] = new Torre(Cor.Branco, 0, 7);
           Pecas[7, 0] = new Torre(Cor.Preto, 7, 0);
           Pecas[7, 7] = new Torre(Cor.Preto, 7, 7);

           Pecas[0, 2] = new Bispo(Cor.Branco, 0, 2);
        Pecas[0, 5] = new Bispo(Cor.Branco, 0, 5);
        Pecas[7, 2] = new Bispo(Cor.Preto, 7, 2);
        Pecas[7, 5] = new Bispo(Cor.Preto, 7, 5);

       
        Pecas[0, 1] = new Cavalo(Cor.Branco, 0, 1);
        Pecas[0, 6] = new Cavalo(Cor.Branco, 0, 6);
        Pecas[7, 1] = new Cavalo(Cor.Preto, 7, 1);
        Pecas[7, 6] = new Cavalo(Cor.Preto, 7, 6);

      
        Pecas[0, 3] = new Rainha(Cor.Branco, 0, 3);
        Pecas[7, 3] = new Rainha(Cor.Preto, 7, 3);

        
        Pecas[0, 4] = new Rei(Cor.Branco, 0, 4);
        Pecas[7, 4] = new Rei(Cor.Preto, 7, 4);

        
        for (int i = 0; i < 8; i++) {
            Pecas[1, i] = new Peao(Cor.Branco, 1, i);
            Pecas[6, i] = new Peao(Cor.Preto, 6, i);
        }
    
    
    }

    public bool MoverPeca(int linhaOrigem, int colunaOrigem, int linhaDestino, int colunaDestino) {
        Peca peca = Pecas[linhaOrigem, colunaOrigem];
        if (peca != null && peca.MovimentoValido(linhaDestino, colunaDestino)) {
            Pecas[linhaDestino, colunaDestino] = peca;
            Pecas[linhaOrigem, colunaOrigem] = null;
            peca.Linha = linhaDestino;
            peca.Coluna = colunaDestino;
            return true;
        }
        return false;
    }
}