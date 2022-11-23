using Library.Models;

namespace Library.Data;

public class Validations
{
    public static void ValidateCard(string cardNumber, string insertedPin, out bool isAuthenticationSuccessfull ,out Account? account)
    {
        Card? card = Database.FindCardByNumber(cardNumber);

        if (card == null || Database.IsPinCorrect(card, insertedPin) == false)
        {
            account = null;
            isAuthenticationSuccessfull = false;
            return;
        }

        account = Database.FindAccountByCardNumber(cardNumber);
        isAuthenticationSuccessfull = true;
    }
}
