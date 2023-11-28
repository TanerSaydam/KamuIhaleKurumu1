using CleanArchitecture.Domain.Entities;
using Elasticsearch.Net;
using MediatR;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace CleanArchitecture.Application.Features.ProductFeature.Queries.GetAllProductWithElasticSearch
{
    public sealed class GetAllProductWithElasticSearchQueryHandler : IRequestHandler<GetAllProductWithElasticSearchQuery, List<Product>>
    {
        public async Task<List<Product>> Handle(GetAllProductWithElasticSearchQuery request, CancellationToken cancellationToken)
        {
            var setting = new ConnectionConfiguration(new Uri("http://localhost:9200"));
            var client = new ElasticLowLevelClient(setting);

            var response = await client.SearchAsync<StringResponse>("products", PostData.Serializable(new
            {
                query = new
                {
                    wildcard = new
                    {
                        Name = new { value = $"*{request.Search}*" }
                    }
                }
            }));

            var result = JObject.Parse(response.Body);
            var hits = result["hits"]["hits"].ToObject<List<JObject>>();

            List<Product> products = new();

            foreach (var hit in hits)
            {
                products.Add(hit["_source"].ToObject<Product>());
            }
            return new(products);
        }
    }
}
