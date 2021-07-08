using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Net.Http;

namespace Pladdra.API
{
    public class GraphQLClient
    {
        public string apiUrl;
        public string apiKey;
        private static GraphQLHttpClient graphQLHttpClient;

        public GraphQLHttpClient Connect(string url, string key)
        {
            apiUrl = url;
            apiKey = key;
            Uri uri = new Uri(apiUrl);
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = uri,
                PreprocessRequest = this.PreprocessRequest
            };

            graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());

            return graphQLHttpClient;
        }

        public Task<GraphQLResponse<T>> Request<T>(string completeQueryString)
        {
            var request = new GraphQLRequest
            {
                Query = completeQueryString
            };

            return graphQLHttpClient.SendQueryAsync<T>(request);
        }

        public Task<GraphQLHttpRequest> PreprocessRequest(GraphQLRequest request, GraphQLHttpClient client)
        {

            if (!client.HttpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                client.HttpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }

            return Task.FromResult(new GraphQLHttpRequest(request));
        }
    }
}