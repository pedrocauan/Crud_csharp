using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormularioBasico
{

    public class Pessoa
    {
        public bool VerificaIdade(int idade)
        {
            if(idade >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public partial class func : Form
    {
       
        public func()
        {
            InitializeComponent();
        }

        int cd_func = 0; //variavel que vai guardar o código
        string funcionario = "";
        string cpf = "";
        string sql; //Variavel que vai guardar o comando sql que vai ler a db

        Pessoa teste = new Pessoa();
        teste.VerificaIdade(18);

        SqlConnection cn = new SqlConnection("Data Source=lab1-20;Initial Catalog=bd_turmaB;User ID=sa;password=1234567"); //Conecta com o bd no sqlserver
        SqlCommand cm = new SqlCommand(); //Faz os comandos sql
        SqlDataReader rd; //lê o bd
        private void Funcionario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Usa o select table no banco de dados e retorna um bool dizendo se existe o registro na tabela
        private bool SelectTable()
        {
            sql = "select * from tbl_funcionario where cd_func = " + cd_func.ToString();
            cn.Open(); // abre o db
            cm.Connection = cn; //Conexão db aberto
            cm.CommandText = sql;//Comando sql que será inserido no db
            rd = cm.ExecuteReader(); //Executa  o comando  

            //Ve se o registro existe na tabela
            if (rd.HasRows)
                return true;
            else
                return false;

        }

        public void ExecutaComandoSql(SqlConnection conexao, string comando)
        {
            cm.Connection = conexao;
            cm.CommandText = comando;
            cm.ExecuteNonQuery();
        }

        //btnDelete
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

       
                //Condição que verifica se o usuario clicou no botão de SIM para excluir o registro
                bool confirma_exclusao = MessageBox.Show("Deseja realmente apagar este registro?", "AVISO !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

                //Ve se o registro existe na tabela
                if (!SelectTable())
                {
                    MessageBox.Show("Código não cadastrado!!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //fecha a conexão se tiver fechado
                    if (!rd.IsClosed)
                        cn.Close();
                    if (confirma_exclusao)
                    {
                        cn.Open(); //abre conexão
                        sql = "delete from tbl_funcionario where cd_func = @cod"; //comando sql pra deletar registro
                        cm.Parameters.Clear(); //Limpa os parametros  inseridos anteriormente
                        cm.Parameters.Add("@cod", SqlDbType.Int).Value = cd_func; //Substitui o @cod pela variavel cd_func

                        //Executa o comando de excluir no banco de dados.
                        ExecutaComandoSql(cn, sql);

                        MessageBox.Show("Registro excluido com sucesso", "Registro Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
         

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

               
            }
            finally
            {
                cn.Close();
            }
            LimparCampos();

        }

        //In
     

        //btnChange
        private void button3_Click(object sender, EventArgs e)
        {
            cd_func = TrataCodigo(cd_func);
            funcionario = TrataFunc(txtFunc.Text);
            cpf = TrataCpf(txtCpf.Text);
            //se o usuario clicar em Sim no botao de aviso ele cai na condição que altera o registro do bd
            bool confirmacao = MessageBox.Show("Deseja alterar o registro??",
                "AVISO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
            try {

                if (!SelectTable())
                    MessageBox.Show("Código não cadastrado!!",  "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (!rd.IsClosed)
                        cn.Close();
                     if (confirmacao)
                    {
                        cn.Open();
                        sql = "update tbl_funcionario set nm_func = @nome, no_CPF = @cpf where cd_func =  @cod";
                        cm.Parameters.Clear();
                        cm.Parameters.Add("@cod", SqlDbType.Int).Value = cd_func;
                        cm.Parameters.Add("@nome", SqlDbType.VarChar).Value = funcionario;
                        cm.Parameters.Add("@cpf", SqlDbType.Char).Value = cpf;

                        ExecutaComandoSql(cn, sql);

                        MessageBox.Show("Dados inseridos com sucesso !!", "Registros inseridos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                 }
               
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                cn.Close();
            }
            LimparCampos();

        }
        // =====TRATA OS ERROS DO CÓDIGO ========
        public int TrataCodigo(int cod) 
        {
           

            //Se nao for um inteiro maior que zero ele da as mensagens de erro
            if (!int.TryParse(txtCodigo.Text, out cod))
            {
                MessageBox.Show("Código inválido !! Digitar um valor inteiro", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus(); //Deixa o cursor do mouse na textbox q deu erro.
            }
            else if (cod == 0)
            {
                MessageBox.Show("Código inválido, por favor inserir um valor inteiro maior que zero.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
            }
 
            return cod;
        }

        // =====TRATA OS ERROS DO CÓDIGO ========
        public string TrataFunc(string func)
        {
            
            // Ve se o campo ta vazio
            if (txtFunc.Text == "")
            {
                MessageBox.Show("O Campo FUNCIONARIO está vazio !!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFunc.Focus();
            }
            //ve se ele digitou o nome completo
            else if(txtFunc.Text.Length < 8)
            {
                MessageBox.Show("Informe o nome completo do funcionário !!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFunc.Focus();

            }
            else
            {
                func = txtFunc.Text;
            }
            return func;
        }
        // ==== TRATA ERRO DO CPF ===
        public string TrataCpf(string cpf)
        {
            if (txtCpf.Text == "")
            {
                MessageBox.Show("O Campo CPF está vazio !!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFunc.Focus();
            }
            else
            {
                cpf = txtCpf.Text;
            }
            return cpf;
        }
        //btnRegister
        private void button2_Click(object sender, EventArgs e)
        {

            //Trata os erros do formulário
            cd_func = TrataCodigo(cd_func);
            funcionario = TrataFunc(funcionario);
            cpf = TrataCpf(cpf);

            //lendo bd
            try
            {
                if(!SelectTable()) //has how ve se tem um registro do código no banco de dados
                {
                    MessageBox.Show("Código já cadastrada !!", "ERRO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                    cn.Close();
                }

                else
                { 
                    if (!rd.IsClosed)
                        rd.Close(); //reader 

                   sql = "insert into tbl_funcionario(cd_func, nm_func, NO_cpf)values(@Cod, @Nome, @CPF)";
                   //parameters add adiciona o conteudo das variaveis nos campos do banco de dados

                   cm.Parameters.Clear(); //Limpa todos os parametros

                   cm.Parameters.Add("@Cod", SqlDbType.Int).Value = cd_func;
                   cm.Parameters.Add("@Nome", SqlDbType.VarChar).Value = funcionario;
                   cm.Parameters.Add("@CPF", SqlDbType.Char).Value = cpf;

                   ExecutaComandoSql(cn, sql);
                   MessageBox.Show("Dados inseridos com sucesso");
                   LimparCampos();
                   cn.Close(); //fecha a conexão                   
                }
               

            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            txtFunc.Clear();
            txtCpf.Clear();
        }

        //btnSearch
        private void button1_Click(object sender, EventArgs e)

        {


            bool usuario_confirmou = MessageBox.Show("Mensagem", "titulo", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if(usuario_confirmou)
            {
                MessageBox.Show("o resultado é sim");

            }
            else
            {
                MessageBox.Show("o resultado é nao");
            }
            cd_func = TrataCodigo(cd_func);//Pegando o código

            
            try
            {
         
                if(!SelectTable())
                {
                    MessageBox.Show("Código não cadastrado !!", "ERRO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cn.Close();
                }

                else
                {
                    rd.Read(); //Lê  o registro digitado na tabela
                    txtFunc.Text = rd["nm_func"].ToString();
                    txtCpf.Text = rd["no_CPF"].ToString();
                    cn.Close();
                }


            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
