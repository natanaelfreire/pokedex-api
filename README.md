# pokedex-api

## Tecnologias utilizadas
* .NET versão 6
* Entity Framework Core
* SQLite como banco local

## Funcionalidades
* Buscar Pokemon por nome
* Buscar Pokemons aleatórios
* Criar, ler, editar e excluir Mestres Pokemon
* Mestre Pokemon pode capturar Pokemon
* Listar Pokemons capturados

## Como testar
Baixe o código com o comando "git clone https://github.com/natanaelfreire/pokedex-api.git"

Entre na pasta pokedex-api e execute o comando "dotnet run", ou abra o arquivo PokedexApi.csproj com o Visual Studio e execute o projeto

Abra o navegador com o link "https://localhost:{porta-gerada}/swagger substituindo {porta-gerada} pela porta que foi gerada pelo dotnet

Execute alguma rota no Swagger para testar.

## Rotas API
### Rotas para Mestre Pokemon
<code>POST</code> - <code>/api/v1/MestrePokemon</code> - <i>cria mestre pokemon</i>

```json
{
  "id": 0,
  "nome": "string",
  "idade": 0,
  "cpf": "string"
}
```

<code>GET</code> - <code>/api/v1/MestrePokemon</code> - <i>lista todos mestres pokemons</i>

<code>POST</code> - <code>/api/v1/MestrePokemon/CapturaPokemon</code> - <i>captura pokemon para um mestre pokemon</i>

```json
{
  "mestreId": 0,
  "pokemonName": "string"
}
```

<code>GET</code> - <code>/api/v1/MestrePokemon/{id}</code> - <i>lista dados específicos de um mestre pokemon</i>

<code>GET</code> - <code>/api/v1/MestrePokemon/{id}/Pokemons</code> - <i>lista pokemons capturados de um mestre pokemon</i>

<code>PUT</code> - <code>/api/v1/MestrePokemon</code> - <i>edita dados de um mestre pokemon</i>

```json
{
  "id": 0,
  "nome": "string",
  "idade": 0,
  "cpf": "string"
}
```

<code>DELETE</code> - <code>/api/v1/MestrePokemon/{id}</code> - <i>exclui um mestre pokemon</i>

### Rotas para Pokemon
<code>GET</code> - <code>/api/v1/Pokemon/{name}</code> - <i>buscar dados de um pokemon por nome</i>

<code>GET</code> - <code>/api/v1/Pokemon/Random?qtd={qtd}</code> - <i>buscar uma quantidade {qtd} de pokemons aleatórios</i>
