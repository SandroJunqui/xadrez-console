namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }  // alteração  permitida somente pela subclasse
        public int qteMovimentos { get; protected set; }    // alteração  permitida somente pela subclasse
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }
        
        public void DecrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() // verifica se a peça nao esta bloqueada para movimentos
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < tab.Linhas; i++)
            {
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)  // metodo para verificar se a peça pode ser movida para o destino
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }


        public abstract bool[,] MovimentosPossiveis();  // a partir de uma peça quais os movimentos possiveis
    }
}
