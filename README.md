# ModeloMVC

# Introdução

Este repositório é um exemplo de uma aplicação com modelo padrão **MVC** com o [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Ferramenta
* SDK do .NET Core
```
Version:   6.0.400
Commit:    7771abd614
```
* ASP.NET Core
```
Version:      6.0.8
Commit:       55fb7ef977
```

### Editor de Código 
* [Visual Studio Code](https://code.visualstudio.com/)

### Métodos

O modelo MVC por padrão cria uma página contendo uma página inicial vazia e uma página de privacidade.

Um método de inserção de contatos utilizando o banco de dados [SQL Server 2019 Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) foi desenvolvido no modelo.

* O controlador do método Contato está disponível em [ContatoController](/Controllers/ContatoController.cs) e possui os procedimentos de:
  * Editar contato
  * Exibir detalhes do contato
  * Deletar contato
  
### Páginas
As páginas do modelo podem ser modificadas em [Views](/Views) e o layout principal se encontra em [_layout.cshtml](/Views/Shared/_Layout.cshtml)

### Aplicação
É necessária a conexão do banco de dados por meio de uma ConnectionStrings em [appsettings.json](appsettings.json). Com isso é possível observar a API pelo comando ``` dotnet watch run```
