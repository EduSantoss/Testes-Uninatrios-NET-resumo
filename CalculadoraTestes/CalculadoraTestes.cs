using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTestes
{
    private CalcuradoraImp _calc; // referenciando o projeto de fora

    public CalculadoraTestes()
    {
        _calc = new CalcuradoraImp();
    }

    [Fact]
    public void DeveSomar5Com10ERetornar15()
    {
        // Arrange: montando cenário
        int num1 = 5;
        int num2 = 10;

        // Act: executando o cenário
        int resultado = _calc.Somar(num1, num2);

        // Assert: validar se ocorreu o esperado
        Assert.Equal(15, resultado);   // -> 1 parametro: resultado esperado, 2 parametro: resultado atual

    }

    [Fact]
     public void DeveSomar10om10ERetornar20()
    {
        // Arrange: montando cenário
        int num1 = 10;
        int num2 = 10;

        // Act: executando o cenário
        int resultado = _calc.Somar(num1, num2);

        // Assert: validar se ocorreu o esperado
        Assert.Equal(20, resultado);   // -> 1 parametro: resultado esperado, 2 parametro: resultado atual
    }

    [Fact]
    public void DeveVerificarSe4EhParERetornarVerdadeiro()
    {
        // Arrange
        int numero = 4;

        // Act
        bool resultado = _calc.EhPar(numero);

        // Assert
        Assert.True(resultado);
    }

    [Theory]
    [InlineData(new int[] { 2, 4})]
    [InlineData(new int[] { 6, 8, 10})]  
    public void DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(int[] numeros)
    {
        // Arrange - > nesse caso não precisa do arrange, ou seja, do cenário.
        
        // Act  // Assert
        foreach (var item in numeros)
        {
            Assert.True(_calc.EhPar(item));     // -> Poderia ser feito assim
        }

        // Em uma única linha
        Assert.All(numeros, num => Assert.True(_calc.EhPar(num)));
        
    }
}