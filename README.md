# Voting System – Trabalho Prático de Integração de Sistemas

## Descrição Geral

Este repositório contém a implementação de uma **aplicação de votação eletrónica** desenvolvida no âmbito da unidade curricular **Integração de Sistemas** (Ano letivo 2025/2026).

O objetivo do trabalho é estudar e aplicar conceitos de **integração de sistemas distribuídos**, recorrendo a **serviços gRPC**, respeitando princípios fundamentais como:
- anonimato do voto,
- validação dos votantes,
- separação de responsabilidades entre entidades.

A solução implementa uma aplicação cliente que consome **serviços gRPC mock ou disponibilizados em ken01.utad.pt:9091** fornecidos para efeitos académicos.

## IMPORTANTE
A solução deve iniciar todos os projectos da solução. A solução foi deixada configurada (.slnx) para executar todas, mas caso haja alguma questão quanto à isto, basta clicar com o botão direito no projecto AutoridadeVotacao e selecionar "Configurar Projetos de Inicialização". Após, do lado direito, colocar todos os projetos com a ação "Iniciar", e premir o botão "Ok".

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

A solução deve iniciar todos os projectos da solução. A solução foi deixada configurada (.slnx) para executar todas, mas caso haja alguma questão quanto à isto, basta clicar com o botão direito no projecto AutoridadeVotacao e selecionar "Configurar Projetos de Inicialização". Após, do lado direito, colocar todos os projetos com a ação "Iniciar", e premir o botão "Ok".


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
#Funcionalidade Experimental – Prevenção de Voto Duplicado (Mock Local)

Para efeitos de demonstração e experimentação, o sistema inclui uma funcionalidade experimental de prevenção de voto duplicado, implementada exclusivamente no mock local do serviço de registo de eleitores.

Esta funcionalidade não faz parte do endpoint remoto oficial disponibilizado para a realização do trabalho, tendo sido criada apenas para ilustrar como poderia ser tratado o cenário em que um mesmo eleitor tenta votar mais do que uma vez.

a) Descrição da funcionalidade

A lógica encontra-se implementada no método IssueVotingCredential do serviço de registo e baseia-se num mecanismo simples de controlo local:

a.1.É mantida uma estrutura de dados em memória que associa o número do Cartão de Cidadão à data/hora de emissão da credencial de voto.
a.2.Sempre que um pedido é efetuado com um número de Cartão de Cidadão já registado, a emissão de uma nova credencial é recusada.
a.3.Não é armazenada qualquer informação relativa à opção de voto, garantindo-se o anonimato do processo.
a.4.Esta abordagem permite impedir a duplicação de voto, reforçando o controlo de elegibilidade do votante, sem introduzir mecanismos de auditoria ou persistência permanente.

b) Como ativar o Mock Local para Testar Voto Duplicado

A funcionalidade de prevenção de voto duplicado está disponível apenas no mock local do serviço de registo. Para a experimentar, é necessário trocar temporariamente o endpoint remoto pelo endpoint local no código cliente.

Vá em:
Projeto: AutoridadeRegisto
Classe: VotacaoApiAR
Ficheiro: VotacaoApiAR.cs
Método afetado: construtor estático onde é criado o GrpcChannel

Passos para ativar o mock local

b.1.Abrir o ficheiro: AutoridadeRegisto/VotacaoApiAR.cs


b.2.Comentar o endpoint remoto e descomentar o endpoint local, ficando assim:

var channel = GrpcChannel.ForAddress(
    // "https://ken01.utad.pt:9091",   // Endpoint remoto (oficial)
    "https://localhost:9093",         // Mock local (voto duplicado)
    new GrpcChannelOptions { HttpHandler = handler });


b.3.Guardar o ficheiro e executar novamente a aplicação.


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
