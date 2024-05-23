using System;
namespace Activity
{
    class Program
    {
        static void Main(string[] args)
        {
            float val_pag;
            Console.WriteLine("Informar Nome");
            string var_name = Console.ReadLine();
            Console.WriteLine("Informar Endereço");
            string var_address = Console.ReadLine();
            Console.WriteLine("Pessoa Física (f) ou Jurídica (j) ?");
            string var_type = Console.ReadLine();
            if (var_type == "f")
            {
                // --- Pessoa Física ----
                FisicalPerson pf = new FisicalPerson();
                pf.name = var_name;
                pf.address = var_address;
                Console.WriteLine("Informar CPF:");
                pf.cpf = Console.ReadLine();
                Console.WriteLine("Informar RG:");
                pf.rg = Console.ReadLine();
                Console.WriteLine("Informar Valor de Compra:");
                val_pag = float.Parse(Console.ReadLine());
                pf.PayTaxes(val_pag);
                Console.WriteLine("-------- Pessoa Física ---------");
                Console.WriteLine("Nome ..........: " + pf.name);
                Console.WriteLine("Endereço ......: " + pf.address);
                Console.WriteLine("CPF ...........: " + pf.cpf);
                Console.WriteLine("RG ............: " + pf.rg);
                Console.WriteLine("Valor de Compra: " +
                pf.value.ToString("C"));
                Console.WriteLine("Imposto .......: " +
                pf.value_taxes.ToString("C"));
                Console.WriteLine("Total a Pagar : " +
                pf.total.ToString("C"));
            }
            if (var_type == "j")
            {
                // Pessoa Jurídica
                JuridicalPerson pj = new JuridicalPerson();
                pj.name = var_name;
                pj.address = var_address;
                Console.WriteLine("Informar CNPJ:");
                pj.cnpj = Console.ReadLine();
                Console.WriteLine("Informar IE:");
                pj.ie = Console.ReadLine();
                Console.WriteLine("Informar Valor de Compra:");
                val_pag = float.Parse(Console.ReadLine());
                pj.PayTaxes(val_pag);
                Console.WriteLine("-------- Pessoa Jurídica ---------");
                Console.WriteLine("Nome ..........: " + pj.name);
                Console.WriteLine("Endereço ......: " + pj.address);
                Console.WriteLine("CNPJ ..........: " + pj.cnpj);
                Console.WriteLine("IE ............: " + pj.ie);
                Console.WriteLine("Valor de Compra: " +
                pj.value.ToString("C"));
                Console.WriteLine("Imposto .......: " +
                pj.value_taxes.ToString("C"));
                Console.WriteLine("Total a Pagar : " +
                pj.total.ToString("C"));
            }
        }
    }
}