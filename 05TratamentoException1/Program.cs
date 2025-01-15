TesteAsync t = new();
t.ChamaTarefaAsync();

Console.ReadKey();

class TesteAsync
{
    public Task MinhaTarefaAsync()
    {
        return Task.Run(() => {
            Task.Delay(2000);
            throw new Exception("Minha Exception...");
        });
    }

    public async void ChamaTarefaAsync()
    {
        try
        {
            await MinhaTarefaAsync();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
