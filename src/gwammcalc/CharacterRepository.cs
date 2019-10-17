using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GwammCalc
{
    public interface ICharacterRepository
    {
        Character GetCharacter(string characterName);
        IEnumerable<string> GetCharacterNames();
        void Add(Character acc);
        void Load();
        void Save();
    }

    public class CharacterRepository : ICharacterRepository
    {
        private List<Character> characters;
        private readonly string _filePath;

        public CharacterRepository(string filePath)
        {
            if (filePath != null)
            {
                _filePath = filePath;
                Load();
            }
        }

        public void Load()
        {
            if (!File.Exists(_filePath))
            {
                characters = new List<Character>();
                return;
            }

            string text = File.ReadAllText(_filePath);
            characters = JsonConvert.DeserializeObject<List<Character>>(text);
        }

        public void Add(Character acc)
        {
            characters.Add(acc);

            if (_filePath != null)
            {
                Save();
            }
        }

        public Character GetCharacter(string characterName)
        {
            return characters.First(c => c.CharacterName.Equals(characterName));
        }

        public IEnumerable<string> GetCharacterNames()
        {
            return characters.Select(c => c.CharacterName);
        }

        public void Save()
        {
            string text = JsonConvert.SerializeObject(characters, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }
    }
}

