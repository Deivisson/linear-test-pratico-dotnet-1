# Desafio Linear Sistemas - Processo Dev BackEnd dotNet

O objetivo desta atividade é avaliar conhecimentos práticos na plataforma dotNet. Abaixo instruções para execução:

## Tecnologias a serem utilizadas:

1 - dotnetCore | .net Framework

2 - Banco de dados (Qualquer um Relacional ou qualquer recurso InMemory)

3 - Entity Framework - Opcional

## Especificações

#### User Case
Eu como desenvolvedor do front-end, preciso ter acesso à recursos (rotas/endpoints) para cadastrar Canais de Vendas e Produtos, para o segmento do varejo.

#### Objetivo
Criar uma aplicação que entregue "CRUDs" básicos, apenas API's, para realizar os cadastros citados acima. Obs: Para fins de testes usar algum REST Client, ex: Postman

#### Implementação
1 - Criar rotas para Inclusão e Listagem de Canais de Vendas:
- POST /canais-vendas
- GET /canais-vendas
    
        Payload para POST:
            { "descricao": "" }

        Response para o GET:
            [
                {
                    "id": 0,
                    "descricao": ""
                },
                {
                    "id": 0,
                    "descricao": ""
                }
            ]

2 - Criar rotas para Inclusão, GET e Pesquisa de Produtos:
- POST /produtos
- GET /produtos/{id}
- GET /produtos/pesquisa?descricao=''

        Payload para POST:
        { "descricao": "", "canaisVendasIds": [] }

        Response para o GET:
            { 
                "id": 0, 
                "descricao": "", 
                "canaisVendas":[{"id": 0, "desricao": ""}] 
            }
        
        Response para o GET da pesquisa:
            [{
                "id": 0, 
                "descricao": "", 
                "canaisVendas":[{"id": 0, "desricao": ""}] 
            },{ 
                "id": 0, 
                "descricao": "", 
                "canaisVendas":[{"id": 0, "desricao": ""}] 
            }]
        
#### Regras de negócio
- Canais de Vendas:
  - Campo descrição deve possuir comprimento mínimo de 5 e máximo 20 caracteres. Sendo assim, automaticamente não poderá ser nulo


- Produtos:
  - Campos descrição deve possuir comprimento mínimo de 3 e máximo 50 caracteres. Sendo assim, também não pode ser nulo
  - Um produto deverá estar vinculado a 1 ou mais canais de vendas. Ou seja, também possui preenchimento obrigatório
  - A rota de pesquisa, deverá permitir pesquisar produtos pela descrição, mas não é obrigatório. A passagem do parâmetro para filtragem será via queryParams "?descricao=''"

#### Material de Apoio
- Exemplos de Canais de Vendas
  - Balcão (É quando o cliente vai na loja física)
  - E-Commerce
  - Televendas

- Exemplos de Produtos
   - Coca-Cola: Vendidos via Balcão, E-Commerce e Televendas
   - Cerveja: Vendidos via Balcão e E-Commerce 
   - Pão Francês: Vendidos somente via Balcão
   

#### Observações
- IMPORTANTE: Entregar o desafio com a documentação dos passos a serem seguidos para executar o projeto localmente

- Você tem total liberdade para estruturar o projeto da forma que achar melhor.

- O Projeto pode ser desenvolvimento em qualquer plataforma: Windows, Linux, MacOs e qualquer Editor/IDE (VsCode, Visual Studio) 

- Cobertura de testes automatizados para garantir as regras de negócios são importantes.


Bom Trabalho. :-)

### Instruções
- docker compose -f "docker-compose.debug.yml" up -d --build 
    - run pasta raiz
    - Docker instalado

### Local Swagger
- http://localhost:8081/swagger/index.html




