namespace Activity
{
    class Clients
{
    public string name { get; set; }
    public string address { get; set; }
    public float value { get; protected set; }
    public float value_taxes { get; protected set; }
    public float total { get; protected set; }
    public virtual void PayTaxes(float value)
    {
        this.value = value;
        this.value_taxes = this.value * 10 / 100;
        this.total = this.value + this.value_taxes;
    }
}
}