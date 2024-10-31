# Sistema de Gerenciamento de Biblioteca

Este sistema foi desenvolvido em ASP.NET MVC utilizando o .NET Framework 4.7.2. O objetivo da aplicação é gerenciar uma biblioteca com recursos para cadastro de livros, editoras, categorias e autores, além de permitir o controle de empréstimos de livros aos usuários. 

## Funcionalidades

- *Cadastro e edição de livros*: Permite adicionar, editar, excluir e visualizar livros.
- *Gerenciamento de editoras, categorias e autores*: É possível cadastrar, editar e listar editoras, categorias e autores associados aos livros.
- *Controle de empréstimos*: O sistema permite registrar o empréstimo e a devolução de livros.
- *Validações*: Uso de data annotations para validações de dados, como ISBN e ano de publicação.

## Estrutura do Projeto

A aplicação possui ao menos seis entidades principais, com relações do tipo 1:N e N:N, garantindo um modelo relacional robusto. As entidades principais incluem:

1. *Livro*: representa os livros disponíveis na biblioteca.
2. *Editora*: relaciona-se com o livro (1:N) para definir a editora de cada livro.
3. *Categoria*: relação N:N com o livro, permitindo que cada livro pertença a múltiplas categorias.
4. *Autor*: permite atribuir autores aos livros.
5. *Usuário*: representa os usuários cadastrados na biblioteca para efetuar empréstimos.
6. *Empréstimo*: permite registrar o histórico de empréstimos e devoluções de livros pelos usuários.

## Tecnologias Utilizadas

- *ASP.NET MVC* com .NET Framework 4.7.2
- *Entity Framework (Code First)* para mapeamento objeto-relacional e geração do banco de dados
- *SQL Server* como banco de dados
- *HTML, CSS e Bootstrap* para o layout e design responsivo
- *JavaScript* para funcionalidades adicionais na interface

## Configuração e Execução

### Pré-requisitos

- Visual Studio 2022 (Community ou superior)
- SQL Server ou SQL Server Express
- .NET Framework 4.7.2

### Passos para Configuração

1. *Clone o repositório*:
   ```bash
   git clone https://github.com/alyne770/A1.git
   
