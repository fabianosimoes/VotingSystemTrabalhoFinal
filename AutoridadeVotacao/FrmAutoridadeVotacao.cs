using VotingSystem.Voting;

namespace AutoridadeVotacao
{
    public partial class FrmAutoridadeVotacao : Form
    {
        public FrmAutoridadeVotacao()
        {
            InitializeComponent();
            lblStatus.Text = "Pronto.";
        }

        private void FrmAutoridadeVotacao_Load(object sender, EventArgs e)
        {

        }

       
        private async void btnVerResultados_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "A obter resultados...";

                var response = await VotacaoApi.Client.GetResultsAsync(new GetResultsRequest());

                gridResultados.AutoGenerateColumns = true;

                gridResultados.DataSource = response.Results;

                lblStatus.Text = "Resultados atualizados.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao obter resultados.";
                MessageBox.Show("Erro ao obter resultados: " + ex.Message);
            }
        }



    }
}
