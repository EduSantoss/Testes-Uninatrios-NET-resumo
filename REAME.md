<h1>DIO | Resumo Testes unitários com .NET - Modulo 5</h1>

-> Aprender os principais conceitos de testes unitários, seu objetivo e sua importância em qualquer projeto, independente de seu tamanho.
<br>
[Digital Innovation One](https://www.dio.me/en)

## 📚 Documentação 
- [Documentação .NET](https://git-scm.com/doc)
- [Documentação C#](https://docs.github.com/pt)
- [Documentação xUnit](https://xunit.net/)

## 💻 Resumos das Aulas

| Aulas | Resumos |
|-------|---------|
| Resumo sobre Testes Unitários | [Resumos]() |

### Teste

->> Conceito altamente ligado a qualidade do software.

-> Existem vários tipos de testes de software: unitários, integração, regressivo, segurançã, etc...

-> Os teste são fundamentais para garantir a qualidade e o correto funcionamento de um software.

-> Serve principalmente para validar se o que foi construído está atendendo ao que se é esperado.

-> Maneira que o desenvolvedor faz o teste é diferente da maneira que o cliente fará o teste.

->>> Garantir que o foi escrito está funcionando de maneira correta.

-->> Qualidade é inegociável <<--

### Teste Unitário

-> Também conhecido como teste de unidade.

-> São testes realizados diretamente no código fonte, buscando testar a menor unidade de código possível, através de cenários que podem ocorrer no sistemas.

-> Exemplo: Construida classe calculadroa com um método somar, que deve realizar uma soma 2 + 2 = 4. Então vamos construir outro código que chama esse método de soma e garanta que o que é passada está tendo o valor esperado.

-> Buscar prever o máximo de cenários possíveis, testando a menor unidade de código possível.

-> Exemplo: Um usuário do sistema só é cadastrado se possuir um CPF e um email válido. Caso contrário, retornará um erro indicando o que está errado.

```
Baseado no cenário acima
"Cadastrado"
"CPF"
"E-mail válido"

Possíveis testes: 
- Usuário com todos os dados válidos
- Usuário com CPF inválido
- Usuário com E-mail inválido
```

#### Vantagens

->>> Aumentar meu profissionalismo ao utilizar testes.

->>> Garantir que as alterações não tenham impactos no sistema.

-> Exemplo: Estou dando manutenção em um sistema financeiro com mais de 1000 linhas de código, uma função bem complexa. Meu objetivo é incluir 5 linhas de códigos, consigo garantir que o escrito nessas linhas está funcionando, mas para isso preciso escrever um cenário baseado nas 1000 linhas, ou seja, antes de entregar o commit, vamos usar os teste já feitos nas 1000 linhas, para garantir que a parte nova não afeta em nada.

-> Seguindo o raciocinio acima, precisaria escrever meus teste para essas 5 linhas, para que a próxima pessoa que tivesse que adicionar algo, pudesse usar todo essa gama de testes para garantir também que não está quebrando o código.

->>> Menos bugs.

-> Exemplo: Validando  CPF, testou só com um CPF e passou, mas ao testar com um CPF unitário identificamos uma falha, assim podemos identificar falhas que não eram nem esperadas.

->>> Maior confiança de que suas classes e métodos funcionam.

-> Ou seja, maior confiança de que o que foi feito está funcionando.

-> Importante para o próximo desenvolvedor saber mexer e ter segurança para não ter problemas ao atualizar o código.

->>> Prevenir problemas futuros.

### Frameworks de Teste

-> Alguns são: MSTest, NUnit, xUnit.

-> Iremos utilizar o xUnit um dos mais amplamente atualizadas e com mais documentações.

```
                   Solution (.sln)
                          |
                       /     \
                    /           \        
     Calculadora (.csproj)  <<-- CalculadoraTests (.csproj)
```

### Criando Projeto

-> Criar pastas diferentes Calculadora e CalculadoraTestes

```
Dentro da pasta Calculadora executar
-> dotnet new console

Agora dentro da pasta CalculadoraTestes executar
-> dotnet new xunit
```

-> Fazer o processo de criação da solution, adicionar os dois projetos e referenciar eles.

-> Clicar em cima do desejado com botão direito e adicionar referência, fazer isso no de Testes.

#### Pegando Erros

-> Classe CalculadoraImp

```
namespace Calculadora.Services
{  
    public class CalcuradoraImp
    {
       public int Somar(int num1, int num2)
       {
           return num1 + num2 + 1;     -> Digamos que na linha 700 tivesse esse erro com calculo            
       }                                  para isso precisamos de testes.
    }
}

Program.cs
Console.WriteLine($"{num1} + {num2} = {c.Somar(num1, num2)}");  -> Devido ao erro acima o retorno seria 5 + 10 = 16
                                                                   o que é um erro.
```

### Criando a Classe Teste

-> Padrão de escrita é: o queremos testar + teste no final.

-> Classe CalculadoraTestes criada.

-> Separar as classes de testes, cenários diferentes.

-> Anotação [Fact] vinda do xUnit, que significa que o método a seguir é um cenário de testes e deve ser validado de acordo, valida apenas um cenário por vez.

-> Nome do método deve ser descritivo e que possa passar claramente o que está fazendo.

``` 
 --> Metodologia válida e prática para ajudar a escrever o método 

 // Arrange  ->  Serve para montar o cenário, no caso, somar 5 com 10    
 // Act      -> Agir, chamar o cenário, a ação somar
 // Assert   -> Validar se o que foi feito retornou o esperado, no caso 15
```

Método de teste Completo
```
 [Fact]
    public void DeveSomar5Com10ERetornar15()   -> como deve ser o nome
    {
        // Arrange: montando cenário
        int num1 = 5;
        int num2 = 10;

        // Act: executando o cenário
        int resultado = _calc.Somar(num1, num2);

        // Assert: validar se ocorreu o esperado
        Assert.Equal(15, resultado);   // -> 1 parametro: resultado esperado, 2 parametro: resultado atual

    }
```
-->> Podemos implementar vários cenários de testes para o mesmo método
```
 [Fact]
    public void DeveSomar10Com10ERetornar20()   
    {
        // Arrange: montando cenário, passando tudo necessário para realizar o teste
        int num1 = 10;
        int num2 = 10;

        // Act: executando o cenário
        int resultado = _calc.Somar(num1, num2);

        // Assert: validar se ocorreu o esperado
        Assert.Equal(20, resultado);   

    }
```

-->> Cuidado para o erro não está no próprio teste, ele ser construído errado e apontar erro onde está correto.

Executando teste:
```
Entrar na pasta CalculadoraTestes e executar

-> dotnet test
```

->> Se tivermos 1000 cálculos com 1000 testes unitários, ele vai executar e apontar se algum deu erro, e onde foi o erro.

### Testando o Cenário de erro 

-> Colocar erro no método somar da classe CalculadoraImp.

-> Executar testes.

```
  public int Somar(int num1, int num2)
       {
           return num1 + num2 + 1;
       }

AVISO

Error Message:
   Assert.Equal() Failure
Expected: 15
Actual:   16
  Stack Trace:
     at CalculadoraTestes.CalculadoraTestes.DeveSomar5Com10ERetornar15() in C:\Users\Laura\Desktop\Testes-Unitarios-NET\CalculadoraTestes\CalculadoraTestes.cs:line 25

Failed!  - Failed:     1, Passed:     0, Skipped:     0, Total:     1, Duration: < 1 ms

```

### Implementando validações de String

-> Criando nova classe para validações de string, para testar e criar novos cenários de testes.

-> Criar outra classe de testes.

```
       [Fact]
        public void DeveContar3CaracteresEmOlaERetornar3()
        {
            // Arrenge
            string texto = "Ola";

            // Act
            int resultado = _validacoes.ContarCaracteres(texto);

            // Assert
            Assert.Equal(3, resultado); 
        }
```

### Verificando se um Número é Par

-> Criar método na classe CalculadoraImp

```
 public bool EhPar(int num)
       {
           return num % 2 == 0;
       }
```

-> Criar teste na classe CalculadoraTestes
```



Assert.Equal(true, resultado);  -> Até poderia ser assim, mas não é recomendado, pois vai comparar o bool com o
                                   resultado, para evitar de ficar (true, true)
melhor maneira 
Assert.True(resultado);
```

### Utilizando o Theory

-> Como passar diversos parametros para o teste sem ter que escrever grandes quantidades de código.

-> Se quiser validar no método do EhPar, para validar além do 4 que já foi validado, números 2, 4, 6, 8, 10

->> Evitar repetir código para testar cada número.

->> Também poderia repetir o Assert.True(resultado4) e Assert.True(resultado2), criando um bood a mais acima, mas também não é recomendado

```
    [Theory]              -> Notação Theory
    [InlineData(2)]       -> Cenários a serem testados, cada um é um teste a mais
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    public void DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(int numero)
    {
        // Arrange             --> nesse caso não precisa do arrange, ou seja, do cenário.
        
        // Act
        bool resultado = _calc.EhPar(numero);
        
        // Assert
        Assert.True(resultado);
    }
```

->> Também podemos refatorar esse método de teste para receber uma lista como parametro e não ter que incluir vários inlineData

->> O número de testes vai aparecer como menor, mas isso se deve ao fato de que agora estão em um array, mas a quantidade de testes realizadas ainda é a mesma.
```
    [Theory]
    [InlineData(new int[] { 2, 4})]
    [InlineData(new int[] { 6, 8, 10})]  
    public void DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(int[] numeros)
    {
        // Arrange - > nesse caso não precisa do arrange, ou seja, do cenário.
        
        // Act  // Assert
      //  foreach (var item in numeros)
      //  {
      //      Assert.True(_calc.EhPar(item));     // -> Poderia ser feito assim
      //  }

        // Maneira mais adequada, tudo em uma única linha.
        Assert.All(numeros, num => Assert.True(_calc.EhPar(num)));
        
    }
```

->> Caso um dos itens da coleção não passe nos testes
```
[xUnit.net 00:00:02.74]     CalculadoraTestes.CalculadoraTestes.DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(numeros: [6, 8, 1]) [FAIL]
  Failed CalculadoraTestes.CalculadoraTestes.DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(numeros: [6, 8, 1]) [9 ms]
  Error Message:
   Assert.True() Failure
Expected: True
Actual:   False
  Stack Trace:
     at CalculadoraTestes.CalculadoraTestes.DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(Int32[] numeros) in C:\Users\Laura\Desktop\Testes-Unitarios-NET\CalculadoraTestes\CalculadoraTestes.cs:line 66

Failed!  - Failed:     1, Passed:     5, Skipped:     0, Total:     6, Duration: 69 ms
```