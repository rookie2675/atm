using Library.Data;

namespace Library.Models
{
    public class HolderName
    {
        internal string? FirstName { get; private set; }

        internal string? LastName { get; private set; }

        public HolderName(Genders gender) => GenerateRandomNames(gender);

        private void GenerateRandomNames(Genders gender) 
        {
            GenerateRandomFirstName(gender);
            GenerateRandomLastName();
        }

        private void GenerateRandomFirstName(Genders gender)
        {
            int arraySize;

            int index;

            if (gender == Genders.Male)
            {
                arraySize = Names.maleNames.Length;

                index = Utilities.GetRandomInt(arraySize);

                FirstName = Names.maleNames[index];
            }

            else
            {
                arraySize = Names.femaleNames.Length;

                index = Utilities.GetRandomInt(arraySize);

                FirstName = Names.femaleNames[index];
            }
        }

        private void GenerateRandomLastName()
        {
            int arraySize = Names.lastNames.Length;

            int index = Utilities.GetRandomInt(arraySize);

            LastName = Names.lastNames[index];
        }
    }
}
