# Sistema Para Cadastrar Usuários


## Requisitos
Para rodar este projeto, é necessário ter instalados na sua máquina os seguintes programas
- Docker
- Docker Compose

## Como executar este projeto
Use o seguinte comando para executar este projeto
```
docker-compose up
```

Esse comando criará os containers especificados no arquivo `docker-compose.yaml` e os inicializará.


Aṕos os containers serem criados, use um programa como postman ou insominia para fazer as requisições.
Uma vez com o insomia ou postman aberto, vá para a url [http://localhost:5000/Users/](http://localhost:5000/Users) para interagir com a api rest.

## Exemplos
- Adicionando um usuário novo


![adicionando](https://user-images.githubusercontent.com/76739275/188004200-e4406285-c0af-471a-a041-0189b85e74c9.png)

- Buscando todos os usuários 

![verificando](https://user-images.githubusercontent.com/76739275/188004348-049eb6e5-b8c6-40d5-bb5c-7706fc58b22b.png)

- Editando um usuário
![Captura de tela de 2022-08-29 17-57-15](https://user-images.githubusercontent.com/76739275/188004589-5e9b3a35-fcb4-4c14-90c7-b5326044b3de.png)

- Removendo um usuário
![Captura de tela de 2022-08-29 18-02-26](https://user-images.githubusercontent.com/76739275/188004719-fcd0a2f4-5f7f-4a74-8bf5-2ae6ff00b2d0.png)
