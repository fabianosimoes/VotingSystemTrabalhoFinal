# Voting System – Trabalho Prático de Integração de Sistemas

## Descrição Geral

Este repositório contém a implementação de uma **aplicação de votação eletrónica** desenvolvida no âmbito da unidade curricular **Integração de Sistemas** (Ano letivo 2025/2026).

O objetivo do trabalho é estudar e aplicar conceitos de **integração de sistemas distribuídos**, recorrendo a **serviços gRPC**, respeitando princípios fundamentais como:
- anonimato do voto,
- validação dos votantes,
- separação de responsabilidades entre entidades.

A solução implementa uma aplicação cliente que consome **serviços gRPC mock ou disponibilizados em ken01.utad.pt:9091** fornecidos para efeitos académicos.

---

## Arquitetura do Sistema

O sistema segue uma arquitetura distribuída e orientada a serviços, baseada em três autoridades conceptuais:

- **Autoridade de Registo (AR)**  
  Responsável pela validação do eleitor e emissão da credencial de voto.

- **Autoridade de Votação (AV)**  
  Responsável pela receção do voto, validação da credencial e disponibilização dos resultados.

- **Autoridade de Apuramento (AA)**  
  Responsável pela contagem dos votos (implementada de forma simplificada através da AV).

A aplicação cliente comunica exclusivamente com estas autoridades através de **serviços gRPC**, promovendo baixo acoplamento e independência entre módulos.

---

## Serviços gRPC Utilizados

Os serviços são disponibilizados externamente (mockups) e descritos nos ficheiros `.proto`.

### Endpoint



### Serviços disponíveis

- `VoterRegistrationService/IssueVotingCredential`  
  Emissão de credenciais de voto.

- `VotingService/GetCandidates`  
  Consulta da lista de candidatos.

- `VotingService/Vote`  
  Submissão do voto com credencial válida.

- `VotingService/GetResults`  
  Consulta dos resultados eleitorais.

---

## Tecnologias Utilizadas

- **C# (.NET / WinForms)** – aplicação cliente
- **gRPC** – integração entre sistemas
- **Protocol Buffers** – definição dos contratos de serviço
- **Visual Studio 2022**
- **grpcurl** – testes iniciais aos serviços
- **GitHub** – versionamento e partilha do código

---

## Estrutura do Repositório
/
├── AutoridadeRegisto/ # Cliente da Autoridade de Registo
├── AutoridadeVotacao/ # Cliente da Autoridade de Votação
├── ClienteVotacao/ # Aplicação WinForms
├── Protos/ # Ficheiros .proto
├── README.md
└── VotingSystem.sln


---

## Como Executar o Projeto

### Pré-requisitos
- Windows
- Visual Studio 2022
- .NET SDK compatível
- Ligação à internet (para acesso aos serviços gRPC)

### Passos
1. Clonar o repositório:
git clone https://github.com/fabianosimoes/VotingSystemTrabalhoFinal.git

2. Abrir o ficheiro:
no Visual Studio 2022.

3. Compilar e executar:
- Premir **F5** ou clicar em **Iniciar** no Visual Studio.

4. Utilizar a aplicação cliente para:
- obter uma credencial de voto,
- consultar candidatos,
- submeter um voto,
- consultar resultados.

---

## Testes aos Serviços

Antes da implementação da aplicação cliente, os serviços foram testados diretamente com a ferramenta **grpcurl**, permitindo validar:
- emissão de credenciais,
- aceitação/rejeição de votos,
- funcionamento do apuramento,
- limitações dos serviços mock (persistência em memória, ausência de segurança avançada).

---

## Limitações Conhecidas

- Os votos são mantidos **apenas em memória**.
- Não existe persistência em base de dados.
- Não estão implementados mecanismos de segurança avançados (autenticação forte, cifragem).
- A Autoridade de Apuramento encontra-se integrada na Autoridade de Votação.

Estas limitações são **assumidas e aceitáveis** no contexto académico do trabalho.

---

## Contexto Académico

Este projeto foi desenvolvido exclusivamente para fins académicos, no âmbito da unidade curricular **Integração de Sistemas**, servindo como exercício prático de:
- desenho de arquiteturas distribuídas,
- consumo de serviços gRPC,
- integração entre sistemas independentes.

---

## Autor

**Ivo Simões**  
Universidade Aberta  
Unidade Curricular: Integração de Sistemas  
Ano letivo: 2025/2026
