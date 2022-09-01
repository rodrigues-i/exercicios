# Sistema Para Cadastrar Usuários
Projeto criado para permitir o cadastro do usuário ao sistema

## Tecnologias usadas
Este projeto foi feito com as seguintes tecnologias:
- Asp.net Core
- Entity Framework Core
- Docker
- Docker compose
- Imagem docker do banco de dados mariadb
- XUnit
- Moq
- FluentAssertions


## Requisitos
Para rodar este projeto, é necessário ter instalados na sua máquina os seguintes programas
- Docker
- Docker Compose

## Como executar este projeto
Use o seguinte comando para executar este projeto
```
docker-compose up
```
Para parar a excução, utilize o comando:
`
Ctrl + C
`
ou, em outro terminal aberto no mesmo caminho:
```
docker-compose stop
```

Esse comando criará os containers especificados no arquivo `docker-compose.yaml` e os inicializará.


Após os containers serem criados, use um programa como `postman` ou `insominia` para fazer as requisições.
Uma vez com o insomia ou postman aberto, vá para a url [http://localhost:5000/Users](http://localhost:5000/Users) para interagir com a api rest.

## Testes Unitários
O projeto possui testes unitários para garantir uma maior qualidade no sistema, ficando assim mais fácil a constatação de possíveis bugs bugs. Para executar os testes, use o seguinte comando no terminal:

```
dotnet test
```

![Captura de tela de 2022-08-29 18-20-14](https://user-images.githubusercontent.com/76739275/188008038-04d78f03-e14d-4553-857a-2a418d1b6c4b.png)



## Demo
[Vídeo](https://www.youtube.com/watch?v=5I7t0YMT5vk) com demo do projeto


## Exemplos
- Adicionando um usuário novo


![adicionando](https://user-images.githubusercontent.com/76739275/188004200-e4406285-c0af-471a-a041-0189b85e74c9.png)

- Buscando todos os usuários 

![verificando](https://user-images.githubusercontent.com/76739275/188004348-049eb6e5-b8c6-40d5-bb5c-7706fc58b22b.png)

- Editando um usuário
![Captura de tela de 2022-08-29 17-57-15](https://user-images.githubusercontent.com/76739275/188004589-5e9b3a35-fcb4-4c14-90c7-b5326044b3de.png)

- Removendo um usuário
![Captura de tela de 2022-08-29 18-02-26](https://user-images.githubusercontent.com/76739275/188004719-fcd0a2f4-5f7f-4a74-8bf5-2ae6ff00b2d0.png)
