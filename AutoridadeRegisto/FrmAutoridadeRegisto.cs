using Microsoft.Win32;
using VotingSystem;
using VotingSystem.Voting;

namespace AutoridadeRegisto
{
    public partial class FrmAutoridadeRegisto : Form
    {
        private string credencial = string.Empty;
        private string ccNumber = string.Empty;

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
            ccNumber = txtCartaoCidadao.Text.Trim();

            if (string.IsNullOrWhiteSpace(ccNumber) || !IsNumeric(ccNumber))
            {
                MessageBox.Show(
                    "Introduza o número do Cartão de Cidadão. Apenas números.",
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

                // 1) Se o servidor diz que não é elegível, aqui entra “já votou” (ou outro motivo)
                if (!response.IsEligible)
                {
                    MessageBox.Show(
                        "Este número do Cartão de Cidadão já consta como tendo realizado a votação (ou não é elegível). " +
                        "\nPor favor, verifique se o número foi digitado corretamente.",
                        "Autoridade de Registo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Invalido();
                    return;
                }

                // 2) Credencial devolvida pelo servidor
                credencial = response.VotingCredential ?? string.Empty;

                // 3) Se a credencial for inválida, forçamos “não elegível”
                if (credencial.StartsWith("INVALID", StringComparison.OrdinalIgnoreCase))
                {
                    Invalido();
                    return;
                }

                // 4) Se chegou aqui, é válido
                lblElegivelValor.Text = "Sim";
                Valido();

                CaregaCandidatos();
                lstCandidatos.Enabled = true;
                lstCandidatos.BackColor = Color.White;
                txtCartaoCidadao.Enabled = false;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao obter credencial.\nChame um responsável na mesa de votação e reporte o problema.";
                MessageBox.Show(
                    "Erro ao contactar o serviço: " + ex.Message +
                    "\nChame um responsável na mesa de votação e reporte o problema.",
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lstCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCandidatos.SelectedItem == null)
            {
                lblMsgConfirmacao.Visible = false;
            }
            else
            {
                lblMsgConfirmacao.Visible = true;

                lblCandSelecionado.Text = lstCandidatos.GetItemText(lstCandidatos.SelectedItem);

                string valor = lblCandSelecionado.Text;
                switch (valor)
                {
                    case "Candidato A":
                        picP.Visible = true;
                        picV.Visible = false;
                        picS.Visible = false;
                        break;

                    case "Candidato B":
                        picP.Visible = false;
                        picV.Visible = true;
                        picS.Visible = false;
                        break;

                    case "Candidato C":
                        picP.Visible = false;
                        picV.Visible = false;
                        picS.Visible = true;
                        break;

                    default:
                        Console.WriteLine("Outro valor");
                        break;
                }
            }
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
                lblStatus.Text = "Erro ao obter a lista candidatos.\nChame um responsável na mesa de votação e reporte o problema.";
                MessageBox.Show(
                    "Erro ao obter candidatos: " + ex.Message +
                    "\nChame um responsável na mesa de votação e reporte o problema.",
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnVotar_Click(object sender, EventArgs e)
        {
            var cred = credencial?.Trim();
            if (string.IsNullOrWhiteSpace(cred))
            {
                MessageBox.Show(
                    "Credencial de voto não registada.\nChame um responsável na mesa de votação e reporte o problema.",
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (lstCandidatos.SelectedItem is not Candidate cand)
            {
                MessageBox.Show(
                    "Deve selecionar um candidato.",
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
                {
                    lblStatus.Text = "Voto registado com sucesso.";
                    Reset();
                }
                else
                {
                    lblStatus.Text = "Voto recusado: " + response.Message +
                                     "\nChame um responsável na mesa de votação e reporte o problema.";
                }

                MessageBox.Show(
                    $"Sucesso: {response.Success}\nMensagem: {response.Message}",
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao submeter voto.\nChame um responsável na mesa de votação e reporte o problema.";
                MessageBox.Show(
                    "Erro ao votar: " + ex.Message,
                    "Autoridade de Registo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public bool IsNumeric(string valor)
        {
            return !string.IsNullOrEmpty(valor) &&
                   valor.All(char.IsDigit);
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
            lblElegivelValor.Text = "Não";
            lblStatus.Text = "Não elegível/credencial inválida.\nVerifique o número do Cartão de Cidadão e repita o processo.";
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

            picP.Visible = false;
            picV.Visible = false;
            picS.Visible = false;

            lstCandidatos.DataSource = null;
            lstCandidatos.Enabled = false;
            lstCandidatos.BackColor = Color.Silver;

            txtCartaoCidadao.Enabled = true;
            txtCartaoCidadao.Text = string.Empty;
        }

        private void lblMsgConfirmacao_Click(object sender, EventArgs e)
        {
        }

        #endregion
        //#####################################################################################################################
    }
}