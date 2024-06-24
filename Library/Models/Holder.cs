using Library.Data;

namespace Library.Models
{
    public class Holder
    {
        public HolderName Name { get; init; }

        public Genders Gender { get; init; }

        private Honorifics Honorific { get; init; }

        private MaritalStatuses MaritalStatus { get; init; }

        public Holder()
        {
            int enumLenght;

            enumLenght = Enum.GetNames<Genders>().Length;
            Gender = (Genders)Utilities.GetRandomInt(enumLenght);

            enumLenght = Enum.GetNames<MaritalStatuses>().Length;
            MaritalStatus = (MaritalStatuses)Utilities.GetRandomInt(enumLenght);

            Name = new(Gender);
            Honorific = SetHonorific(Gender, MaritalStatus);
        }

        public string GetName() => $"{Honorific}. {Name.FirstName} {Name.LastName}";

        private static Honorifics SetHonorific(Genders gender, MaritalStatuses maritalStatus)
        {
            if (gender == Genders.Female && maritalStatus != MaritalStatuses.Married)
                return Honorifics.Ms;

            else if (gender == Genders.Female && maritalStatus == MaritalStatuses.Married)
                return Honorifics.Mrs;

            return Honorifics.Mr;
        }
    }

}
