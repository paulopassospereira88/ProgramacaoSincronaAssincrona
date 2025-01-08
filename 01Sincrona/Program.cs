Console.WriteLine("### Programacao Sincrona ###");

int espera = 4000;

Console.WriteLine("Tecle algo para iniciar");
Console.ReadLine();

RealizarTarefa(espera);

Console.WriteLine($"\nTempo gasto {espera / 1000} segundos");
Console.WriteLine("\n### Fim do processamento");

Console.ReadKey();

static void RealizarTarefa(int tempo)
{
    Console.WriteLine("\n>>> Iniciando a tarefa...");
    //Task.Delay(TimeSpan.FromSeconds(tempo));
    Thread.Sleep(tempo);
    Console.WriteLine(">>>Tarefa concluida.");
}