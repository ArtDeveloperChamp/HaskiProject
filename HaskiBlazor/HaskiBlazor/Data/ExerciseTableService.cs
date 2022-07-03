namespace HaskiBlazor.Data;

using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
public class ExerciseTableService
{
    public async Task<ExerciseTable[]> GetExercises (int? id)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
       
        string fileName = "Data/DataExercise.json";
        using FileStream openStream = File.OpenRead(fileName);
        var dataExs =
            await JsonSerializer.DeserializeAsync<ExerciseTable[]>(openStream)!;
        /*var countData = (id == null ? 1 : id);
        var startId = (id == null ? dataExs.Length : id);
        Task<ExerciseTable[]> exercises = Task.FromResult(Enumerable.Range(startId, countData).Select(index => new ExerciseTable
        {
            Id = id + 1,
            Name = Names[index],
            Note = Notes[index],
            Links = Names[index],
            Demand = Demands[index],
            ForExample = Examples[index].Split(';')  //System.Web.HttpUtility.HtmlEncode(Examples[index])
        }).ToArray());
        */
        return dataExs;
    }
}