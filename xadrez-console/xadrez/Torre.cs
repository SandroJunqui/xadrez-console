using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        private bool PodeMover(Posicao pos) // mover a peça qdo a casa estiver libree até a peça adversária
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            while(tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto estiver vazia a casa até a peça adversaria ou final do tabuleiro
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)   // parar o while qdo econtrar final tabuleiro ou peça adversária
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            // Abaixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto estiver vazia a casa até a peça adversaria ou final do tabuleiro
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)   // parar o while qdo econtrar final tabuleiro ou peça adversária
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            // A direita
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto estiver vazia a casa até a peça adversaria ou final do tabuleiro
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)   // parar o while qdo econtrar final tabuleiro ou peça adversária
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            // Acima
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto estiver vazia a casa até a peça adversaria ou final do tabuleiro
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)   // parar o while qdo econtrar final tabuleiro ou peça adversária
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}