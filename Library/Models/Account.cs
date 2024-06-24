namespace Library.Models
{
    public class Account
    {
        private decimal _balance;

        public Holder Holder { get; init; }

        public required Card Card { get; init; }

        public required decimal Balance 
        { 
            get { return _balance; }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                _balance = value;
            } 
        }

        public Account() 
        {
            Holder = new Holder();
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
