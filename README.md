# Central De Erros

> Desafio final da Aceleração Dev de C# da Codenation, com apoio da Stone.

# Central de Erros - Back-end (API)

Desenvolvimento de uma API para registro e acesso a logs de erros registrados por microserviços, para possibilitar o monitoramento e auxiliar na tomada de decisão.

*A aplicação foi desenvolvida em conformidade com as instruções para o projeto final.* 

## Tecnologia

- [Visual Studio Code](https://visualstudio.microsoft.com/pt-br/downloads/) ```2019```
- [.NET Core Runtime](https://dotnet.microsoft.com/download/dotnet-core/2.2/runtime/?utm_source=getdotnetcore&utm_medium=referral) ```2.2```
- [SQL Server](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [Postman](https://www.postman.com/downloads/) ```APP``` 


### Clonando o repositório:

```bash
$ git clone https://github.com/leandrolldavid/CentralDeErros.git
```
## Diagramas

Representação visual das classes da aplicação e das tabelas do banco de dados.

#### Classe

<img src="https://github.com/leandrolldavid/CentralDeErros/blob/fe91849b52bea58eae677a5a13affa9f89e6784a/assets/DiagramaDeClasseRefeito.png" alt="Imagem representando as classes da aplicação">

#### Banco de Dados

<img src="https://github.com/leandrolldavid/CentralDeErros/blob/fe91849b52bea58eae677a5a13affa9f89e6784a/assets/BD.png" alt="Imagem representando as tabelas do banco de dados">

## Desenvolvedor

- [Leandro David](https://github.com/leandrolldavid) 

## Front-end

Para simular o fornt-and usaremoso o Postman.

## Tabela de Endpoints

| Endpoints | verbo | Resposta|
| :--- | :--- | :--- |
| localhost:5000/api/Logs/listar | GET | Retornar todos os logs|
| localhost:5000/api/Logs/ordernaPorLevel | GET | Retornar logs ordernado por Level|
| localhost:5000/api/Logs/ordernaPorFrequencia | GET | Retornar logs ordernado por frequência|
| localhost:5000/api/Logs/log/{id} | GET | Retornar o log|
| localhost:5000/api/Logs/setor/{id} | GET | Retornar logs ordernado por setor|
| localhost:5000/api/Logs/cadastrar | POST | Cadastrar o log|
| localhost:5000/api/Logs/{id} | DELITE | Apagar o registro do log  |
| localhost:5000/api/Logs | UPDATE | Atualizar o registro do log no sistema |
| localhost:5000/api/Logs/arquivar | UPDATE | Arquivar o registro do log | 
| localhost:5000/api/User/login | POST | Retornar o token|
| localhost:5000/api/User/{id} | GET | Retornar o usuario|
| localhost:5000/api/User/listar | GET | Retornar todos os usuario|
| localhost:5000/api/User/cadastrar | POST | Cadastrar o usuario|
| localhost:5000/api/User/{id} | DELITE | Apagar o registro do usuario  |
| localhost:5000/api/User | UPDATE | Atualizar o registro do usuario no sistema |
| localhost:5000/api/User/permissao | UPDATE | Cadastra permissão ao usuário |
| localhost:5000/api/Setor/cadastrar | POST | Cadastrar o setor|
| localhost:5000/api/Setor/listar | GET | Retornar todos os setores|
| localhost:5000/api/Setor/log/{id} | GET | Retornar o setor|
| localhost:5000/api/Setor/{id} | DELITE | Apagar o registro do setor  |
| localhost:5000/api/Setor | UPDATE | Atualizar o registro do setor no sistema |
| localhost:5000/api/TipoLog/cadastrar | POST | Cadastrar o tipolog|
| localhost:5000/api/TipoLog/{id} | GET | Retornar o tipolog|
| localhost:5000/api/TipoLog/listar | GET | Retornar todos os tipolog|
| localhost:5000/api/TipoLog/{id} | DELITE | Apagar o registro do tipolog  |
| localhost:5000/api/TipoLog | UPDATE | Atualizar o registro do tipolog no sistema |


## Endpoints

Após executar a aplicação, você pode acessar os endpoints implementados, com o uso do ```Postman``` no endereço ```http://coloque aqui o endpont```.
