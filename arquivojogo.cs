public class ArquivoJogo {
public void SalvarEstado(Tabuleiro tabuleiro, string caminhoArquivo) {
    using (StreamWriter writer = new StreamWriter(caminhoArquivo)) {
    for (int linha = 0; linha < 8; linha++) {
     for (int coluna = 0; coluna < 8; coluna++) {
        Peca peca = tabuleiro.Pecas[linha, coluna];
        if (peca != null) {
    writer.WriteLine($"{peca.GetType().Name},{peca.Cor},{peca.Linha},{peca.Coluna}");
         }
}
 }
 }
}

    public Tabuleiro CarregarEstado(string caminhoArquivo) {
    Tabuleiro tabuleiro = new Tabuleiro();
    using (StreamReader reader = new StreamReader(caminhoArquivo)) {
    string linha;
    while ((linha = reader.ReadLine()) != null) {
                string[] partes = linha.Split(',');
                string tipo = partes[0];
                Cor cor = (Cor)Enum.Parse(typeof(Cor), partes[1]);
                int linhaPeca = int.Parse(partes[2]);
                int colunaPeca = int.Parse(partes[3]);

    Peca peca;
    switch (tipo) {
    case "Torre":
       peca = new Torre(cor, linhaPeca, colunaPeca);
       break;
                   
    default:
    throw new Exception("Tipo de peça desconhecido");
}

  tabuleiro.Pecas[linhaPeca, colunaPeca] = peca;
}
}
    return tabuleiro;
}
}