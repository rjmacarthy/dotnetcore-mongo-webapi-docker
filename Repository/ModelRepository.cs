using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Model;
using MongoDB.Bson;
using MongoDB.Driver;

public interface IModelRepository
{
    Task<IEnumerable<BaseModel>> Get();
    Task Create(BaseModel model);
}

public class ModelRepository : IModelRepository
{
    private readonly IModelContext _modelContext;

    public ModelRepository(IModelContext modelContext)
    {
        _modelContext = modelContext;
    }

    public async Task<IEnumerable<BaseModel>> Get()
    {
        try
        {
            return await _modelContext.Model.FindAsync(new BsonDocument()).GetAwaiter().GetResult().ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task Create(BaseModel model)
    {
        try
        {
            await _modelContext.Model.InsertOneAsync(model);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

