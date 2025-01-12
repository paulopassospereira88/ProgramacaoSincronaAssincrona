Console.WriteLine("\nIniciando a operacao assincrona...");

await MetodoSemRetornoAsync();

Console.WriteLine("\nIniciando a operacao assincrona...");

var result = await MetodoRetornoValorAsync(20);
Console.WriteLine(result);

Console.ReadKey();

static async ValueTask MetodoSemRetornoAsync()
{
    Console.WriteLine("-Metodo que nao retorna valor");
    await Task.Delay(2000);
}

static async ValueTask<int> MetodoRetornoValorAsync(int valor)
{
    Console.WriteLine("-Metodo que retorna valor");
    await Task.Delay(2000);
    return valor * 2;
}