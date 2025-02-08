using LigaMX.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace LigaMX.Repositories
{
    public class PartidoRepository
    {
        private readonly string filePath = "wwwroot/data/partidos.json";
        private List<LigaMx> partidos;

        public PartidoRepository()
        {
            partidos = LoadPartidosFromJson();
        }

        private List<LigaMx> LoadPartidosFromJson()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<LigaMx>>(json) ?? new List<LigaMx>();
            }
            return new List<LigaMx>();
        }

        private void SavePartidosToJson()
        {
            string json = JsonSerializer.Serialize(partidos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<LigaMx> GetAllPartidos()
        {
            return partidos;
        }

        public void AddPartido(LigaMx partido)
        {
            partidos.Add(partido);
            SavePartidosToJson();
        }

        public bool DeletePartido(string partido)
        {
            var result = partidos.FirstOrDefault(p => p.Partido == partido);
            if (result != null)
            {
                partidos.Remove(result);
                SavePartidosToJson();
                return true;
            }
            return false;
        }
    }
}
