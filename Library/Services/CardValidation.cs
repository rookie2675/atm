using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class CardValidation
    {
        public Account? AuthenticatedAccount { get; init; }

        public CardValidation(string number, string pin)
        {
            Card? card = Database.FindCardByNumber(number);

            if (card == null || Database.IsPinCorrect(card, pin) == false)
                return;

            AuthenticatedAccount = Database.FindAccountByCardNumber(number);
        }
    }
}
