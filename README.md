# BleutradeOperator
### A cryptocurrency trading robot 

BleutradeOperator is a platform for trading strategies in [Bleutrade](http://www.bleutrade.com). The output is a Console Application (which becomes it lighter) and interacts with Bleutrade's API using [RestSharp](http://restsharp.org). 

####Projects

This solution has the following projects:

- **BleutradeOperator**: Console Application. It's here where you're going to change the strategy you're going to use.
- **BleutradeOperator.Consts**: It's here where you'll set the values of your API key and secret (obviously, my API key and secret aren't written there lol). 
- **BleutradeOperator.Controller**: Stores the API interation methods (buy/sell operations or retrieving market data, for example).
- **BleutradeOperator.Model**: Model classes, which are used on response from API.
- **BleutradeOperator.Operations**: You can create your own strategy here, in a class. As an example, there's one strategy (Gustavos Strategy), which consists of buying based on user's story and selling with a 2% difference.
- **BleutradeOperator.Request**: Request classes.
- **BleutradeOperator.Response**: Response classes.

---

### Um robô criado para trading de criptomoedas.

A ideia do BleutradeOperator é ser uma plataforma para criação de estratégias para trading de criptomoedas no [Bleutrade](http://www.bleutrade.com). O robô é um Console Application (com o objetivo de tornar o output de dados o mais leve possível) que interage com a API do Bleutrade utilizando o [RestSharp](http://restsharp.org). 

####Partes

O projeto é dividido nas seguintes partes:

- **BleutradeOperator**: Parte relativa à aplicação de console. Quando você criar sua própria estratégia, é aqui que você muda qual estratégia vai ser usada.
- **BleutradeOperator.Consts**: Contém a classe onde o usuário deve colocar api key e api secret (obviamente essa classe não contém os meus dados hehe). 
- **BleutradeOperator.Controller**: Armazena os métodos de interação com API (métodos que retornam moedas disponíveis ou para lançar uma ordem de compra, por exemplo).
- **BleutradeOperator.Model**: Armazena as classes de domínio, relativas às respostas dos comandos do Controller.
- **BleutradeOperator.Operations**: Essa é a parte onde você pode criar sua própria estratégia em uma classe. A estratégia que está lá, como um exemplo, usa do próprio histórico do usuário para comprar moedas e vende com uma diferença de 2%.
- **BleutradeOperator.Request**: Classes de requisição.
- **BleutradeOperator.Response**: Classes de resposta.
