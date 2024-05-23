namespace Activity
{
    class JuridicalPerson : Clients
    {
        public string cnpj { get; set; }
        public string ie { get; set; }
        public override void PayTaxes(float value)
        {
            this.value = value;
            this.value_taxes = this.value * 20 / 100;
            this.total = this.value + this.value_taxes;
        }
    }
}