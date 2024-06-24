using Library.Models;

namespace Library.Data
{
    public static class Database
    {
        private static readonly List<Account> _accounts = [];

        private static readonly List<Card> _cards = [];

        public static List<Card> Cards => GetCards();

        public static List<Account> Accounts => GetAccounts();

        private static void FillCardsList()
        {
            _cards.Add(new Card { Number = "3665477898", Pin = "5589" });
            _cards.Add(new Card { Number = "3225447698", Pin = "6547" });
            _cards.Add(new Card { Number = "6987745123", Pin = "2547" });
            _cards.Add(new Card { Number = "0214554789", Pin = "3658" });
            _cards.Add(new Card { Number = "6455125898", Pin = "8789" });
        }

        private static List<Card> GetCards()
        {
            List<Card> copy = [];
            foreach (Card card in _cards)
            {
                Card temp = new() { Number = card.Number, Pin = card.Pin };
                copy.Add(temp);
            }
            return copy;
        }

        private static void FillAccountsList()
        {
            _accounts.Add(new Account() { Card = _cards[0], Balance = 250_000M });
            _accounts.Add(new Account() { Card = _cards[1], Balance = 500_000M });
            _accounts.Add(new Account() { Card = _cards[2], Balance = 750_000M });
            _accounts.Add(new Account() { Card = _cards[3], Balance = 1_000_000M });
            _accounts.Add(new Account() { Card = _cards[4], Balance = 2_500_000 });
        }

        private static List<Account> GetAccounts()
        {
            List<Account> copy = [];
            foreach (Account account in _accounts)
            {
                Account temp = new() { Holder = account.Holder, Card = account.Card, Balance = account.Balance };
                copy.Add(temp);
            }
            return copy;
        }

        public static void FeedData()
        {
            FillCardsList();
            FillAccountsList();
        }

        public static Account? FindAccountByCardNumber(string cardNumber)
        {
            foreach (Account account in Accounts)
                if (account.Card.Number == cardNumber)
                    return account;

            throw new NullReferenceException("There is no account linked to this card.");
        }

        public static Card? FindCardByNumber(string cardNumber)
        {
            foreach (Card card in Cards)
                if (card.Number == cardNumber)
                    return card;

            throw new NullReferenceException("There is no card linked to this card number.");
        }

        public static bool IsPinCorrect(Card card, string cardPin)
        {
            if (card.Pin == cardPin)
                return true;

            return false;
        }
    }
}
