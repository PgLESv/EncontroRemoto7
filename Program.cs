using System;
using System.Threading;
using System.Collections.Generic;


namespace ENCONTROREMOTO7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaFisica> listaPf = new List<PessoaFisica>();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@$"
=============================================
|    Bem vindo ao sistema de cadastro       |
|    de pessoa física e pessoa jurídica     |
=============================================
");
     
            BarraCarregamento("Iniciando");

            string? opcao;

            do
            {
                Console.WriteLine(@$"
=====================================
|   Escolha uma das opções abaixo   |
|           PESSOA FÍSICA           |
|   1 - Cadastrar Pessoa Física     |
|   2 - Listar Pessoa Física        |
|   3 - Remover Pessoa Física       |
|                                   |
|          PESSOA JURÍDICA          |
|   4 - Cadastrar Pessoa Jurídica   |
|   5 - Listar Pessoa Jurídica      |
|   6 - Remover Pessoa Jurídica     |
|                                   |
|           0 - Sair                |
=====================================
");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Endereco endPf = new Endereco();

                    Console.WriteLine($"Digite seu logradouro:");
                    endPf.logradouro = Console.ReadLine();

                    Console.WriteLine($"Digite o número:");
                    endPf.numero = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                    endPf.complemento = Console.ReadLine();

                    Console.WriteLine($"Este endereço é comercial? S/N");
                    string endComercial = Console.ReadLine().ToUpper();

                    if (endComercial == "S")
                    {
                        endPf.enderecoComercial = true;
                    }
                    else
                    {
                        endPf.enderecoComercial = false;
                    }

                    PessoaFisica novapf = new PessoaFisica();

                    Console.WriteLine($"Digite seu CPF (somente números)");
                    novapf.cpf = Console.ReadLine();

                    Console.WriteLine($"Digite seu nome:");
                    novapf.nome = Console.ReadLine();

                    Console.WriteLine($"Digite sua data de nascimento:");
                    novapf.dataNascimento = DateTime.Parse(Console.ReadLine());

                    PessoaFisica pf = new PessoaFisica();
                    // pf.ValidarDataNascimento(novapf.dataNascimento);

                    
                    bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);

                    if (idadeValida == true)
                    {
                        System.Console.WriteLine($"Cadastro Aprovado");
                        listaPf.Add(novapf);
                        Console.WriteLine($"Digite seu rendimento:");
                        novapf.rendimento = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Imposto a pagar: R$" + pf.PagarImposto(novapf.rendimento).ToString("N2"));
                    }
                    else
                    {
                        Console.WriteLine($"Cadastro Não Aprovado");
                    }

                    // Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
                    // Console.WriteLine("Rua: " + novapf.endereco.logradouro + ", " + novapf.endereco.numero);
                    break;

                case "2":
                    foreach (var cadaItem in listaPf)
                    {
                        Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.dataNascimento}");
                    }
                    break;

                case "3":
                    Console.WriteLine($"Digite o CPF que deseja remover:");
                    string cpfProcurado = Console.ReadLine();

                    PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);
                    if (pessoaEncontrada != null)
                    {
                        listaPf.Remove(pessoaEncontrada);
                        Console.WriteLine($"Cadastro Removido");
                    }
                    else
                    {
                        Console.WriteLine($"CPF não encontrado");
                    }
                    break;
                    
                case "4":
                    PessoaJuridica pj = new PessoaJuridica();

                    PessoaJuridica novapj = new PessoaJuridica();

                    Endereco endPj = new Endereco();

                    endPj.logradouro = "Rua Y";
                    endPj.numero = 120;
                    endPj.complemento = "Próximo ao Mercado";
                    endPj.enderecoComercial = true;

                    novapj.endereco = endPj;
                    novapj.cnpj = "01234567890123";
                    novapj.rendimento = 8000;
                    novapj.razaoSocial = "Pessoa Jurídica";

                    Console.WriteLine(pj.PagarImposto(novapj.rendimento).ToString("N2"));
                    

                    if (pj.ValidarCNPJ(novapj.cnpj))
                    {
                        Console.WriteLine("CNPJ Válido");
                    }
                    else
                    {
                        Console.WriteLine("CNPJ Inválido");
                    }
                    break;
                
                case "0":
                    Console.WriteLine($"Obrigado por utilizar o nosso sistema");
                    BarraCarregamento("Finalizando");
                    break;
                
                default:
                    Console.WriteLine($"Opção inválida, digite uma opção válida");
                    break;
            }
                
            } while (opcao != "0");
            
            static void BarraCarregamento(string textoCarregamento)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(textoCarregamento);
                Thread.Sleep(500);

                for (var contador = 0; contador < 10; contador++)
                {
                    Console.Write($".");
                    Thread.Sleep(500); 
                }
                Console.ResetColor();
            }
        }
    }
}