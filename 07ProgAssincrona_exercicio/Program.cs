await ExecutaOperacaoAsync();

Console.ReadKey();

static async Task ExecutaOperacaoAsync()
{
    // Criar um CancellationTokenSource
    var temp = 10;
    var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(temp));

    Console.WriteLine("\nIniciando download...");
    Console.WriteLine($"\nCancelando a operacao apos {temp} segundos...");

    try
    {
        using var httpCliente = new HttpClient();
        var destino = "C:\\Users\\paulo\\Documents\\development\\dados";

        var response = await httpCliente.GetAsync("https://www.macoratti.net/dados/Poesia.txt", 
            HttpCompletionOption.ResponseHeadersRead,
            cancellationTokenSource.Token);

        var totalBytes = response.Content.Headers.ContentLength;
        var readBytes = 0L;

        await using var fileStream = new FileStream(destino, FileMode.Create, FileAccess.Write);

        await using var contentStream = await response.Content.ReadAsStreamAsync(cancellationTokenSource.Token);

        var buffer = new byte[81920];
        int bytesRead;

        while((bytesRead = await contentStream
            .ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token)) > 0)
        {
            await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationTokenSource.Token);
            readBytes += bytesRead;
            Console.WriteLine($"Progresso: {readBytes} / {totalBytes}");
        }
    }
    catch(OperationCanceledException e)
    {
        if (cancellationTokenSource.IsCancellationRequested)
        {
            Console.WriteLine("\nDownloads cancelada por tempo limite : " + e.Message);
        }
        else
        {
            Console.WriteLine("\nO tempo limite para o download foi atingido.");
        }
    }
    catch(HttpRequestException e)
    {
        Console.WriteLine($"\nOcorreu um erro de rede: {e.Message}");
    }
    catch(Exception e)
    {
        Console.WriteLine($"\nOcorreu um erro desconhecido: {e.Message}");
    }
    finally
    {
        Console.WriteLine("\nDownload finalizado.");
    }
}
