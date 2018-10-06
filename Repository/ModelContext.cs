using Api.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ModelContext : IModelContext
{
    private readonly IMongoDatabase _database = null;

    public ModelContext(IOptions<Settings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        if (client != null)
            _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection<BaseModel> Model
    {
        get
        {
            return _database.GetCollection<BaseModel>("BaseModel");
        }
    }
}

public interface IModelContext
{
    IMongoCollection<BaseModel> Model { get; }
}