namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public  int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)   // sobrecarga
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        
        public bool ExistePeca(Posicao pos) // verifica se existe uma peça na posição
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.Linha, pos.Coluna] = p;   // coloca a peça na matriz
            p.posicao = pos;    // agora a peça esta na posição pos
        }

        public bool PosicaoValida(Posicao pos)  // retorna se a posição é válida ou não
        {
            if(pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)  // validar uma posição e retorna uma excessão
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
