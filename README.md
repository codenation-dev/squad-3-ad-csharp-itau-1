# TryLog

### Propósito do projeto

Este projeto deve servir para capturar erros vindos de qualquer aplicação. Para permitir que isso aconteça,  disponibilizaremos endpoints REST para tratar as mensagens de erro capturadas em diversas plataformas, como mobile, site e o próprio backend desta aplicacao. Tentaremos seguir o mais próximo da teoria REST apresentada por Roy Fielding.

#### Sobre conceitos descritos

Como se trata de um projeto vinculado a Codenation/Itaú e possui um intuito de aprendizado/demonstração de conhecimento, nos propomos a descrever com detalhes os conceitos que vamos utilizar, mostrando como os entendemos.

#### Arquitetura do sistema

Decidimos separar as camadas de projeto, tendo como orientação o modelo Clean Architecture, de Bob Martin, mas usado aqui na visão de Steve Smith. Info: Microsoft Docs (https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures].

Através desta modelo arquitetural, esperamos melhorar a forma como o projeto é separado e compreendido. Tendo também vantagens como uso de injeção de dependência, fazendo a inverção do controle e viabilizando testes automatizados (unitários a princípio).

Também nos serviu de base o material apresentado no livro Asp.NET Core Architecture e-book, disponível em sítio microsoft [https://dotnet.microsoft.com/download/e-book/aspnet/pdf].

##### Camada de Infraestrutura

São itens desta camada, aqueles relativos à:

* Conexão com banco de dados
* Tipos representando o banco de dados
* Implementações de acesso a dados (das Interfaces definidas no Core)
* Serviços específicos de infraestrutura

##### Camada de Webapi

Esta camada será responsável por receber as requisições dos clientes e endereça-las.

Vamos tratar aqui:

* Autenticação e autorização
* Rotas
* Bindings
* Injeção de dependência
* Ativação de serviços que afetam o pipeline HTTP


##### Camada Core

Esta camada é responsável por armazenar as abstrações do nosso universo. Por exemplo, o que é um log de erro será representado aqui por uma classe.

Nesta camada você vai encontrar os seguintes itens:

* Entidades
* Interfaces
* Servicos
* DTOs


#### Camada UseCases

Embora não esteja descrita nos materiais de arquitetura mencionados, achamos por bem adicionar uma camada para isolar as funcionalidades do sistema. Nela você vai encontrar:

* Funcionalidades descritas em casos de uso

#### MessageBroker

Vamos utilizar o conceito de MessageBroker para dar confiabilidade na entrega e gravação dos logs, fazendo com que nossa API apenas faça uma publicação do log em sistema de fila. Este, por sua vez, será o responsável por acionar a gravação do banco de dados.

Esperamos assim, resolver possíveis problemas com não gravação de log, ou incosistência e perda de logs.

#### Tests

Por fim uma camada para separar os testes será utilizada.

## Criando as camadas

Camada | Comando |
_______|__________
Core | dotnet new classlib -n TryLog.Core -o ./src/Core
Infraestructure | dotnet new classlib -n TryLog.Infraestructure -o ./src/Infraestructure
UseCase | dotnet new classlib -n TryLog.UseCase -o ./src/UseCase
WebApi | dotnet new webapi -n TryLog.WebApi -o ./src/WebApi
MessageBroker | dotnet new console -n TryLog.MessageBroker ./src/MessageBroker
Sentinela | dotnet new xunit -n TryLog.Sentinela ./tests/Sentinela
