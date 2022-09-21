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
Entre na pasta do projeto, onde está o arquivo `docker-compose.yaml` e então use o seguinte comando para executar o projeto
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

`docker-compose up` criará os containers especificados no arquivo `docker-compose.yaml` e os inicializará.


Após os containers serem criados, use um programa como `Postman` ou `Insomnia` para fazer as requisições http.
Uma vez com o Insomnia ou Postman aberto, vá até a url [http://localhost:5000/Users](http://localhost:5000/Users) para interagir com a api rest.

## Testes Unitários
O projeto possui testes unitários para garantir uma maior qualidade do sistema, ficando assim mais fácil a detecção de possíveis bugs. Para executar os testes, use o seguinte comando no terminal:

```
dotnet test
```

![Captura de tela de 2022-08-29 18-20-14](https://user-images.githubusercontent.com/76739275/188008038-04d78f03-e14d-4553-857a-2a418d1b6c4b.png)


## Logs
As requisições de http `Post`, `Put` e `Delete` geram logs que ficam salvos na pasta `/logs`, na raiz do projeto.
Caso precise alterar o local onde os logs ficam salvos, abra o arquivo `docker-compose.yaml`, e altere o volume do serviço de nome `api`
```
volumes:
      - ./logs:/app/logs
```
Por exemplo, caso tenha criada uma pasta de nome `arquivos-de-log` na raiz do projeto e queria salvar os logs nele, o volume ficará assim:
```
volumes:
      - ./arquivos-de-log:/app/logs
```

O nome antes do símbolo `:` refere-se ao nome da pasta na sua máquina, já o nome depois dele refere-se ao local no container docker, onde a api rest está rodando.
Caso queira mudar o local onde os logs ficam salvos dentro do container docker, abra o arquivo `Program.cs`, que está no caminho `Clients.API/Program.cs` e altere a string do método `WriteTo.File("/caminho-para-o-arquivo/nome-do-arquivo.txt")`

```
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("/app/logs/api_log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

```
Se você alterar o método `WriteTo.File`, precisará alterar o volume no arquivo docker-compose.yaml para que os arquivos de log gerados apareçam na pasta na sua máquina

## Demo
[Vídeo](https://www.youtube.com/watch?v=5I7t0YMT5vk) com demo do projeto


## Imagens de Exemplo
- Adicionando um usuário novo


![adicionando](https://user-images.githubusercontent.com/76739275/188004200-e4406285-c0af-471a-a041-0189b85e74c9.png)

- Buscando todos os usuários 

![verificando](https://user-images.githubusercontent.com/76739275/188004348-049eb6e5-b8c6-40d5-bb5c-7706fc58b22b.png)

- Editando um usuário
![Captura de tela de 2022-08-29 17-57-15](https://user-images.githubusercontent.com/76739275/188004589-5e9b3a35-fcb4-4c14-90c7-b5326044b3de.png)

- Removendo um usuário
![Captura de tela de 2022-08-29 18-02-26](https://user-images.githubusercontent.com/76739275/188004719-fcd0a2f4-5f7f-4a74-8bf5-2ae6ff00b2d0.png)

## Aplicativo Mobile
Versão mobile da aplicação para a plataforma android.
### Tecnologias utilizadas
- Xamarin.Forms

O aplicativo mobile consome os dados da api rest através de requisições http.

### Como executar o aplicativo

Para executar o aplicativo mobile é necessário o `Visual Studio` com suporte a desenvolvimento mobile.
Certifiquese-se de que a aplicação asp.net core  e o banco de dados estão rodando em containers docker, e então vá até a aba `depurar` do Visual Studio e clique para executar o projeto.

### Imagens

#### Menu
![Captura de Tela (13)](https://user-images.githubusercontent.com/76739275/190729319-925ed63b-c8b5-4647-8dbc-1dd8f804c801.png)

#### Buscando todos os usuários
![Captura de Tela (14)](https://user-images.githubusercontent.com/76739275/190729371-1ff031d5-0f38-4de4-ac3d-b856e9f4ee93.png)

#### Criando um usuário novo
![Captura de Tela (15)](https://user-images.githubusercontent.com/76739275/190729484-93e93895-bc54-48d5-9e3d-24553c974aea.png)

#### Buscando usuário por id
![Captura de Tela (16)](https://user-images.githubusercontent.com/76739275/190729506-193528e2-c624-4424-bca3-1c0e78a5718d.png)
![Captura de Tela (17)](https://user-images.githubusercontent.com/76739275/190729571-122536ed-7b33-4c0e-a247-d3f1e6b153d2.png)

#### Atualizando os dados de um usuário
![Captura de Tela (18)](https://user-images.githubusercontent.com/76739275/190729585-57859ddf-3fb6-4fb2-a751-27f84fac09bf.png)
![Captura de Tela (19)](https://user-images.githubusercontent.com/76739275/190729649-9f55b7d0-8eaf-4450-83d7-3ad11a1d1b9b.png)


#### Removendo um usuário
![Captura de Tela (20)](https://user-images.githubusercontent.com/76739275/190729692-f12d1f16-5435-410e-915f-4e51ec74ce5b.png)

![Captura de Tela (21)](https://user-images.githubusercontent.com/76739275/190729703-ecb1c375-96ff-4ec4-9aa5-ad7a966efe2a.png)

