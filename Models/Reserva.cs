namespace DesafioProjetoHospedagem.Models
{
 public class Reserva
 {

  public Reserva() { }
  public List<Pessoa> Hospedes { get; set; }
  public Suite Suite { get; set; }
  public int DiasReservados { get; set; }

  public Reserva(int diasReservados)
  {
   DiasReservados = diasReservados;
  }

  public void CadastrarHospedes(List<Pessoa> hospedes)
  {
   Hospedes = (hospedes.Count <= Suite.Capacidade) ? hospedes : throw new Exception($"A quantidade máxima de pessoas que podem ser hospedadas nesta suite é de: {Suite.Capacidade}");
  }

  public void CadastrarSuite(Suite suite)
  {
   Suite = suite;
  }

  public int ObterQuantidadeHospedes()
  {
   return Suite.Capacidade;
  }

  public static decimal CalcularDesconto(decimal valor, decimal desconto) => valor - (valor * desconto / 100);


  public static decimal CalcularValorDiaria(Reserva reserva)
  {

   decimal valorDiaria = reserva.DiasReservados * reserva.Suite.ValorDiaria;
   return (reserva.DiasReservados >= 10) ? CalcularDesconto(valorDiaria, 10) : valorDiaria;
  }
 }
}
