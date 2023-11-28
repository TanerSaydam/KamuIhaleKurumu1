using Elasticsearch.Net;

namespace CleanArchitecture.Application.Services;

public static class ElasticSearchService
{
    private static string Uri = "http://localhost:9200";
    private static ElasticLowLevelClient GetClient()
    {
        var setting = new ConnectionConfiguration(new Uri(Uri));
        var client = new ElasticLowLevelClient(setting);
        return client;
    }

    public static async Task SyncToElastic<T>(string indexName, Func<Task<List<T>>> getDataFunc)
        where T : class
    {
        var client = GetClient();

        List<T> items = await getDataFunc();

        var tasks = new List<Task>();

        foreach (var item in items) 
        {
            var itemId = item.GetType().GetProperty("Id")?.GetValue(item).ToString();

            if (string.IsNullOrEmpty(itemId)) continue;

            var response = await client.GetAsync<StringResponse>(indexName, itemId);
            if(response.HttpStatusCode != 200)
            {
                tasks.Add(client.IndexAsync<StringResponse>(indexName, itemId, PostData.Serializable(item)));
            }
        }

        await Task.WhenAll(tasks);
    }
}
