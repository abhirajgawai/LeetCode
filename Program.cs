// See https://aka.ms/new-console-template for more information
using LeetCode.BAM;
using Microsoft.Extensions.DependencyInjection;

public class Progam
{
    public static void Main()
    {
        var service = new ServiceCollection();
        service.AddScoped<IBAM, BAM>();

        var provider = service.BuildServiceProvider();
        var bam = provider.GetRequiredService<IBAM>();
        bam.MoveZeros();
    }
}
