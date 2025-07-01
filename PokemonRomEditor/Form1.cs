namespace PokemonRomEditor
{
    using System.IO;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Metodo executado ao clicar em Abrir ROM.
        private void button1_Click(object sender, EventArgs e)
        {   
            //Cria um seletor de aquivos para o usuario escolher o arquivo da ROM. Instancia de Objeto.
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Usando funçao .FIlter para filtrar e mostrar apenas o arquivos gba e nds.
            openFileDialog.Filter = "ROM Files (*.gba;  *.nds)|*.gba;*.nds";

            //Verifica se o usuario clicou em algum arquivo e selecionou.
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {   
                //Variavel para receber o caminho da ROM selecionada.
                string RomPath = openFileDialog.FileName;

                //Mostra nome do arquivo selecionado para o usuario.
                lblFile.Text = $"ROM Selected: {Path.GetFileName(RomPath)}";

                //Le o conteudo e armazena em array de bytes.
                //Vai permitir acessar os dados do jogo e alterar futuramente.
                byte[] RomData = File.ReadAllBytes(RomPath);

                //Exibe uma mensagem com o tamanho da ROM (TESTE).
                MessageBox.Show($"ROM loaded with {RomData.Length} bytes");
            }
        }

        private void lblFile_Click(object sender, EventArgs e)
        {

        }
    }
}
