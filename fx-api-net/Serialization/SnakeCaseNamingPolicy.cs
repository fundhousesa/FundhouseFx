using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FundhouseFx.Serialization
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new SerializationException($"Property name cannot be null or empty");

            var mutated = name.Select(FormatCharacter);
            
            return string.Concat(mutated).ToLowerInvariant();
        }

        private static string FormatCharacter(char character, int index)
        {
            if (index == 0) return character.ToString();
            if (char.IsUpper(character) || char.IsDigit(character))
                return $"_{character}";
            return character.ToString();
        }
    }
}