await LancaMultiplasExcecoesAsync();

Console.ReadKey();

static async Task LancaMultiplasExcecoesAsync()
{
    Task? tarefas = null;
    try
    {
        var primeiraTask = Task.Run(() =>
        {
            Task.Delay(1000);
            throw new IndexOutOfRangeException("IndexOutOfRangeException lancada explicitamente.");
        });

        var segundaTask = Task.Run(() =>
        {
            Task.Delay(1000);
            throw new IndexOutOfRangeException("IndexOutOfRangeException lancada explicitamente.");
        });

        tarefas = Task.WhenAll(primeiraTask, segundaTask);
        await tarefas;
    }
    catch
    {
        Console.WriteLine("Ocorreram as seguintes excecoes :-\n");
        AggregateException TodasExceptions = tarefas.Exception;

        foreach(var ex in TodasExceptions.InnerExceptions)
        {
            Console.WriteLine(ex.GetType().ToString());
        }
    }
}