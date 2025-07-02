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

                // Offset do primeiro nome de Pokémon (Bulbasaur) em Emerald
                int offsetBulbasaur = 0x1CFE00;
                int nameSize = 11;

                string nameBulbasaur = ReadTextPKMN(RomData, offsetBulbasaur, nameSize);

                // Mostra na tela
                MessageBox.Show($"First Pokémon: {nameBulbasaur}");
            }
        }

        private void lblFile_Click(object sender, EventArgs e)
        {

        }

        //Funçao que converte bytes da ROM para texto usando a tabela de caracteres do PKMN Emerald.
        private string ReadTextPKMN(byte[] romData, int offset, int length)
        {   
            //Tabela simplificada com Letras e espaços
            Dictionary<byte, char> table = new Dictionary<byte, char>()
                {
                    { 0x00, ' ' }, { 0x02, ' ' }, { 0x08, ' ' }, { 0x10, ' ' }, { 0x20, ' ' }, { 0x81, ' ' },
                    { 0x47, 'é' }, 
                    { 0xFE, '\n' },
                    { 0xFF, '\0' },
                    { 0x2D, '-' },
                    { 0xA1, 'a' }, { 0xA2, 'b' }, { 0xA3, 'c' }, { 0xA4, 'd' }, { 0xA5, 'e' },
                    { 0xA6, 'f' }, { 0xA7, 'g' }, { 0xA8, 'h' }, { 0xA9, 'i' }, { 0xAA, 'j' },
                    { 0xAB, 'k' }, { 0xAC, 'l' }, { 0xAD, 'm' }, { 0xAE, 'n' }, { 0xAF, 'o' },
                    { 0xB0, 'p' }, { 0xB1, 'q' }, { 0xB2, 'r' }, { 0xB3, 's' }, { 0xB4, 't' },
                    { 0xB5, 'u' }, { 0xB6, 'v' }, { 0xB7, 'w' }, { 0xB8, 'x' }, { 0xB9, 'y' },
                    { 0xBA, 'z' }, { 0xBB, 'A' }, { 0xBC, 'B' }, { 0xBD, 'C' }, { 0xBE, 'D' },
                    { 0xBF, 'E' }, { 0xC0, 'F' }, { 0xC1, 'G' }, { 0xC2, 'H' }, { 0xC3, 'I' },
                    { 0xC4, 'J' }, { 0xC5, 'K' }, { 0xC6, 'L' }, { 0xC7, 'M' }, { 0xC8, 'N' },
                    { 0xC9, 'O' }, { 0xCA, 'P' }, { 0xCB, 'Q' }, { 0xCC, 'R' }, { 0xCD, 'S' },
                    { 0xCE, 'T' }, { 0xCF, 'U' }, { 0xD0, 'V' }, { 0xD1, 'W' }, { 0xD2, 'X' },
                    { 0xD3, 'Y' }, { 0xD4, 'Z' }, { 0xE0, '\'' }, { 0xE1, '-' }, { 0xE2, '?' }
                };

            string result = "";

            for (int i = 0; i < length; i++) {
                //Pega o byte atual da ROM, começando do offset
                byte b = romData[offset + i];
                if (table.ContainsKey(b))
                    result += table[b];
                else 
                    result += '?'; //Caractere desconhecido
            }

            // Debug: imprime os bytes lidos no console
            string debug = "";
            for (int i = 0; i < length; i++)
                debug += $"{romData[offset + i]:X2} ";

            MessageBox.Show($"Bytes read: {debug}");

            return result.Trim();


        }
    }
}
