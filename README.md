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

## Aluno

- **Nome:** Luiz Henrique Grabe
- **RM:** 556001
- **Turma:** ESPV
- **Disciplina:** C Software Development — FIAP
