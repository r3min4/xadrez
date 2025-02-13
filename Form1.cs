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
                botao.Click += (sender, args) => Botao_Click(sender, args, linha, coluna);
                botao.Tag = new Point(linha, coluna);
                this.Controls.Add(botao); 
            }
        }
        AtualizarBotoes();
    }

    private void Botao_Click(object sender, EventArgs e, int linha, int coluna) {
        if (pecaSelecionada == null) {
            pecaSelecionada = tabuleiro.Pecas[linha, coluna];
        } else {
            bool movimentoValido = tabuleiro.MoverPeca(pecaSelecionada.Linha, pecaSelecionada.Coluna, linha, coluna);
            if (movimentoValido) {
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
                botao.Text = peca != null ? peca.GetType().Name[0].ToString() : "";
                botao.BackColor = ((posicao.X + posicao.Y) % 2 == 0) ? Color.Gray : Color.White;
            }
        }
    }
}
