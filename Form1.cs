using System;
using System.Drawing;
using System.Windows.Forms;
namespace xadrez;

public partial class Form1 : Form {
    private Tabuleiro tabuleiro;
    private Peca pecaSelecionada;

    public Form1() {
        InitializeComponent();
        tabuleiro = new Tabuleiro();
        CriarGradeBotoes();
    }

    private void CriarGradeBotoes() {
        for (int linha = 0; linha < 8; linha++) {
            for (int coluna = 0; coluna < 8; coluna++) {
                Button botao = new Button();
                botao.Width = botao.Height = 50;
                botao.Location = new Point(coluna * 50, linha * 50);
                int x = linha, y = coluna;
                botao.Click += (sender, args) => Botao_Click(sender, args, x, y);
                botao.Tag = new Point(linha, coluna);
                this.Controls.Add(botao); 
            }
        }
        AtualizarBotoes();
    }

    private void Botao_Click(object sender, EventArgs e, int linha, int coluna) {
        if (pecaSelecionada == null) {
            pecaSelecionada = tabuleiro.Pecas[linha, coluna];
            if (pecaSelecionada != null && 
                ((turnoBranco && pecaSelecionada.Cor == Cor.Branco) ||
                (!turnoBranco && pecaSelecionada.Cor == Cor.Preto))) {
               
            } else {
                pecaSelecionada = null;
            }
        } else {
            if (tabuleiro.MoverPeca(pecaSelecionada.Linha, pecaSelecionada.Coluna, linha, coluna)) {
                turnoBranco = !turnoBranco;
                AtualizarBotoes();
                pecaSelecionada = null;
            } else {
                MessageBox.Show("Movimento inválido!");
            }
        }
    }

    private void AtualizarBotoes() {
        foreach (Control control in Controls) {
            if (control is Button botao) {
                Point posicao = (Point)botao.Tag;
                Peca peca = tabuleiro.Pecas[posicao.X, posicao.Y];
                botao.Text = peca != null ? peca.GetType().Name.Substring(0, 2) : ""; 
                botao.BackColor = ((posicao.X + posicao.Y) % 2 == 0) ? Color.White : Color.Gray;
            }
        }
    }
}


