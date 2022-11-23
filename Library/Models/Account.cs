namespace Library.Models
{
    public class Account
    {
        public Holder Holder { get; init; }

        public required Card Card { get; init; }

        public required decimal Balance { get; set; }

        public Account() 
        {
            Holder = new Holder();
            Balance = RandomizeBalance();
        }

        private static decimal RandomizeBalance()
        {
            int max = 100;

            return Utilities.GetRandomInt(max) + Utilities.GetRandomDecimal();
        }

        public void MakeDeposit(decimal amount) => Balance += amount;

        public void MakeWithdraw(decimal amount)
        {
            if (amount == 0)
                throw new ArgumentException("The minimum value that can be withdrawn is 10");

            else if (amount > Balance)
                throw new ArgumentException("The withdraw amount can't be greater than the account balance");

            Balance -= amount;
        }
    }
}
