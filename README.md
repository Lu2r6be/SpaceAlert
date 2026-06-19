# SpaceAlertMonitor

Sistema de monitoramento espacial desenvolvido em C# como parte da **Global Solution da FIAP** — tema **Space Connect: Tecnologia Espacial Aplicada a Desafios Reais**.

## Sobre o Projeto

O SpaceAlertMonitor é uma aplicação Console em .NET que permite cadastrar dispositivos espaciais (como satélites e sensores) e registrar alertas vinculados a eles, com controle automático de data e hora.

O sistema simula o monitoramento de uma infraestrutura espacial: cada dispositivo pode gerar alertas com diferentes níveis (Baixo, Médio, Alto), e o sistema integra essas informações em um relatório.

## Funcionalidades

- Cadastrar satélites com órbita e coordenadas geográficas
- Cadastrar sensores com tipo de monitoramento
- Registrar alertas com nível de criticidade
- Listar todos os dispositivos cadastrados
- Listar todos os alertas registrados
- Gerar relatório por nível de alerta

## Conceitos de POO Aplicados

| Conceito | LOcal do projeto |
|---|---|
| Classe Abstrata | `DispositivoEspacial` — base para `Satelite` e `Sensor` |
| Herança | `Satelite` e `Sensor` herdam de `DispositivoEspacial` |
| Polimorfismo | `ExibirInfo()` sobrescrito com `override` em cada subclasse |
| Interface | `IMonitoravel` implementada por `Satelite` e `Sensor` |
| Injeção de Dependência | `IMonitoravel monitor = satelite` no `Program.cs` |
| Encapsulamento | Campos `private` com propriedades `public` em todas as classes |
| Static | `contadorId` estático em `DispositivoEspacial` e `Alerta` |
| Struct | `Coordenada` — armazena latitude e longitude do satélite |
| Partial Class | `AlertaService` dividida em `AlertaService.cs` e `AlertaService.Relatorio.cs` |
| DateTime | `DataRegistro` e `RegistradoEm` usam `DateTime.Now` automaticamente |
| Tratamento de Exceções | `try/catch` com `FormatException` e `ArgumentException` em todas as entradas |

## Estrutura do Projeto

```
SpaceAlertMonitor/
├── Interface/
│   └── IMonitoravel.cs           ← contrato de monitoramento
├── Model/
│   ├── Coordenada.cs             ← struct com latitude e longitude
│   ├── DispositivoEspacial.cs    ← classe abstrata base
│   ├── Satelite.cs               ← herda + implementa IMonitoravel
│   ├── Sensor.cs                 ← herda + implementa IMonitoravel
│   └── Alerta.cs                 ← registro de alerta com DateTime
├── Service/
│   ├── AlertaService.cs          ← partial: CRUD de alertas
│   └── AlertaService.Relatorio.cs← partial: geração de relatório
├── Program.cs                    ← menu principal e métodos locais
└── SpaceAlertMonitor.csproj
```

## Como Executar

1. Clonar o repositório
2. Abrir o arquivo `SpaceAlertMonitor.csproj` no Visual Studio
3. Abrir o terminal e digitar `dotnet run` para executar

## Evidências de Execução

### Organização do Projeto
<img width="292" height="225" alt="Screenshot_20260619_115025" src="https://github.com/user-attachments/assets/d1c02b8a-84ca-481c-86aa-cfd66bc27556" />

### Menu
<img width="547" height="288" alt="Screenshot_20260619_115046" src="https://github.com/user-attachments/assets/6437eaac-e521-4c60-86e1-88d210037f0a" />

### Cadastro de Satélite
<img width="458" height="442" alt="Screenshot_20260619_115300" src="https://github.com/user-attachments/assets/5b8ea0a0-f0c4-4bd4-a2eb-583286254504" />

### Cadastro de Sensor
<img width="552" height="482" alt="Screenshot_20260619_115917" src="https://github.com/user-attachments/assets/32db0bd8-7ec2-4734-a683-606262447593" />

### Listar Dispositivos
<img width="1109" height="408" alt="Screenshot_20260619_115956" src="https://github.com/user-attachments/assets/25b574fb-5913-428a-bb8c-e112fbd027f0" />

### Registrar Alerta
<img width="1067" height="495" alt="Screenshot_20260619_120223" src="https://github.com/user-attachments/assets/91f84811-f65d-4b23-bf4d-b8c9fd63f9fd" />

### Alertas Registrados
<img width="1067" height="495" alt="Screenshot_20260619_120223" src="https://github.com/user-attachments/assets/3e6142f2-70d3-4436-85a2-8d00f03bd757" />

<img width="1083" height="501" alt="Screenshot_20260619_120310" src="https://github.com/user-attachments/assets/2059c518-358a-4e19-a542-3fb00dd2bd3d" />

### Relatorio
<img width="940" height="397" alt="Screenshot_20260619_120338" src="https://github.com/user-attachments/assets/68e19379-721b-4be1-93dc-1144e84f197f" />

### Alerta de erro
<img width="394" height="342" alt="Screenshot_20260619_120422" src="https://github.com/user-attachments/assets/45aeb567-6607-44b8-8a73-91f923179302" />

### Fechando sistema
<img width="437" height="304" alt="Screenshot_20260619_120453" src="https://github.com/user-attachments/assets/9ddfea32-048d-4d6f-93cc-4af4946068d5" />


## Aluno

- **Nome:** Luiz Henrique Dos Reis Grabe
- **RM:** 556001
- **Turma:** ESPV
- **Disciplina:** C Software Development — FIAP
