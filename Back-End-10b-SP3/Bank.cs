using System.Data.SqlClient;

namespace WebLHPetsProject
{
    class Bank
    {
        private List<Clients> list = new List<Clients>();
        public List<Clients> GetList()
        {
            return list;
        }
        public Bank()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
                "User ID=sa;Password=12345;" +
                "Server=localhost\\SQLEXPRESS;" +
                "Database=sells;" +
                "Trusted_Connection=False;"
                );

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        conexao.Open();
                        using (SqlDataReader table = command.ExecuteReader())
                        {
                            while (table.Read())
                            {
                                list.Add(new Clientes()
                                {
                                    cpf_cnpj = table["cpf_cnpj"].ToString(),
                                    name = table["name"].ToString(),
                                    address = table["address"].ToString(),
                                    rg_ie = table["rg_ie"].ToString(),
                                    type = table["type"].ToString(),
                                    value = (float)Convert.ToDecimal(table["value"]),
                                    value_taxes = (float)Convert.ToDecimal(table["value_taxes"]),
                                    total = (float)Convert.ToDecimal(table["total"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public String GetStringList()
        {
            string send = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset='utf-8' />\n" +
                          "<title>Cadastro de Clientes</title>\n</head>\n<body>";
            send = send + "<b>   CPF / CNPJ    -      Nome    -    Endereço    -   RG / IE   -   Tipo  -   Valor   - Valor Imposto -   Total  </b>";

            int i = 0;
            string backColor = "", textColor = "";

            foreach (Clients cli in GetList())
            {
                if (i % 2 == 0)
                { backColor = "#6f47ff"; textColor = "white"; }
                else
                { backColor = "#ffffff"; textColor = "#6f47ff"; }
                i++;

                send = send +
               $"\n<br><div style='background-color:{backColor};color:{textColor};'>" +
                cli.cpf_cnpj + " - " +
                cli.name + " - " + cli.address + " - " + cli.rg_ie + " - " +
                cli.type + " - " + cli.value.ToString("C") + " - " +
                cli.value_taxes.ToString("C") + " - " + cli.total.ToString("C") + "<br>" +
                 "</div>";
            }
            return send;
        }

        public void PrintListConsole()
        {
            Console.WriteLine("   CPF / CNPJ   " + " - " + "    Nome   " +
                " - " + "   Endereço   " + " - " + "  RG / IE  " + " - " +
                "  Tipo " + " - " + "  Valor  " + " - " + "Valor Imposto" +
                " - " + "  Total  ");

            foreach (Clients cli in GetList())
            {
                Console.WriteLine(cli.cpf_cnpj + " - " +
                cli.name + " - " + cli.address + " - " + cli.rg_ie + " - " +
                cli.tipo + " - " + cli.value.ToString("C") + " - " +
                cli.value_taxes.ToString("C") + " - " + cli.total.ToString("C"));
            }
        }
    }
}