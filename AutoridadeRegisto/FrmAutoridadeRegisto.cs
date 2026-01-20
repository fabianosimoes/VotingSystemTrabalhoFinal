using VotingSystem;
using VotingSystem.Voting;

namespace AutoridadeRegisto
{
    public partial class FrmAutoridadeRegisto : Form
    {

        private string credencial=string.Empty;

        public FrmAutoridadeRegisto()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
        }

        //#####################################################################################################################
        #region Métodos de Interface
        private async void btnObterCredencial_Click(object sender, EventArgs e)
        {
            Reset();

            var ccNumber = txtCartaoCidadao.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ccNumber))
            {
                MessageBox.Show("Introduza o número do Cartão de Cidadão.");
                return;
            }

            try
            {
                lblStatus.Text = "A contactar serviço de registo...";

                var request = new VoterRequest
                {
                    CitizenCardNumber = ccNumber
                };

                var response = await RegistoApi.Client.IssueVotingCredentialAsync(request);

                // primeiro, mostra o que veio do serviço
                bool elegivel = response.IsEligible;
                credencial = response.VotingCredential ?? string.Empty;

                // se a credencial for inválida, forçamos "não elegível"
                if (credencial.StartsWith("INVALID", StringComparison.OrdinalIgnoreCase))
                {
                    elegivel = false;
                }

                lblElegivelValor.Text = elegivel ? "Sim" : "Não";
                

                if (!elegivel)
                {
                    Invalido();
                }
                else
                {
                    Valido();
                    CaregaCandidatos();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao obter credencial. Chame um responsávelna mesa de votação e reporte o problema.";
                MessageBox.Show("Erro ao contactar o serviço: " + ex.Message + "Chame um responsávelna mesa de votação e reporte o problema.");
            }
        }


        private void lstCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCandidatos.SelectedItem == null)
                return;

             lblCandSelecionado.Text = lstCandidatos.GetItemText(lstCandidatos.SelectedItem);
            lblMsgConfirmacao.Visible = true;
        }
        #endregion

        //#####################################################################################################################

        //#####################################################################################################################
        #region Métodos internos
        private async void CaregaCandidatos()
        {
            try
            {
                lblStatus.Text = "A carregar candidatos...";

                var response = await VotacaoApiAR.Client.GetCandidatesAsync(new GetCandidatesRequest());

                lstCandidatos.DataSource = response.Candidates;
                lstCandidatos.DisplayMember = "Name";
                lstCandidatos.ValueMember = "Id";

                lblStatus.Text = "Candidatos carregados.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao obter a lista candidatos.Chame um responsávelna mesa de votação e reporte o problema. ";
                MessageBox.Show("Erro ao obter candidatos: " + ex.Message + "Chame um responsávelna mesa de votação e reporte o problema.");
            }
        }

        private async void btnVotar_Click(object sender, EventArgs e)
        {
            var cred = credencial?.Trim();
            if (string.IsNullOrWhiteSpace(cred))
            {
                MessageBox.Show("Credencial de voto não registada. Chame um responsávelna mesa de votação e reporte o problema.");
                return;
            }

            if (lstCandidatos.SelectedItem is not Candidate cand)
            {
                MessageBox.Show("Deve selecionar um candidato.");
                return;
            }

            try
            {
                lblStatus.Text = "A submeter voto...";

                var request = new VoteRequest
                {
                    VotingCredential = cred,
                    CandidateId = cand.Id
                };

                var response = await VotacaoApiAR.Client.VoteAsync(request);

                if (response.Success)
                    lblStatus.Text = "Voto registado com sucesso.";
                else
                    lblStatus.Text = "Voto recusado: " + response.Message + "Chame um responsávelna mesa de votação e reporte o problema." ;

                MessageBox.Show($"Sucesso: {response.Success}\nMensagem: {response.Message}");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao submeter voto." + "Chame um responsávelna mesa de votação e reporte o problema";
                MessageBox.Show("Erro ao votar: " + ex.Message);
            }
        }



        private void Valido()
        {
            lblStatus.Text = "Credencial válida obtida com sucesso.";
            lblStatus.ForeColor = Color.Green;
            lblElegivelValor.ForeColor = Color.Green;
            lblMensagemInstr.Visible = true;
            btnObterCredencial.Enabled = false;
            btnVotar.Enabled = true;

        }
        private void Invalido()
        {
            lblStatus.Text = "Credencial inválida. Verifique se o número do Cartão de Cidadão foi digitado corretamente e repita o processo.";
            lblStatus.ForeColor = Color.Red;
            lblElegivelValor.ForeColor = Color.Red;
            lblMensagemInstr.Visible = false;
            btnObterCredencial.Enabled = true;
            btnVotar.Enabled = false;
        }

        private void Reset()
        {
            lblElegivelValor.Text = "N/D";
            lblStatus.Text = "Pronto";
            lblStatus.ForeColor = Color.Black;
            lblElegivelValor.ForeColor = Color.Black;
            lblMsgConfirmacao.Visible = false;
            lblCandSelecionado.Text = "N/D";
            lblMensagemInstr.Visible = false;
            credencial = string.Empty;
            btnObterCredencial.Enabled = true;
            btnVotar.Enabled = false;
        }
#endregion

        //#####################################################################################################################
    }
}
